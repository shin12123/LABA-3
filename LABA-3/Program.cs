using System.Text.Json;

namespace LABA_3
//1) Створити клас з двома змінними. 
//Додати конструктор з вхідними параметрами. 
//Додати конструктор, який ініціалізує члени класу за замовчуванням. Додати деструктор, що виводить на екран повідомлення про видалення об’єкту.
//2)Створити у попередньому завданні два методи з використанням серіалізації та десеріалізації JSON. 
//Метод 1. Зберігає створений об’єкт класу з Завдання 1 у JSON файл 
//Метод 2. Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.

{
    public class cl
    {
        // Класс с 2 переменными
        public int Number { get; set; }
        public string Text { get; set; }


        //Додати конструктор з вхідними параметрами
        public cl(int number, string text)
        {

            Number = number;
            Text = text;

        }

        //Додати конструктор, який ініціалізує члени класу за замовчуванням
        public cl() : this(0, "Просто текст")
        {
        }

        //Додати деструктор, що виводить на екран повідомлення про видалення об’єкту.
        ~cl()
        {

            Console.WriteLine("Объект Class удаляется");

        }

        // Сериализация в json
        public static void SerializeToJson(cl obj, string filePath)
        {

            string jsonString = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonString);
        }

        // Десериализация файла и возвращение в объект Class
        public static cl DeserializeFromJson(string filePath)
        {

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<cl>(jsonString);

        }
    }


    class Program
    {

        static void Main()
        {

            cl o1 = new cl(123, "Пример");
            cl.SerializeToJson(o1, @"C:\Users\bludj\source\repos\LABA-3\1.json");
            cl deserializedObject = cl.DeserializeFromJson("1.json");

            Console.WriteLine($"Number: {deserializedObject.Number}, Text: {deserializedObject.Text}");
        }
    }
}
