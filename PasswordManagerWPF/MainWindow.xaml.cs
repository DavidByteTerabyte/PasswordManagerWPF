using System;
using System.Windows;
namespace PasswordManagerWPF
{
    /// <summary>
    /// Логіка взаємодії для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Відкриваємо сторінку логіну при запуску програми
            MainFrame.Navigate(new Views.LoginPage());
        }

        //Обробник для кнопки "Мої паролі"
        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.PasswordsListPage());
        }

        //Обробник для кнопки "Додати новий"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.AddPasswordPage());
        }

        //Обробник для кнопки "Вийти"
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Повернення на екран блокування (Логіну)
            MainFrame.Navigate(new Views.LoginPage());
        }
    }
}