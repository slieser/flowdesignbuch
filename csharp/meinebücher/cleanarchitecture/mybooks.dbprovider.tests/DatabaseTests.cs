using System;
using Dapper;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace mybooks.dbprovider.tests
{
    public class DatabaseTests
    {
        private MySqlConnection _connection = null!;
        private string _databaseName = null!;
        protected BooksRepository _booksRepository = null!;

        [SetUp]
        public void BaseSetup() {
            CreateDatabase($"tmp_{DateTime.Now:dd_MM_yyyy__hh_mm_ss}");
            _booksRepository = new BooksRepository(_databaseName);
        }

        protected void CreateDatabase(string databaseName) {
            var connectionString = BooksRepository.CreateConnectionString();
            _connection = new MySqlConnection(connectionString);

            _databaseName = databaseName;
            try {
                _connection.Execute($"CREATE DATABASE {_databaseName};");
                _connection.Open();
                _connection.ChangeDatabase(_databaseName);
            }
            catch (MySqlException e) {
                if (e.Number != 1007) {
                    // Database already exists
                    throw;
                }
            }

            BooksRepository.CreateTables(_connection);
        }

        [TearDown]
        public void Teardown() {
            _connection.Execute($"DROP DATABASE {_databaseName}");
        }
    }
}