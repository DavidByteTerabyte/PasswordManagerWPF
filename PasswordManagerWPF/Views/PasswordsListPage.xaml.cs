using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using PasswordManagerWPF.Models;
namespace PasswordManagerWPF.Views
{
    public partial class PasswordsListPage : Page
    {
        public PasswordsListPage()
        {
            InitializeComponent();
            this.DataContext = DataStore.Passwords;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = txtSearch.Text.ToLower();
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgPasswords.ItemsSource);

            if (string.IsNullOrWhiteSpace(filterText))
            {
                cv.Filter = null;
            }
            else
            {
                cv.Filter = item =>
                {
                    //Додали ? для уникнення CS8600
                    PasswordEntry? entry = item as PasswordEntry;
                    return entry != null && entry.Site.ToLower().Contains(filterText);
                };
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            //Додали ? для уникнення CS8602
            var button = sender as Button;
            var entry = button?.DataContext as PasswordEntry;

            if (entry != null)
            {
                Clipboard.SetText(entry.Password);
                MessageBox.Show($"Пароль для {entry.Site} скопійовано!", "Скопійовано", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Додали ? для уникнення CS8602
            var button = sender as Button;
            var entry = button?.DataContext as PasswordEntry;

            if (entry != null)
            {
                var result = MessageBox.Show($"Ви дійсно хочете видалити пароль для {entry.Site}?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    DataStore.Passwords.Remove(entry);
                    DataStore.SaveToFile();
                }
            }
        }
    }
}