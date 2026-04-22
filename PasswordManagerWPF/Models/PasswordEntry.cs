using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace PasswordManagerWPF.Models
{
    public class PasswordEntry : INotifyPropertyChanged
    {
        //Додал = string.Empty; щоб прибрати попередження CS8618
        private string _site = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;

        public string Site
        {
            get => _site;
            set { _site = value; OnPropertyChanged(); }
        }

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        //Додал знак питання (?) до PropertyChangedEventHandler, щоб прибрати CS8612
        public event PropertyChangedEventHandler? PropertyChanged;

        //string name = null на string? name = null
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}