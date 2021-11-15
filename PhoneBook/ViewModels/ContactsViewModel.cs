using PhoneBook.Models;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PhoneBook.ViewModels
{
    // Création de notre observable Etape 1
    // On implémente une interface qui est déjà présente, qui dicte à la vue de se rafraichir car une propriété a changé INotifyPropertyChanged
    public class ContactsViewModel : INotifyPropertyChanged
    {
        //création d'une propriété qui contient la liste, je n'oublie pas get, set.
        public IEnumerable<string> Results { get; set; }
        //propriété qui récupère le texte entré dans l'input
        public string SearchText { get; set; }
        //dans cette propriété, il y a bertrand maintenant
        private readonly RepositoryService _repositoryService;
        // Création de notre observable Etape 2
        // Cela m'a créé automatiquement un évènement
        public event PropertyChangedEventHandler PropertyChanged;

        //création du constructeur
        //Si je veux initialiser une valeur, je peux la mettre dans le constructeur
        public ContactsViewModel(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            //à l'intérieur du constructeur, j'instancie cette liste
            //Results = new List<string>() { "Bonjour", "comment", "ça", "va" };
            //sans cette ligne, le SearchText est à null donc si je clique sur le bouton, crée une erreur, car le ToString attend qqchose
            SearchText = "";
        }

        //Je crée une fonction ExecuteLIst() qui appelle la liste du RepositoryService
        public void ExecuteList()
        {
            // c'est pour ça que j'appelle la méthode de Bertrand à la ligne 28. Je dois indiquer le type
            IEnumerable<Entity> results = _repositoryService.List();
            // Comme je récupère une liste d'entity de Bertrand, je dois la convertir en string. 
            Results = results.Select(x => x.ToString());
            // Création de notre observable Etape 3: Envoi de données
            //On appelle l'évènement PropertyChanged comme une fonction. En premier paramètre, on écrit qui envoie les données, c'est cet objet donc this
            // En deuxième paramètre, on met l'évènement que j'envoie donc j'instancie un objet en lui indiquant quelle propriété a changé en chaine de caractères
            PropertyChanged(this, new PropertyChangedEventArgs("Results"));
        }

        public void ExecuteSearch()
        {
            // appel de la méthode Search() du RepositoryService
            IEnumerable<Entity> results = _repositoryService.Search(SearchText);
            Results = results.Select(x => x.ToString());
            PropertyChanged(this, new PropertyChangedEventArgs("Results"));
            // j'injecte dans la propriété une string vide
            SearchText = "";
            // j'appelle à nouveau l'évènement PropertyChanged pour dire à la vue que ma propriété a changé
            PropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
        }


    }
}
