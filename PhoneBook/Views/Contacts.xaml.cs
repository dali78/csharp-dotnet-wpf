using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook.Views
{
    /// <summary>
    /// Logique d'interaction pour Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl
    {
        public Contacts()
        {
            InitializeComponent();
        }

        //On crée une fonction pour le bouton all my friends
        public void List_Click(object sender, RoutedEventArgs e)
        {
            // Data casting pour avoir le bon type de context
            (DataContext as ContactsViewModel).ExecuteList();
        }

        //On crée une fonction pour le bouton search
        public void Search_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ContactsViewModel).ExecuteSearch();
        }
    }
}
