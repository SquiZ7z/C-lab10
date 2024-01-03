using System;

class BlackBoxInt
{
    private int innerValue;

    public BlackBoxInt()
    {
        innerValue = 0;
    }

    public void Add(int value)
    {
        innerValue += value;
    }

    public void Subtract(int value)
    {
        innerValue -= value;
    }

    public void Multiply(int value)
    {
        innerValue *= value;
    }

    public void Divide(int value)
    {
        if (value != 0)
        {
            innerValue /= value;
        }
        // Якщо value дорівнює 0, можна взяти велику узагальнену обробку або залишити без змін.
        // У цьому випадку ми просто залишаємо innerValue без змін.
    }

    public void LeftShift(int value)
    {
        innerValue <<= value;
    }

    public void RightShift(int value)
    {
        innerValue >>= value;
    }

    public int GetInnerValue()
    {
        return innerValue;
    }
}

class Program
{
    static void Main()
    {
        BlackBoxInt blackBox = new BlackBoxInt();

        Console.WriteLine("Введіть команди у форматі <назва методу>_<значення>. Наприклад: Add_5");
        Console.WriteLine("Для завершення введіть 'END'");

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split('_');
            string methodName = parts[0];
            int value = int.Parse(parts[1]);

            switch (methodName)
            {
                case "Add":
                    blackBox.Add(value);
                    break;
                case "Subtract":
                    blackBox.Subtract(value);
                    break;
                case "Multiply":
                    blackBox.Multiply(value);
                    break;
                case "Divide":
                    blackBox.Divide(value);
                    break;
                case "LeftShift":
                    blackBox.LeftShift(value);
                    break;
                case "RightShift":
                    blackBox.RightShift(value);
                    break;
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    continue; // Перейти до наступної ітерації циклу, не виводячи значення.
            }

            Console.WriteLine($"Поточне значення innerValue: {blackBox.GetInnerValue()}");
        }

        Console.WriteLine("Програма завершена.");
    }
}
