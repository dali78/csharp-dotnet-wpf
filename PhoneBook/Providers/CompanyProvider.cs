using MySql.Data.MySqlClient;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Providers
{
    public class CompanyProvider : BaseProvider
    {
        protected override string GetTable()
        {
            return "company";
        }
        protected override Entity CreateItem(MySqlDataReader reader)
        {
            return new Company(Convert.ToInt32(reader["id"]), reader["name"].ToString());
        }

    }
}
