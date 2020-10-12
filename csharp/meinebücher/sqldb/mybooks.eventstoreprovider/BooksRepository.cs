using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using mybooks.contracts;
using MySql.Data.MySqlClient;

namespace mybooks.dbprovider
{
    public class BooksRepository
    {
        private readonly MySqlConnection _connection;

        public BooksRepository() : this("MyBooks") {
        }

        internal BooksRepository(string databaseName) {
            var connectionString = CreateConnectionString();
            _connection = new MySqlConnection(connectionString);
            _connection.Execute($"USE {databaseName};");
        }

        internal static string CreateConnectionString() {
            var server = "127.0.0.1";
            var user = "root";
            var pwd = "geheim";
            return $"Server={server};Uid={user};Pwd={pwd};";
        }

        public bool TryAdd(Book book) {
            var sql = "INSERT INTO Books (Title, Lender, LendingDate, CanBeLended) Values (@Title, @Lender, @LendingDate, @CanBeLended)";
            return TryExecute(sql, book);
        }

        public bool TryUpdate(Book book) {
            var sql = "UPDATE Books SET Title = @Title, Lender = @Lender, LendingDate = @LendingDate, CanBeLended = @CanBeLended WHERE Id = @Id;";
            return TryExecute(sql, book);
        }

        public bool TryDeleteById(long id) {
            var sql = "DELETE FROM Books WHERE Id = @Id;";
            return TryExecute(sql, new{Id = id});
        }
        
        private bool TryExecute(string sql, object parameter) {
            try {
                var rowsAffected = _connection.Execute(sql, parameter);
                if (rowsAffected != 1) throw new Exception($"Rows affected should be 1 but was {rowsAffected}");
            }
            catch (MySqlException e) {
                if (e.Number == 1062) // Duplicate entry error
                    return false;

                throw e;
            }

            return true;
        }

        public static void CreateTables(MySqlConnection connection) {
            connection.Execute(@"
                CREATE TABLE Books (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Title VARCHAR(255) NOT NULL,
                    Lender VARCHAR(255) NOT NULL,
                    LendingDate DATETIME,
                    CanBeLended BOOLEAN NOT NULL
                    ) ENGINE=INNODB;
            ");
            connection.Execute("ALTER TABLE Books ADD CONSTRAINT TitleUnique UNIQUE KEY (Title);");
            connection.Execute("ALTER TABLE Books ADD FULLTEXT (Title, Lender)");
        }

        public Book GetById(in long id) {
            var sql = "SELECT Id, Title, Lender, LendingDate, CanBeLended FROM Books WHERE Id = @Id;";
            var result = _connection.QuerySingle<Book>(sql, new {Id = id});
            return result;
        }


        public IEnumerable<Book> LoadAll() {
            const string select = "SELECT Id, Title, Lender, LendingDate, CanBeLended FROM Books";
            var result = _connection.Query<Book>(select).ToList();
            return result;
        }
    }
}