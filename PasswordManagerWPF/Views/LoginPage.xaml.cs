using System.Windows;
using System.Windows.Controls;
namespace PasswordManagerWPF.Views
{
    public partial class LoginPage : Page
    {
        //ТУТ ВСТАНОВЛЮЄТЬСЯ МАЙСТЕР-ПАРОЛЬ ДЛЯ ПРОГРАМИ
        private const string MASTER_PASSWORD = "123";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (pbMaster.Password == MASTER_PASSWORD)
            {
                pbMaster.Password = "";

                //Завантажуємо паролі з файлу перед відкриттям ===
                Models.DataStore.LoadFromFile();

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.UnlockSafe();
            }
            else
            {
                //Пароль невірний
                MessageBox.Show("Невірний Майстер-пароль! Доступ заборонено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                pbMaster.Password = "";
            }
        }
    }
}