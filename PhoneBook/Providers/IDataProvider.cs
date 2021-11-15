using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Providers
{
    public interface IDataProvider
    {
        // pas d'implémentation pour interface
        IEnumerable<Entity> List();
        IEnumerable<Entity> Search(string text);
    }
}
