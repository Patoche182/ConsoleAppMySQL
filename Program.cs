using System;
using MySql.Data.MySqlClient;

namespace ConsolAppMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connexion à la BDD
            string cs = @"server=localhost;userid=root;password=;database=tutoMySql";
            using var con = new MySqlConnection(cs);
            con.Open();
            Console.WriteLine($"Connecté à la BDD");

            // SELECT
            var stm = "SELECT VERSION()";
            var cmd = new MySqlCommand(stm, con);
            var v = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"MySQL version: {v}");

            // INSERT
            using var cmd2 = new MySqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "INSERT INTO listeTutos(name, price) VALUES('WPF' , 49)";
            cmd2.ExecuteNonQuery();
            Console.WriteLine("Une ligne à été ajoutée");
        }

    }

}