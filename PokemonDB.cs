using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestSQLlite
{
    internal class PokemonDB
    {
        public PokemonDB() 
        { 
        }

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public void CreateDatabaseAndTable()
        {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                string sql = @"CREATE TABLE Student(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               FirstName           TEXT      NOT NULL,
                               LastName            TEXT       NOT NULL
                            );";
                con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                con.Open();
                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            }
        }
        public void AddData(string name, string lastname)
        {
            cmd = new SQLiteCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Student(FirstName,LastName) values ('" + name + "','" + lastname + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void SelectData()
        {
            int counter = 0;
            cmd = new SQLiteCommand("Select * From Student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                counter++;
                Console.WriteLine(dr[0] + " : " + dr[1] + " " + dr[2]);

            }
            con.Close();

        }
        public void ClearDB()
        {
            cmd = new SQLiteCommand("Delete From Student", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ResetAutoIncrement();

        }

        public void ResetAutoIncrement()
        {
            cmd = new SQLiteCommand("UPDATE `sqlite_sequence` SET `seq` = 0 WHERE `name` = 'Student';", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
