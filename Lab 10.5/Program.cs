using System;

// Абстрактний клас для команди
public abstract class Command
{
    // Поля даних залишаються
    public string Data { get; set; }

    public abstract void Execute();
}

// Атрибут для позначення поля, яке буде встановлено через ін'єкцію залежностей
[AttributeUsage(AttributeTargets.Field)]
public class InjectAttribute : Attribute
{
}

// Приклад конкретної команди з ін'єкцією залежностей
public class ConcreteCommand : Command
{
    // Приклад поля, яке буде встановлено через ін'єкцію залежностей
    [Inject]
    private SomeDependency dependency;

    public override void Execute()
    {
        // Використання dependency у виконанні команди
        Console.WriteLine("Executing command with dependency: " + dependency.GetData());
    }
}

// Приклад класу, який представляє залежність
public class SomeDependency
{
    public string GetData()
    {
        return "Data from dependency";
    }
}

// Клас для інтерпретатора команд
public class CommandInterpreter
{
    public void Interpret(Command command)
    {
        Console.WriteLine("Interpreting command...");

        // Тут ви могли б використовувати reflection або інші методи для встановлення залежностей
        // У цьому прикладі ми використовуємо простий приклад, де ми перевіряємо атрибут Inject
        foreach (var field in command.GetType().GetFields())
        {
            var injectAttribute = (InjectAttribute)Attribute.GetCustomAttribute(field, typeof(InjectAttribute));
            if (injectAttribute != null)
            {
                // Встановлення залежностей для полів, які мають атрибут Inject
                Console.WriteLine($"Injecting dependency into field: {field.Name}");
                field.SetValue(command, new SomeDependency());
            }
        }

        // Виклик методу Execute
        Console.WriteLine("Executing command...");
        command.Execute();
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання
        Console.WriteLine("Creating command...");
        CommandInterpreter interpreter = new CommandInterpreter();
        Command command = new ConcreteCommand();
        interpreter.Interpret(command);
    }
}
