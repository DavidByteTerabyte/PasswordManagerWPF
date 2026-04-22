using System.Windows;
using System.Windows.Controls;
using PasswordManagerWPF.Models;
namespace PasswordManagerWPF.Views
{
    public partial class AddPasswordPage : Page
    {
        //Поточний пароль, який ми вводимо
        public PasswordEntry CurrentEntry { get; set; }

        public AddPasswordPage()
        {
            InitializeComponent();
            CurrentEntry = new PasswordEntry();

            //Встановлюємо DataContext (Вимога Етапу 6)
            this.DataContext = CurrentEntry;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataStore.Passwords.Add(CurrentEntry);

            //Одразу зберігаємо зміни у файл ===
            DataStore.SaveToFile();

            MessageBox.Show("Пароль успішно збережено у сейф!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            CurrentEntry = new PasswordEntry();
            this.DataContext = CurrentEntry;
        }
    }
}