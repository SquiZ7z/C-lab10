using System;

class TrafficLight
{
    enum Signal { Red, Green, Yellow }

    static void Main()
    {
        // Введення початкових сигналів світлофорів
        Console.WriteLine("Введіть початкові сигнали світлофорів (Червоний Зелений Жовтий):");
        string[] initialSignals = Console.ReadLine().Split();

        // Введення кількості оновлень для кожного світлофора
        Console.WriteLine("Введіть кількість оновлень для кожного світлофора:");
        int n = int.Parse(Console.ReadLine());

        foreach (string signalStr in initialSignals)
        {
            Signal currentSignal = (Signal)Enum.Parse(typeof(Signal), signalStr, true);

            Console.WriteLine($"Початковий сигнал світлофора: {currentSignal}");

            for (int i = 0; i < n; i++)
            {
                // Оновлення сигналу світлофора
                currentSignal = GetNextSignal(currentSignal);
                Console.WriteLine($"Оновлений сигнал світлофора: {currentSignal}");
            }

            Console.WriteLine(); // Пустий рядок для розділення виводу для кожного світлофора
        }
    }

    static Signal GetNextSignal(Signal currentSignal)
    {
        // Логіка для визначення наступного сигналу
        switch (currentSignal)
        {
            case Signal.Red:
                return Signal.Green;
            case Signal.Green:
                return Signal.Yellow;
            case Signal.Yellow:
                return Signal.Red;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
