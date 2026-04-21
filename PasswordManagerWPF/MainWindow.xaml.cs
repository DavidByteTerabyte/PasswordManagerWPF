using System.Windows;
using System.Windows.Media;
namespace PasswordManagerWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Замість сторінки логіну поки що просто показуємо вітальне повідомлення у Frame
            MainFrame.Content = new System.Windows.Controls.TextBlock
            {
                Text = "Ласкаво просимо до Сейфу!\nОберіть дію в меню ліворуч.",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.DarkGray),
                TextAlignment = TextAlignment.Center
            };
        }

        //Обробник для кнопки "Мої паролі"
        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Тут буде відкриватися список ваших паролів.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Обробник для кнопки "Додати новий"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Тут буде відкриватися форма для додавання нового сайту та пароля.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Обробник для кнопки "Вийти"
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете закрити сейф?", "Вихід", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}