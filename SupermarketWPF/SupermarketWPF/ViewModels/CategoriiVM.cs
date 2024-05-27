using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SupermarketWPF.Models;
using SupermarketWPF.Helpers;

namespace SupermarketWPF.ViewModels
{
    public class CategoriiVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _id;
        private string _numeCategorie;
        private Categorii _selectedCategorie;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string NumeCategorie
        {
            get { return _numeCategorie; }
            set { _numeCategorie = value; OnPropertyChanged(nameof(NumeCategorie)); }
        }

        public Categorii SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; OnPropertyChanged(nameof(SelectedCategorie)); }
        }

        public ObservableCollection<Categorii> CategoriiList { get; set; }
        public ICommand AddCategorieCommand { get; }
        public ICommand UpdateCategorieCommand { get; }
        public ICommand DeleteCategorieCommand { get; }

        public CategoriiVM()
        {
            _context = new SupermarketDBEntities();
            CategoriiList = new ObservableCollection<Categorii>(_context.Categorii.ToList());
            AddCategorieCommand = new RelayCommand(AddCategorie);
            UpdateCategorieCommand = new RelayCommand(UpdateCategorie);
            DeleteCategorieCommand = new RelayCommand(DeleteCategorie);
        }

        private void AddCategorie(object obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NumeCategorie))
                {
                    MessageBox.Show("Numele categoriei este obligatoriu.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_context.Categorii.Any(c => c.NumeCategorie == NumeCategorie))
                {
                    MessageBox.Show("Există deja o categorie cu acest nume.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var categorie = new Categorii
                {
                    NumeCategorie = NumeCategorie
                };

                _context.Categorii.Add(categorie);
                _context.SaveChanges();
                CategoriiList.Add(categorie);

                NumeCategorie = string.Empty;
                OnPropertyChanged(nameof(NumeCategorie));

                MessageBox.Show("Categorie adăugată: " + categorie.NumeCategorie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Categorie Error");
            }
        }

        private void UpdateCategorie(object obj)
        {
            try
            {
                if (Id == 0 || string.IsNullOrWhiteSpace(NumeCategorie))
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var categorie = _context.Categorii.FirstOrDefault(c => c.Id == Id);
                if (categorie == null)
                {
                    MessageBox.Show($"Categoria cu ID-ul {Id} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                categorie.NumeCategorie = NumeCategorie;
                _context.SaveChanges();

                MessageBox.Show("Categorie actualizată: " + categorie.NumeCategorie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Categorie Error");
            }
        }

        private void DeleteCategorie(object obj)
        {
            try
            {
                if (SelectedCategorie == null)
                {
                    MessageBox.Show("Selectați o categorie pentru a o șterge.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var categorieDeSters = SelectedCategorie; // Salvați referința la categoria de șters

                categorieDeSters.IsActive = false;
                _context.SaveChanges();

                CategoriiList.Remove(categorieDeSters);
                SelectedCategorie = null;
                OnPropertyChanged(nameof(SelectedCategorie));

                MessageBox.Show("Categorie ștearsă: " + categorieDeSters.NumeCategorie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Categorie Error");
            }
        }
    }
}
