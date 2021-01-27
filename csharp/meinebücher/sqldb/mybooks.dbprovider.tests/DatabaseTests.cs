using System;
using Dapper;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace mybooks.dbprovider.tests
{
    public class DatabaseTests
    {
        private MySqlConnection _connection;
        private string _databaseName;
        protected BooksRepository _booksRepository;

        [SetUp]
        public virtual void Setup() {
            CreateDatabase($"tmp_{DateTime.Now:dd_MM_yyyy__hh_mm_ss}");
            _booksRepository = new BooksRepository(_databaseName);
        }

        protected void CreateDatabase(string databaseName) {
            var connectionString = BooksRepository.CreateConnectionString();
            _connection = new MySqlConnection(connectionString);

            _databaseName = databaseName;
            _connection.Execute($"CREATE DATABASE {_databaseName}; USE {_databaseName};");

            BooksRepository.CreateTables(_connection);
        }

        [TearDown]
        public void Teardown() {
            _connection.Execute($"DROP DATABASE {_databaseName}");
        }
    }
}