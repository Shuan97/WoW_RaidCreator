using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator
{
    public static class DatabaseConnectionHandler
    {
        private static readonly string ConnectionString;
        private static SqlConnection _conn;
        private static SqlCommand _command;
        private static SqlDataAdapter _adapter;
        //private static SqlDataReader _reader;
        private static DataTable _characterTable;

        public static DataTable CharacterTable
        {
            get => _characterTable;
            set
            {
                if (_characterTable != null && value == _characterTable) return;
                _characterTable = value;
            }
        }

        static DatabaseConnectionHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["WoW_RaidCreator.Properties.Settings.DatabaseConnectionString"].ConnectionString;
        }

        public static DataTable GetTable()
        {
            return CharacterTable;
        }

        public static void GetData()
        {
            const string query = "SELECT * FROM Characters";
            using (_conn = new SqlConnection(ConnectionString))
            using (_command = new SqlCommand(query, _conn))
            using (_adapter = new SqlDataAdapter(_command))
            {
                _characterTable = new DataTable();
                _adapter.Fill(_characterTable);
                CharacterTable = _characterTable;
            }
        }

        public static void Insert(Character character)
        {
            const string query = "INSERT INTO Characters " +
                                 "(Name, Class, MainSpec, OffSpec, MainSpecGearScore, OffSpecGearScore, Player)" +
                                 "VALUES (@Name, @Class, @MainSpec, @OffSpec, @MainSpecGearScore, @OffSpecGearScore, 'Player')";
            using (_conn = new SqlConnection(ConnectionString))
            using (_command = new SqlCommand(query, _conn))
            {
                _conn.Open();
                _command.Parameters.AddWithValue("@Name", character.Name);
                _command.Parameters.AddWithValue("@Class", character.Class);
                _command.Parameters.AddWithValue("@MainSpec", character.MainSpec);
                _command.Parameters.AddWithValue("@OffSpec", character.OffSpec);
                _command.Parameters.AddWithValue("@MainSpecGearScore", character.MainSpecGearScore);
                _command.Parameters.AddWithValue("@OffSpecGearScore", character.OffSpecGearScore);
                //_command.ExecuteScalar();
                _command.ExecuteNonQuery();
            }
            //Console.WriteLine("Inserted");
            GetData();
        }

        public static void Delete(Character character)
        {
            const string query = "DELETE FROM Characters WHERE Id=@Id";
            using (_conn = new SqlConnection(ConnectionString))
            using (_command = new SqlCommand(query, _conn))
            {
                _conn.Open();
                _command.Parameters.AddWithValue("@Id", character.Id);
                //_command.ExecuteNonQuery();
                _command.ExecuteScalar();
            }
            GetData();
        }
    }
}
