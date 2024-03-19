using System.Text.Json;

//1) Створити клас з двома змінними. 
//Додати конструктор з вхідними параметрами. 
//Додати конструктор, який ініціалізує члени класу за замовчуванням. Додати деструктор, що виводить на екран повідомлення про видалення об’єкту.
//2)Створити у попередньому завданні два методи з використанням серіалізації та десеріалізації JSON. 
//Метод 1. Зберігає створений об’єкт класу з Завдання 1 у JSON файл 
//Метод 2. Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.


public class Class
{
   
    public int Number { get; set; }
    public string Text { get; set; }



    public Class(int number, string text)
    {
        
        Number = number;
        Text = text;

    }


    public Class() : this(0, "Просто текст")
    {
    }


    ~Class()
    {

        Console.WriteLine("Объект MyClass удаляется");

    }


    public static void SerializeToJson(Class obj, string filePath)
    {
       
        string jsonString = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
    
        File.WriteAllText(filePath, jsonString);
    }

 
    public static Class DeserializeFromJson(string filePath)
    {
      
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Class>(jsonString);

    }
}


class Program
{
  
    static void Main()
    {
      
        Class m1 = new Class(123, "Пример");
        Class.SerializeToJson(m1, @"C:\Users\bludj\source\repos\LABA-3\1.json");
        Class deserializedObject = Class.DeserializeFromJson("1.json");

        Console.WriteLine($"Number: {deserializedObject.Number}, Text: {deserializedObject.Text}");
    }
}
