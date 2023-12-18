using System;
using MySql.Data.MySqlClient;

namespace ConsolAppMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connexion à la BDD
            string cs = @"server=localhost;userid=root;password=;database=tuto";
            using var con = new MySqlConnection(cs);
            con.Open();
            Console.WriteLine("Connecté à la BDD !");

            // SELECT
            var stm = "SELECT VERSION()";
            var cmd = new MySqlCommand(stm, con);
            var v = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"MySQL version: {v}");

            // INSERT
            using var cmd2 = new MySqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "INSERT INTO listetutos(name, price) VALUES('WEB' , 79)";
            cmd2.ExecuteNonQuery();
            Console.WriteLine("Une ligne à été ajoutée");

            // SELECT TUTOS
            string sql = "SELECT name, price FROM listetutos";
            using var cmd3 = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd3.ExecuteReader();

            // Boucle sur les données pour les afficher
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " | " + rdr[1] + " EUR");
            }
        }

    }

}