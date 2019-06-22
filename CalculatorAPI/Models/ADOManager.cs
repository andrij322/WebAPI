using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.IO;

namespace CalculatorAPI.Models
{
    public class ADOManager:IConnectionManager
    {
        private List<Action> actions;
        private SQLiteConnection connection;


        public ADOManager(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            actions = new List<Action>();
        }


        public void Dispose()
        {
            connection.Close();
        }


        public int WriteAction(Action action)
        {
            var query = $"insert into Actions(Name,Number1,Number2,Result) values ('{action.Name}',{action.Number1},{action.Number2},{action.Result})";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }


        public List<Action> GetActions()
        {
            var query = "select * from Actions";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            var reader = command.ExecuteReader();
            ReadActions(reader);
            return actions;
        }


        private void ReadActions(SQLiteDataReader reader)
        {
            var action = new Action();
            while (reader.Read())
            {
                action.Id = reader.GetInt32(0);
                action.Name = reader.GetString(1);
                action.Number1 = reader.GetInt32(2);
                action.Number2 = reader.GetInt32(3);
                action.Result = reader.GetInt32(4);
                actions.Add(action);
            }
        }


        public Action GetActionById(int id)
        {
            var query = $"select * from Actions where Id={id}";
            Action action = new Action();
            SQLiteCommand command = new SQLiteCommand(query, connection);


            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                action.Id = reader.GetInt32(0);
                action.Name = reader.GetString(1);
                action.Number1 = reader.GetInt32(2);
                action.Number2 = reader.GetInt32(3);
                action.Result = reader.GetInt32(4);
            }
            return action;
        }

        public int DeleteAction(int id)
        {
            var query = $"delete from Actions where id={id}";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}