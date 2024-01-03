using System;
using System.Collections.Generic;
using System.Linq;

class Weapon
{
    public string Name { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int Slots { get; set; }
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int VitalityBonus { get; set; }

    public Weapon(string name, int minDamage, int maxDamage, int slots)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Slots = slots;
    }

    public void AddGem(Gem gem, int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < Slots)
        {
            StrengthBonus += gem.StrengthBonus;
            AgilityBonus += gem.AgilityBonus;
            VitalityBonus += gem.VitalityBonus;
        }
    }

    public void RemoveGem(int slotIndex)
    {
        // Implement gem removal logic if needed
    }

    public override string ToString()
    {
        return $"{Name}: {MinDamage}-{MaxDamage} damage, +{StrengthBonus} strength, +{AgilityBonus} agility, +{VitalityBonus} vitality";
    }
}

class Gem
{
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int VitalityBonus { get; set; }

    public Gem(int strengthBonus, int agilityBonus, int vitalityBonus)
    {
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        VitalityBonus = vitalityBonus;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] command = input.Split(';');
            string action = command[0];

            switch (action)
            {
                case "Create":
                    CreateWeapon(command, weapons);
                    break;
                case "Add":
                    AddGem(command, weapons);
                    break;
                case "Remove":
                    RemoveGem(command, weapons);
                    break;
                case "Print":
                    PrintWeapon(command, weapons);
                    break;
            }
        }
    }

    static void CreateWeapon(string[] command, Dictionary<string, Weapon> weapons)
    {
        string weaponType = command[1];
        string weaponName = command[2];

        Weapon weapon;
        switch (weaponType)
        {
            case "Axe":
                weapon = new Weapon(weaponName, 5, 10, 4);
                break;
            case "Sword":
                weapon = new Weapon(weaponName, 4, 6, 3);
                break;
            case "Knife":
                weapon = new Weapon(weaponName, 3, 4, 2);
                break;
            default:
                throw new ArgumentException("Invalid weapon type");
        }

        weapons.Add(weaponName, weapon);
    }

    static void AddGem(string[] command, Dictionary<string, Weapon> weapons)
    {
        string weaponName = command[1];
        int slotIndex = int.Parse(command[2]);
        string gemType = command[3];

        Gem gem;
        switch (gemType)
        {
            case "Ruby":
                gem = new Gem(7, 2, 5);
                break;
            case "Emerald":
                gem = new Gem(1, 4, 9);
                break;
            case "Amethyst":
                gem = new Gem(2, 8, 4);
                break;
            default:
                throw new ArgumentException("Invalid gem type");
        }

        if (weapons.ContainsKey(weaponName))
        {
            weapons[weaponName].AddGem(gem, slotIndex);
        }
    }

    static void RemoveGem(string[] command, Dictionary<string, Weapon> weapons)
    {
        // Implement gem removal logic if needed
    }

    static void PrintWeapon(string[] command, Dictionary<string, Weapon> weapons)
    {
        string weaponName = command[1];
        if (weapons.ContainsKey(weaponName))
        {
            Console.WriteLine(weapons[weaponName]);
        }
    }
}
