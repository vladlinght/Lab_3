using System;
using System.Threading;


public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public double TrafficLevel { get; set; }

    public Road(double length, double width, int numberOfLanes)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        TrafficLevel = 0.0;
    }
}


public enum VehicleType
{
    Car,
    Truck,
    Bus,
    Motorcycle
}


public class Vehicle : IDriveable
{
    public double Speed { get; set; }
    public double Size { get; set; }
    public VehicleType Type { get; set; }

    public Vehicle(double speed, double size, VehicleType type)
    {
        Speed = speed;
        Size = size;
        Type = type;
    }

    public void Move()
    {
       
        Console.WriteLine($"The {Type} is moving at a speed of {Speed} km/h.");
    }

    public void Stop()
    {
       
        Console.WriteLine($"The {Type} has stopped.");
    }
}


public interface IDriveable
{
    void Move();
    void Stop();
}


public class TrafficSimulation
{
    public void SimulateTraffic(Road road, Vehicle vehicle)
    {
        Console.WriteLine($"Simulating traffic on a road of length {road.Length} km with {road.NumberOfLanes} lanes.");
        
        // Імітація руху транспортних засобів
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Traffic level: {road.TrafficLevel}%");
            vehicle.Move();
            Thread.Sleep(1000); // Затримка для імітації руху
            road.TrafficLevel += 20;
            if (road.TrafficLevel > 100)
            {
                road.TrafficLevel = 100;
                Console.WriteLine("Traffic congestion! Vehicle is stuck.");
                vehicle.Stop();
                break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Road cityRoad = new Road(10.0, 4.0, 2);
        Vehicle car = new Vehicle(60, 2.0, VehicleType.Car);

        TrafficSimulation trafficSimulator = new TrafficSimulation();
        trafficSimulator.SimulateTraffic(cityRoad, car);
    }
}
