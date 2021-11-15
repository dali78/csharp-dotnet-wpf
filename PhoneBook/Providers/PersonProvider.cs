using MySql.Data.MySqlClient;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Providers
{
    public class PersonProvider : BaseProvider
    {
        protected override string GetTable()
        {
            return "person";
        }

        protected override Entity CreateItem(MySqlDataReader reader)
        {
            return new Person(Convert.ToInt32(reader["id"]), reader["firstname"].ToString(), reader["lastname"].ToString());
        }
    }
}
