using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using RomainJ.MinieBicks.lib;
using RomainJ.MinieBicks.Data;

namespace RomainJ.MinieBicks.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void comboBoxListePersonne_Loaded(object sender, RoutedEventArgs e)
        {
            List<Personne> personnes = ControlerPersonne.RechercheToutLesEmployes();

            var combo = sender as ComboBox;

            combo.ItemsSource = personnes;


        }

        private void comboBoxListePersonne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personne personne = (Personne)comboBoxListePersonne.SelectedItem;

            textBoxNom.Text = personne.Nom;

            textBoxPrenom.Text = personne.Prenom;

            textBoxRole.Text = personne.Role.Nom;

            textBoxAdresse.Text = personne.Adresse.Numero + " " + personne.Adresse.Rue + personne.Adresse.Ville;

            if (personne.Superieur != null)
                textBoxSuperieur.Text = personne.Superieur.Nom + " " + personne.Superieur.Prenom;
            else
                textBoxSuperieur.Text = "Pas de supérieur";

        }
    }
}
