using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json; //Бібліотека для роботи з JSON
namespace PasswordManagerWPF.Models
{
    public static class DataStore
    {
        public static ObservableCollection<PasswordEntry> Passwords { get; set; } = new ObservableCollection<PasswordEntry>();

        //Назва файлу куди будемо все ховати
        private static readonly string filePath = "my_safe.json";

        //Метод для ЗБЕРЕЖЕННЯ даних у файл
        public static void SaveToFile()
        {
            //Перетворюємо наш список паролів на текст формату JSON
            string jsonString = JsonSerializer.Serialize(Passwords);

            //Записуємо цей текст у файл
            File.WriteAllText(filePath, jsonString);
        }

        //Метод для ЗАВАНТАЖЕННЯ даних з файлу
        public static void LoadFromFile()
        {
            //Якщо файл існує читаємо його
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                //Перетворюємо текст назад у список паролів
                var loadedData = JsonSerializer.Deserialize<ObservableCollection<PasswordEntry>>(jsonString);

                if (loadedData != null)
                {
                    Passwords = loadedData;
                }
            }
        }
    }
}