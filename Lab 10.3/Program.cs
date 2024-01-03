using System;
using System.Collections.Generic;
using System.Linq;

// Інтерфейс для всіх одиниць
public interface IUnit
{
    void DisplayInfo();
}

// Реалізації для різних типів одиниць
public class Archer : IUnit
{
    public void DisplayInfo()
    {
        Console.WriteLine("Archer created! Health: 30, Attack: 5");
    }
}

public class Swordsman : IUnit
{
    public void DisplayInfo()
    {
        Console.WriteLine("Swordsman created! Health: 40, Attack: 8");
    }
}

public class Pikeman : IUnit
{
    public void DisplayInfo()
    {
        Console.WriteLine("Pikeman created! Health: 35, Attack: 7");
    }
}

public class Horseman : IUnit
{
    public void DisplayInfo()
    {
        Console.WriteLine("Horseman created! Health: 50, Attack: 10");
    }
}

public class Guide : IUnit
{
    public void DisplayInfo()
    {
        Console.WriteLine("Guide created! Health: 20, Attack: 20");
    }
}

// Фабрика для створення одиниць
public class UnitFactory
{
    public static IUnit CreateUnit(string unitType)
    {
        Type type = Type.GetType(unitType);
        if (type == null || !typeof(IUnit).IsAssignableFrom(type))
        {
            throw new ArgumentException("Invalid unit type");
        }

        return (IUnit)Activator.CreateInstance(type);
    }
}

// Сховище для одиниць
public class Barracks
{
    private List<IUnit> storage = new List<IUnit>();

    // Додає нову одиницю до сховища
    public void AddUnit(string unitType)
    {
        IUnit unit = UnitFactory.CreateUnit(unitType);
        storage.Add(unit);
        Console.WriteLine($"{unitType} added!");
    }

    // Виводить статистику про одиниці у сховищі
    public void DisplayReport()
    {
        // Сортує одиниці за типом
        storage.Sort((a, b) => string.Compare(a.GetType().Name, b.GetType().Name));

        // Групує та виводить кількість кожного типу одиниць
        foreach (var group in storage.GroupBy(u => u.GetType().Name))
        {
            Console.WriteLine($"{group.Key} -> {group.Count()} units");
        }
    }
}

class Program
{
    static void Main()
    {
        // Створюємо сховище
        Barracks barracks = new Barracks();

        // Додаємо декілька одиниць
        barracks.AddUnit("Archer");
        barracks.AddUnit("Horseman");
        barracks.AddUnit("Guide");
        barracks.AddUnit("Archer");

        // Виводимо статистику
        barracks.DisplayReport();
    }
}
