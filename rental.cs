using System;
using System.Collections.Generic;

class RentalItem
{
    public string Name { get; set; }
    public int RatePerHour { get; set; }

    public RentalItem(string name, int ratePerHour)
    {
        Name = name;
        RatePerHour = ratePerHour;
    }

    public int CalculateCost(int hours)
    {
        return RatePerHour * hours;
    }
}

class RentalSystem
{
    private List<RentalItem> items;

    public RentalSystem()
    {
        items = new List<RentalItem>
        {
            new RentalItem("Sepeda", 5000),
            new RentalItem("Skuter", 10000),
            new RentalItem("Mobil", 50000)
        };
    }

    public void DisplayItems()
    {
        Console.WriteLine("Barang yang tersedia untuk disewa:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - Rp{items[i].RatePerHour} per jam");
        }
    }

    public void RentItem()
    {
        DisplayItems();

        Console.Write("Pilih barang yang ingin disewa (1/2/3): ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > items.Count)
        {
            Console.WriteLine("Pilihan tidak valid!");
            return;
        }

        Console.Write($"Berapa jam Anda ingin menyewa {items[choice - 1].Name}? ");
        int hours;
        if (!int.TryParse(Console.ReadLine(), out hours) || hours <= 0)
        {
            Console.WriteLine("Durasi tidak valid!");
            return;
        }

        int totalCost = items[choice - 1].CalculateCost(hours);
        Console.WriteLine($"Total biaya untuk menyewa {items[choice - 1].Name} selama {hours} jam adalah: Rp{totalCost}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        RentalSystem rentalSystem = new RentalSystem();

        while (true)
        {
            Console.WriteLine("\nSelamat datang di sistem rental!");
            Console.WriteLine("1. Sewa barang");
            Console.WriteLine("2. Keluar");
            Console.Write("Pilih menu: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                rentalSystem.RentItem();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Terima kasih telah menggunakan sistem rental!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }
}