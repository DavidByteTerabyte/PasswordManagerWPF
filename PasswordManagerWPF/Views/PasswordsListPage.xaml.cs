using System.Windows.Controls;
using PasswordManagerWPF.Models;
namespace PasswordManagerWPF.Views
{
    public partial class PasswordsListPage : Page
    {
        public PasswordsListPage()
        {
            InitializeComponent();

            //Встановлюємо DataContext на нашу колекцію паролів
            this.DataContext = DataStore.Passwords;
        }
    }
}