using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Models
{
    public class Person : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        // j'appelle directement id dans base
        // Dans mon constructeur, je mets en paramètre ce dont j'ai besoin pour construire un objet
        public Person (int id, string firstname, string lastname) : base (id)
        {
            // pas besoin d'appeler id, se fera automatiquement grâce au base(id)
            Firstname = firstname;
            Lastname = lastname;
        }

        public override string ToString()
        {
            return Id + ": " + Firstname + " " + Lastname;
        }
    }
}
