using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        #region Employes

        private void comboBoxListePersonne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personne personne = (Personne)comboBoxListePersonne.SelectedItem;
            textBoxNom.Text = personne.Nom;
            textBoxPrenom.Text = personne.Prenom;
            textBoxRole.Text = personne.Role.Nom;
            textBoxAdresseNumero.Text = personne.Adresse.Numero.ToString();
            textBoxAdresseRue.Text = personne.Adresse.Rue;
            textBoxAdresseCP.Text = personne.Adresse.CodePostal.ToString();
            textBoxAdresseVille.Text = personne.Adresse.Ville;
            if (personne.Superieur != null)
                comboBoxListePersonneSuperieur.ItemsSource = GetListSuperieur(personne);
        }

        public List<Personne> GetListSuperieur(Personne personne)
        {
            List<Personne> listSuperieur = new List<Personne>();
            if (listSuperieur != null && listSuperieur.Count > 0)
            {
                listSuperieur = ControlerPersonne.RechercheToutLesEmployes();
                listSuperieur.Remove(personne); 
            }

            return listSuperieur;
        }

        private void comboBoxListePersonne_Initialized(object sender, EventArgs e)
        {
            List<Personne> personnes = ControlerPersonne.RechercheToutLesEmployes();
            if (personnes != null && personnes.Count > 0)
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = personnes;
            }
        }

        public void IsEditing(bool value = false)
        {
            if (value)
            {
                comboBoxListePersonne.IsEnabled = false;
                comboBoxListePersonne.IsEnabled = true;
                textBoxNom.IsEnabled = true;
                textBoxPrenom.IsEnabled = true;
                textBoxRole.IsEnabled = true;
                textBoxAdresseNumero.IsEnabled = true;
                textBoxAdresseRue.IsEnabled = true;
                textBoxAdresseCP.IsEnabled = true;
                textBoxAdresseVille.IsEnabled = true;
                AddButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
                SaveButton.Visibility = Visibility.Visible;
                CancelButton.Visibility = Visibility.Visible;
                comboBoxListePersonneSuperieur.Visibility = Visibility.Visible;
            }
            else
            {
                comboBoxListePersonne.IsEnabled = false;
                comboBoxListePersonneSuperieur.IsEnabled = false;
                textBoxNom.IsEnabled = false;
                textBoxPrenom.IsEnabled = false;
                textBoxRole.IsEnabled = false;
                textBoxAdresseNumero.IsEnabled = false;
                textBoxAdresseRue.IsEnabled = false;
                textBoxAdresseCP.IsEnabled = false;
                textBoxAdresseVille.IsEnabled = false;
                AddButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                SaveButton.Visibility = Visibility.Hidden;
                CancelButton.Visibility = Visibility.Hidden;
                comboBoxListePersonneSuperieur.Visibility = Visibility.Visible;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Hidden;
            EditButton.Visibility = Visibility.Hidden;
            SaveAddButton.Visibility = Visibility.Visible;
            CancelAddButton.Visibility = Visibility.Visible;
            textBoxNom.Text = string.Empty;
            textBoxPrenom.Text = string.Empty;
            textBoxRole.Text = string.Empty;
            textBoxAdresseNumero.Text = string.Empty;
            textBoxAdresseRue.Text = string.Empty;
            textBoxAdresseCP.Text = string.Empty;
            textBoxAdresseVille.Text = string.Empty;
            comboBoxListePersonne.IsEnabled = true;
            comboBoxListePersonneSuperieur.IsEnabled = true;
            textBoxNom.IsEnabled = true;
            textBoxPrenom.IsEnabled = true;
            textBoxRole.IsEnabled = true;
            textBoxAdresseNumero.IsEnabled = true;
            textBoxAdresseRue.IsEnabled = true;
            textBoxAdresseCP.IsEnabled = true;
            textBoxAdresseVille.IsEnabled = true;
            comboBoxListePersonneSuperieur.ItemsSource = GetListSuperieur(null);
        }

        public void SaveAdd(object sender, RoutedEventArgs e)
        {

            AddButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;
            Adresse adresse;
            string nom = textBoxNom.Text;
            string prenom = textBoxNom.Text;
            string role = textBoxRole.Text;
            if (!string.IsNullOrEmpty(textBoxAdresseNumero.Text) &&
                !string.IsNullOrEmpty(textBoxAdresseRue.Text) &&
                !string.IsNullOrEmpty(textBoxAdresseCP.Text) &&
                !string.IsNullOrEmpty(textBoxAdresseVille.Text))
                adresse = new Adresse(Convert.ToInt32(textBoxAdresseNumero.Text), textBoxAdresseRue.Text, textBoxAdresseVille.Text, Convert.ToInt32(textBoxAdresseCP.Text));
            else
                adresse = null;
            Personne superieur = (Personne)comboBoxListePersonneSuperieur.SelectedItem;

            if (!string.IsNullOrEmpty(nom) && !string.IsNullOrEmpty(prenom) &&
                !string.IsNullOrEmpty(role) && adresse != null)
                Personne.InsertPersonne(new Personne(nom, prenom));
            comboBoxListePersonne.IsEnabled = true;
            comboBoxListePersonneSuperieur.IsEnabled = false;
            textBoxNom.IsEnabled = false;
            textBoxPrenom.IsEnabled = false;
            textBoxRole.IsEnabled = false;
            textBoxAdresseNumero.IsEnabled = false;
            textBoxAdresseRue.IsEnabled = false;
            textBoxAdresseCP.IsEnabled = false;
            textBoxAdresseVille.IsEnabled = false;
            SaveAddButton.Visibility = Visibility.Hidden;
            CancelAddButton.Visibility = Visibility.Hidden;
            comboBoxListePersonne.SelectedItem = this;
        }

        public void CancelAdd(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;
            SaveAddButton.Visibility = Visibility.Hidden;
            CancelAddButton.Visibility = Visibility.Hidden;
            comboBoxListePersonne.IsEnabled = true;
            textBoxNom.IsEnabled = false;
            textBoxPrenom.IsEnabled = false;
            textBoxRole.IsEnabled = false;
            textBoxAdresseNumero.IsEnabled = false;
            textBoxAdresseRue.IsEnabled = false;
            textBoxAdresseCP.IsEnabled = false;
            textBoxAdresseVille.IsEnabled = false;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (comboBoxListePersonne.SelectedItem != null)
            {
                IsEditing(true);
            }
        }

        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxListePersonne.SelectedItem != null)
                {
                    Personne personne = (Personne)comboBoxListePersonne.SelectedItem;
                    Adresse adresse = personne.Adresse;

                    adresse.Numero = Convert.ToInt32(textBoxAdresseNumero.Text);
                    adresse.Rue = textBoxAdresseRue.Text;
                    adresse.CodePostal = Convert.ToInt32(textBoxAdresseCP.Text);
                    adresse.Ville = textBoxAdresseVille.Text;
                    Adresse.UpdateAdresse(adresse);

                    personne.Nom = textBlockNom.Text;
                    personne.Prenom = textBlockPrenom.Text;
                    personne.Role = new Role(textBoxRole.Text);
                    personne.Adresse = adresse;
                    personne.Superieur = comboBoxListePersonneSuperieur.SelectedItem == null ? null : (Personne)comboBoxListePersonne.SelectedItem;
                    Personne.UpdatePersonne(personne);
                }
                IsEditing();
            }
            catch (Exception)
            {
                throw new Exception("NotImplementedException");
            }
        }

        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            if (comboBoxListePersonne.SelectedItem != null)
            {
                Personne personne = (Personne)comboBoxListePersonne.SelectedItem;
                textBoxNom.Text = personne.Nom;
                textBoxPrenom.Text = personne.Prenom;
                textBoxRole.Text = personne.Role.Nom;
                textBoxAdresseNumero.Text = personne.Adresse.Numero.ToString();
                textBoxAdresseRue.Text = personne.Adresse.Rue;
                textBoxAdresseCP.Text = personne.Adresse.CodePostal.ToString();
                textBoxAdresseVille.Text = personne.Adresse.Ville;
                if (personne.Superieur != null)
                    comboBoxListePersonneSuperieur.ItemsSource = GetListSuperieur(personne);
            }
            IsEditing();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Êtes-vous sûre de vouloir supprimer cet employé ?",
                            "Supprimer",
                            MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Personne.DeletePersonne((Personne)comboBoxListePersonne.SelectedItem);
 
            }
        }

        #endregion

        #region Conges

        private void comboBoxListePersonneConges_Initialized(object sender, EventArgs e)
        {
            List<Personne> personnes = ControlerPersonne.RechercheToutLesEmployes();
            if (personnes != null && personnes.Count > 0)
            {
                comboBoxListePersonne.ItemsSource = personnes;
            }
        }

        private void ComboBoxTypeConge_Initialized(object sender, EventArgs e)
        {
            List<TypeConges> typeConges = TypeCongeController.RechercheTousLesConges();
            var combo = sender as ComboBox;
            combo.ItemsSource = typeConges;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddConge(object sender, RoutedEventArgs e)
        {
            if (ComboBoxPersonnesConge.SelectedItem != null &&
                DatePickerDebut.SelectedDate != null && 
                DatePickerDebut.SelectedDate >= DateTime.Now &&
                DatePickerFin.SelectedDate != null &&
                ComboBoxTypeConge != null) 
            {
                Personne p = (Personne)ComboBoxPersonnesConge.SelectedItem;
                TypeConges tc = (TypeConges)ComboBoxTypeConge.SelectedItem;
                int idPersonne = p.IdPersonne;
                int idTypeConges = tc.IdTypeConges;
                Conges.AddConge(new Conges(DatePickerDebut.SelectedDate.Value,
                                            DatePickerFin.SelectedDate.Value,
                                            idPersonne,
                                            idTypeConges));
                TypeConges typeConges = (TypeConges)ComboBoxTypeConge.SelectedItem;
                TextBoxNombreConges.Text = (typeConges.JoursConges - Conges.GetNombreCongeRestant(typeConges)).ToString();
            }
        }


        #endregion

        #region TypeConges

        public void ComboBoxTypesConges_Initialized(object sender, EventArgs e)
        {
            List<TypeConges> typeConges = TypeCongeController.RechercheTousLesConges();
            if (typeConges != null && typeConges.Count > 0)
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = typeConges;
            }
        }

        private void comboBoxTypeConges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConges typeConges = (TypeConges)ComboBoxListeTypeConges.SelectedItem;
            TextBoxNombreJours.Text = typeConges.JoursConges.ToString();
            TextBoxLibelle.Text = typeConges.Libelle;
            CheckboxValidationTypeConges.IsChecked = typeConges.ValidationObligatoire;
            TextBoxPays.Text = typeConges.Pays;
        }

        private void CheckBoxIsChecked(object sender, RoutedEventArgs e)
        {
            if (CheckboxValidationTypeConges.IsChecked == true)
                CheckboxValidationTypeConges.Content = "Oui";
            else
                CheckboxValidationTypeConges.Content = "Non";
        }

        private void AddButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            IsAddingTypeConges(true);
        }

        private void SaveAddButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nbJourConges = Convert.ToInt32(TextBoxNombreJours.Text);
                string libelle = TextBoxLibelle.Text;
                bool validation = (bool)CheckboxValidationTypeConges.IsChecked;
                string pays = TextBoxPays.Text;

                TypeConges.AddTypeConges(new TypeConges(nbJourConges, libelle, validation, pays));
            }
            catch (Exception ex)
            {
                throw new Exception("NotImplementedException");
            }
            finally
            {
                IsAddingTypeConges(false);
            }
        }

        private void UpdateComboboxes()
        {
            ComboBoxTypeConge.ItemsSource = TypeCongeController.RechercheTousLesConges();
            ComboBoxListeTypeConges.ItemsSource = TypeCongeController.RechercheTousLesConges();
        }

        private void CancelAddButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            IsAddingTypeConges(false);
        }

        private void IsAddingTypeConges(bool value)
        {
            if (value)
            {
                ComboBoxListeTypeConges.IsEnabled = false;
                TextBoxNombreJours.IsEnabled = true;
                TextBoxLibelle.IsEnabled = true;
                CheckboxValidationTypeConges.IsEnabled = true;
                TextBoxPays.IsEnabled = true;
                TextBoxNombreJours.Text = string.Empty;
                TextBoxLibelle.Text = string.Empty;
                CheckboxValidationTypeConges.IsChecked = false;
                ComboBoxListeTypeConges.ItemsSource = TypeConges.SearchGroupTypeConges();
                TextBoxPays.Text = string.Empty;
                AddButtonTypeConges.Visibility = Visibility.Hidden;
                EditButtonTypeConges.Visibility = Visibility.Hidden;
                DeleteButtonTypeConges.Visibility = Visibility.Hidden;
                SaveAddButtonTypeConges.Visibility = Visibility.Visible;
                CancelAddButtonTypeConges.Visibility = Visibility.Visible;
                SaveEditButtonTypeConges.Visibility = Visibility.Hidden;
                CancelEditButtonTypeConges.Visibility = Visibility.Hidden;
            }
            else
            {
                ComboBoxListeTypeConges.IsEnabled = true;
                TextBoxNombreJours.IsEnabled = false;
                TextBoxLibelle.IsEnabled = false;
                CheckboxValidationTypeConges.IsEnabled = false;
                TextBoxPays.IsEnabled = false;
                TextBoxNombreJours.Text = string.Empty;
                TextBoxLibelle.Text = string.Empty;
                CheckboxValidationTypeConges.IsChecked = false;
                ComboBoxListeTypeConges.ItemsSource = TypeConges.SearchGroupTypeConges();
                TextBoxPays.Text = string.Empty;
                AddButtonTypeConges.Visibility = Visibility.Visible;
                EditButtonTypeConges.Visibility = Visibility.Visible;
                DeleteButtonTypeConges.Visibility = Visibility.Visible;
                SaveAddButtonTypeConges.Visibility = Visibility.Hidden;
                CancelAddButtonTypeConges.Visibility = Visibility.Hidden;
                SaveEditButtonTypeConges.Visibility = Visibility.Hidden;
                CancelEditButtonTypeConges.Visibility = Visibility.Hidden;
            }
        }

        private void EditButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxTypeConge.SelectedItem != null)
            {
                IsEditingTypeConges(true);
                TypeConges typeConges = (TypeConges)ComboBoxTypeConge.SelectedItem;
                TextBoxNombreJours.Text = typeConges.JoursConges.ToString();
                TextBoxLibelle.Text = typeConges.Libelle;
                CheckboxValidationTypeConges.IsChecked = (bool)typeConges.ValidationObligatoire;
                TextBoxPays.Text = typeConges.Pays;
            }
        }

        private void SaveEditButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            IsEditingTypeConges(false);
            try
            {
                TypeConges typeConges = (TypeConges)ComboBoxTypeConge.SelectedItem;
                typeConges.JoursConges = Convert.ToInt32(TextBoxNombreJours.Text);
                typeConges.Libelle = TextBoxLibelle.Text;
                typeConges.ValidationObligatoire = (bool)CheckboxValidationTypeConges.IsChecked;
                typeConges.Pays = TextBoxPays.Text;

                TypeConges.UpdateTypeConges(typeConges);
            }
            catch (Exception)
            {
                throw new Exception("NotImplementedException");
            }
        }

        private void CancelEditButtonTypeConges_Click(object sender, RoutedEventArgs e)
        {
            IsEditingTypeConges(false);
        }

        private void IsEditingTypeConges(bool value)
        {
            if (value)
            {
                ComboBoxTypeConge.IsEnabled = false;
                TextBoxNombreJours.IsEnabled = true;
                TextBoxLibelle.IsEnabled = true;
                CheckboxValidationTypeConges.IsEnabled = true;
                TextBoxPays.IsEnabled = true;
                ComboBoxTypeConge.ItemsSource = TypeConges.SearchGroupTypeConges();
                AddButtonTypeConges.Visibility = Visibility.Hidden;
                EditButtonTypeConges.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
                SaveAddButtonTypeConges.Visibility = Visibility.Hidden;
                CancelAddButtonTypeConges.Visibility = Visibility.Hidden;
                SaveEditButtonTypeConges.Visibility = Visibility.Visible;
                CancelEditButtonTypeConges.Visibility = Visibility.Visible;
            }
            else
            {
                ComboBoxTypeConge.IsEnabled = true;
                TextBoxNombreJours.IsEnabled = false;
                TextBoxLibelle.IsEnabled = false;
                CheckboxValidationTypeConges.IsEnabled = false;
                TextBoxPays.IsEnabled = false;
                ComboBoxTypeConge.ItemsSource = TypeConges.SearchGroupTypeConges();
                AddButtonTypeConges.Visibility = Visibility.Visible;
                EditButtonTypeConges.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                SaveAddButtonTypeConges.Visibility = Visibility.Hidden;
                CancelAddButtonTypeConges.Visibility = Visibility.Hidden;
                SaveEditButtonTypeConges.Visibility = Visibility.Hidden;
                CancelEditButtonTypeConges.Visibility = Visibility.Hidden;
            }
        }


        private void DeleteTypeConges(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Êtes-vous sûre de vouloir supprimer ce type de congé ?",
                            "Supprimer un type de congés",
                            MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                TypeConges.DeleteTypeConges((TypeConges)comboBoxListePersonne.SelectedItem);
            }
        }

#endregion


        
    }
}
