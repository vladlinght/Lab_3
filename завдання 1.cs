using System;
using System.Collections.Generic;


public class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public LivingOrganism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}


public interface IReproducible
{
    void Reproduce();
}


public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

public class Animal : LivingOrganism, IPredator, IReproducible
{
    public string Species { get; set; }

    public Animal(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Hunt(LivingOrganism prey)
    {
        
    }

    public void Reproduce()
    {
       
    }
}


public class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public Plant(double energy, int age, double size, string type)
        : base(energy, age, size)
    {
        Type = type;
    }

    public void Reproduce()
    {
        
    }
}


public class Microorganism : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public Microorganism(double energy, int age, double size, string type)
        : base(energy, age, size)
    {
        Type = type;
    }

    public void Reproduce()
    {
        
    }
}

public class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteraction()
    {
       
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal(100, 5, 1.5, "Lion");
        Animal deer = new Animal(80, 4, 1.2, "Deer");
        Plant grass = new Plant(50, 2, 0.1, "Grass");

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(deer);
        ecosystem.AddOrganism(grass);

        ecosystem.SimulateInteraction();
    }
}
