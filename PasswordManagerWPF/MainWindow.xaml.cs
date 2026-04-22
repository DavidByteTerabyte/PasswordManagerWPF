using System.Windows;
using System.Collections.ObjectModel;
using PasswordManagerWPF.Models;
namespace PasswordManagerWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<PasswordEntry> MyPasswords { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MyPasswords = new ObservableCollection<PasswordEntry>();

            //Тимчасовий тестовий запис
            MyPasswords.Add(new PasswordEntry { Site = "Google", Login = "test@gmail.com", Password = "123" });

            this.DataContext = this;

            //При запуску відкриваємо сторінку Логіну
            MainFrame.Navigate(new Views.LoginPage());
        }

        private void btnShowList_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Views.PasswordsListPage());
        private void btnAdd_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Views.AddPasswordPage());

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //При виході: Ховаємо меню і йдемо на сторінку Логіну
            LeftMenuPanel.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new Views.LoginPage());
        }

        //Цей метод ми викличемо зі сторінки логіну, коли пароль буде вірним
        public void UnlockSafe()
        {
            LeftMenuPanel.Visibility = Visibility.Visible;
            MainFrame.Navigate(new Views.PasswordsListPage());
        }
    }
}