using PhoneBook.Models;
using PhoneBook.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Services
{
    public class RepositoryService
    {
        private readonly IEnumerable<IDataProvider> _providers; 

        public RepositoryService(IEnumerable<IDataProvider> providers)
        {
            _providers = providers;
        }

        public IEnumerable<Entity> List()
        {
            // pour avoir une liste vide, j'instancie une liste en indiquant son type
            IEnumerable<Entity> accu = new List<Entity>();

            // pour une boucle : type e in enumérable
            foreach (IDataProvider provider in _providers)
            {
                // déclarer le type que pour nouvelle variable
                accu = accu.Concat(provider.List());
            }
            return accu; 
        }

        public IEnumerable<Entity> Search(string text)
        {
            IEnumerable<Entity> result = new List<Entity>();

            foreach (IDataProvider provider in _providers)
            {
                result = result.Concat(provider.Search(text));
            }
            return result; 
        }
    }
}
