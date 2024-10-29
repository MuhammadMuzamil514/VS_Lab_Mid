
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        StudentClub studentClub = new StudentClub();

        while (true)
        {
            Console.WriteLine("-------Student Club Management System-------  ");
            Console.WriteLine("1.     Register a New Society");
            Console.WriteLine("2.     Allocate Funding to Societies");
            Console.WriteLine("3.     Register an Event for a Society");
            Console.WriteLine("4.     Display Society Funding Information");
            Console.WriteLine("5.     Display Events for a Society");
            Console.WriteLine("6.     Exit");
            Console.Write("Select An Option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    studentClub.RegisterSociety();
                    break;
                case 2:
                    studentClub.DispenseFunds();
                    break;
                case 3:
                    studentClub.AddEventToSociety();
                    break;
                case 4:
                    studentClub.DisplaySocietyFundingInfo();
                    break;
                case 5:
                    studentClub.DisplayEvents();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine(" please Enter valid choice.");
                    break;
            }
        }
    }
}

class StudentClub
{
    public double Budget { get; set; } = 2000;
    public List<Society> Societies { get; set; } = new List<Society>();

    public void RegisterSociety()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Console.Write("Enter contact person: ");
        string contact = Console.ReadLine();
        Console.Write("Is this a funded society? ");
        string isFunded = Console.ReadLine().ToLower();

        if (isFunded == "yes")
        {
            Console.Write("Enter funding amount: ");
            double funding = double.Parse(Console.ReadLine());
            Societies.Add(new FundedSociety(name, contact, funding));
        }
        else
        {
            Societies.Add(new NonFundedSociety(name, contact));
        }
        Console.WriteLine(" Registered successfully.");
    }

    public void DispenseFunds()
    {
        foreach (var society in Societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Fund Allocated to {fundedSociety.Name}: ${fundedSociety.FundingAmount}");
            }
        }
    }

    public void AddEventToSociety()
    {
        Console.Write("Enter society Name: ");
        string name = Console.ReadLine();
        Society society = Societies.Find(s => s.Name == name);

        if (society != null)
        {
            Console.Write("Enter Event name: ");
            string eventName = Console.ReadLine();
            society.AddActivity(eventName);
            Console.WriteLine("Event Successfully add.");
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }

    public void DisplaySocietyFundingInfo()
    {
        foreach (var society in Societies)
        {
            Console.WriteLine($"Society: {society.Name}, Contact: {society.Contact}");
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Funding: ${fundedSociety.FundingAmount}");
            }
            else
            {
                Console.WriteLine("No Funding.");
            }
            Console.WriteLine();
        }
    }

    public void DisplayEvents()
    {
        Console.Write("Enter Society Name: ");
        string name = Console.ReadLine();
        Society society = Societies.Find(s => s.Name == name);

        if (society != null)
        {
            society.ListEvents();
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }
}

class ClubRole
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string ContactInfo { get; set; }
}

class Society
{
    public string Name { get; set; }
    public string Contact { get; set; }
    public List<string> Activities { get; set; } = new List<string>();

    public Society(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public void AddActivity(string activity)
    {
        Activities.Add(activity);
    }

    public void ListEvents()
    {
        Console.WriteLine($"Events for {Name}:");
        foreach (var activity in Activities)
        {
            Console.WriteLine($"- {activity}");
        }
        Console.WriteLine();
    }
}

class FundedSociety : Society
{
    public double FundingAmount { get; set; }

    public FundedSociety(string name, string contact, double fundingAmount)
        : base(name, contact)
    {
        FundingAmount = fundingAmount;
    }
}

class NonFundedSociety : Society
{
    public NonFundedSociety(string name, string contact)
        : base(name, contact)
    {
    }
}
















