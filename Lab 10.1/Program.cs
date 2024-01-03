using System;
using System.Reflection;

class RichSoilLand
{
    private int privateField = 10;
    protected string protectedField = "Protected Field";
    public double publicField = 3.14;

    // Інші поля та методи класу RichSoilLand

    // Метод для друку полів з вказаним модифікатором доступу
    public void PrintFields(string accessModifier)
    {
        // Отримуємо всі поля класу RichSoilLand
        FieldInfo[] fields = typeof(RichSoilLand).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        // Проходимося по кожному полі
        foreach (FieldInfo field in fields)
        {
            string modifier = "";

            // Визначаємо модифікатор доступу для поточного поля
            if (field.IsPrivate)
            {
                modifier = "private";
            }
            else if (field.IsFamily || field.IsFamilyOrAssembly)
            {
                modifier = "protected";
            }
            else if (field.IsPublic)
            {
                modifier = "public";
            }

            // Перевіряємо, чи поточний модифікатор доступу відповідає введеному користувачем
            if (accessModifier.ToLower() == "all" || modifier.ToLower() == accessModifier.ToLower())
            {
                // Друкуємо інформацію про поле у вказаному форматі
                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        RichSoilLand land = new RichSoilLand();

        Console.WriteLine("Введіть команду (private/protected/public/all/жнива):");

        while (true)
        {
            // Отримуємо введену команду від користувача
            string input = Console.ReadLine();

            // Перевіряємо, чи користувач ввів "жнива" для завершення програми
            if (input.ToLower() == "жнива")
            {
                break;
            }

            // Викликаємо метод для друку полів з вказаним модифікатором доступу
            land.PrintFields(input);

            // Повторюємо запит на команду
            Console.WriteLine("Введіть команду (private/protected/public/all/жнива):");
        }
    }
}
