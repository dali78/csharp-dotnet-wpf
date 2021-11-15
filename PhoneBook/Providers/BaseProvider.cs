using MySql.Data.MySqlClient;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Providers
{
    public abstract class BaseProvider : IDataProvider
    {
        protected abstract string GetTable();
        protected abstract Entity CreateItem(MySqlDataReader reader);
        private IEnumerable<Entity> GetData()
        {
            string connectionString = "server=localhost;port=3306;user=root;password=;database=adodotnet";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM " + GetTable(), connection);

            MySqlDataReader reader = command.ExecuteReader();
            List<Entity> results = new List<Entity>();
            while (reader.Read())
            {
                // comme j'ai déjà un constructeur, je mets directement les readers dans les paramètres de mon instanciation d'objet, pas dans des {}
                Entity item = CreateItem(reader);
                results.Add(item);
            }

            connection.Close();
            return results;
        }

        public IEnumerable<Entity> List()
        {
            return GetData();
        }

        public IEnumerable<Entity> Search(string text)
        {
            string search = text.ToLower();
            //J'instancie une nouvelle liste
            List<Entity> results = new List<Entity>();
            foreach (Entity item in GetData())
            {
                if (item.ToString().ToLower().Contains(search))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        
    }
}
