using PhoneBook.Providers;
using PhoneBook.Services;
using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Je déclare deux propriétés ViewModel
        private readonly AboutViewModel _aboutViewModel;
        private readonly ContactsViewModel _contactsViewModel;

        public MainWindow() //constructeur
        {
            IDataProvider jose = new PersonProvider();
            IDataProvider sophie = new CompanyProvider();

            IEnumerable<IDataProvider> providers = new List<IDataProvider>() { jose, sophie };
            RepositoryService bertrand = new RepositoryService(providers);

            // J'instancie les deux propriétés
            _aboutViewModel = new AboutViewModel();
            _contactsViewModel = new ContactsViewModel(bertrand);

            InitializeComponent();
        }

        //au lieu d'instancier des objets, j'appelle directement les propriétés
        public void About_Click(object sender, RoutedEventArgs e)
        {
            DataContext = _aboutViewModel;
        }

        public void Contacts_Click(object sender, RoutedEventArgs e)
        {
            DataContext = _contactsViewModel;
        }
    }
}
