using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Models
{
    public abstract class Entity
    {
        //public avant le type
        public int Id { get; set; }

        // pour créer un constructeur, même nom que la classe
        public Entity(int id)
        {
            Id = id;
        }
    }
}
