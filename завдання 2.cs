using System;
using System.Collections.Generic;


public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    public Computer(string ipAddress, int power, string os)
    {
        IPAddress = ipAddress;
        Power = power;
        OperatingSystem = os;
    }
}


public interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void TransferData(Computer target, string data);
}


public class Server : Computer
{
    public int StorageCapacity { get; set; }

    public Server(string ipAddress, int power, string os, int storageCapacity)
        : base(ipAddress, power, os)
    {
        StorageCapacity = storageCapacity;
    }
}


public class Workstation : Computer
{
    public string UserName { get; set; }

    public Workstation(string ipAddress, int power, string os, string userName)
        : base(ipAddress, power, os)
    {
        UserName = userName;
    }
}

public class Router : Computer
{
    public List<Computer> ConnectedDevices { get; set; }

    public Router(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
        ConnectedDevices = new List<Computer>();
    }
}

public class Network
{
    private List<Computer> computers = new List<Computer>();

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void ConnectComputers(Computer computer1, Computer computer2)
    {
        if (computers.Contains(computer1) && computers.Contains(computer2))
        {
            if (computer1 is IConnectable && computer2 is IConnectable)
            {
                ((IConnectable)computer1).Connect(computer2);
                ((IConnectable)computer2).Connect(computer1);
            }
            else
            {
                Console.WriteLine("One or both computers cannot be connected.");
            }
        }
        else
        {
            Console.WriteLine("One or both computers do not exist in the network.");
        }
    }

    public void DisconnectComputers(Computer computer1, Computer computer2)
    {
        if (computers.Contains(computer1) && computers.Contains(computer2))
        {
            if (computer1 is IConnectable && computer2 is IConnectable)
            {
                ((IConnectable)computer1).Disconnect(computer2);
                ((IConnectable)computer2).Disconnect(computer1);
            }
            else
            {
                Console.WriteLine("One or both computers cannot be disconnected.");
            }
        }
        else
        {
            Console.WriteLine("One or both computers do not exist in the network.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Network network = new Network();

        Server server = new Server("192.168.1.1", 500, "Windows Server", 1000);
        Workstation workstation1 = new Workstation("192.168.1.2", 100, "Windows 11", "User1");
        Workstation workstation2 = new Workstation("192.168.1.3", 100, "Windows 11", "User2");
        Router router = new Router("192.168.1.4", 50, "RouterOS");

        network.AddComputer(server);
        network.AddComputer(workstation1);
        network.AddComputer(workstation2);
        network.AddComputer(router);

        network.ConnectComputers(workstation1, router);
        network.ConnectComputers(workstation2, router);

        // Симулюємо передачу даних
        if (workstation1 is IConnectable && workstation2 is IConnectable)
        {
            ((IConnectable)workstation1).TransferData(workstation2, "Hello, workstation2!");
        }
    }
}
