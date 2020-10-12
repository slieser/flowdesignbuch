using System;
using Dapper;
using mybooks.dbprovider;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace kunden.tests
{
    [TestFixture]
    public class Integrationstests
    {
        private MySqlConnection _connection;
        private string _databaseName;
        private BooksRepository _booksRepository;

        [SetUp]
        public void Setup() {
            CreateDatabase($"tmp_{DateTime.Now:dd_MM_yyyy__hh_mm_ss}");

            _booksRepository = new BooksRepository(_databaseName);
        }

        private void CreateDatabase(string databaseName) {
            var connectionString = BooksRepository.CreateConnectionString();
            _connection = new MySqlConnection(connectionString);

            _databaseName = databaseName;
            _connection.Execute($"CREATE DATABASE {_databaseName}; USE {_databaseName};");

            BooksRepository.CreateTables(_connection);
        }

        [TearDown]
        public void Teardown() {
//            _connection.Execute($"DROP DATABASE {_databaseName}");
        }

        [Test, Explicit]
        public void CreateProductiveDatabase() {
            CreateDatabase("MyBooks");
        }
    }
}