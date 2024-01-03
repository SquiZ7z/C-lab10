using System;

// Command Interface
public interface IExecutable
{
    string Execute();
}

// Command Base Class
public abstract class Command : IExecutable
{
    private string[] data;
    private IRepository repository;
    private IUnitFactory unitFactory;

    protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
    {
        this.Data = data;
        this.Repository = repository;
        this.UnitFactory = unitFactory;
    }

    protected string[] Data
    {
        get { return this.data; }
        private set { this.data = value; }
    }

    protected IRepository Repository
    {
        get { return this.repository; }
        private set { this.repository = value; }
    }

    protected IUnitFactory UnitFactory
    {
        get { return this.unitFactory; }
        private set { this.unitFactory = value; }
    }

    public abstract string Execute();
}

// Command Implementation for "retire" command
public class RetireCommand : Command
{
    public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[1];

        if (this.Repository.ContainsUnit(unitType))
        {
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} вилучено!";
        }
        else
        {
            return "Немає таких одиниць у сховищі";
        }
    }
}

// UnitRepository Interface
public interface IRepository
{
    bool ContainsUnit(string unitType);
    void RemoveUnit(string unitType);
}

// UnitRepository Implementation
public class UnitRepository : IRepository
{
    // Implement IRepository methods

    public bool ContainsUnit(string unitType)
    {
        // Implement unit existence check
        return false;
    }

    public void RemoveUnit(string unitType)
    {
        // Implement unit removal
    }
}

// IUnitFactory Interface
public interface IUnitFactory
{
    // Define factory methods if needed
}

// Example usage in Engine class
public class Engine
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        // Example usage of the "retire" command
        string[] commandArgs = { "retire", "Archer" };
        Command retireCommand = new RetireCommand(commandArgs, new UnitRepository(), new UnitFactory());
        string result = retireCommand.Execute();
        Console.WriteLine(result);
    }
}

// ICommandInterpreter Interface
public interface ICommandInterpreter
{
    IExecutable InterpretCommand(string[] commandArgs);
}

// Example ICommandInterpreter Implementation
public class CommandInterpreter : ICommandInterpreter
{
    public IExecutable InterpretCommand(string[] commandArgs)
    {
        // Logic to interpret different commands and return the corresponding Command object
        // Example: if (commandArgs[0] == "retire") return new RetireCommand(commandArgs, repository, unitFactory);
        return null;
    }
}

// IUnitFactory Implementation (Assuming IUnitFactory)
public class UnitFactory : IUnitFactory
{
    // Define factory methods if needed
}

class Program
{
    static void Main()
    {
        // Create instances and run the engine
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        Engine engine = new Engine(commandInterpreter);
        engine.Run();
    }
}
