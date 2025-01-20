using System;
using System.Collections.Generic;

class Vehicle
{
    public string Model { get; private set; }
    public int Price { get; private set; }
    public int Stock { get; private set; }

    public Vehicle(string model, int price, int stock)
    {
        Model = model;
        Price = price;
        Stock = stock;
    }

    // Menampilkan informasi kendaraan
    public void DisplayInfo()
    {
        Console.WriteLine($"Model: {Model}, Harga: Rp{Price}, Stok: {Stock}");
    }

    // Mengupdate stok setelah pembelian
    public void UpdateStock(int quantity)
    {
        Stock -= quantity;
        if (Stock < 0)
        {
            Stock = 0;
        }
    }

    // Memeriksa ketersediaan stok
    public bool IsAvailable(int quantity)
    {
        return Stock >= quantity;
    }
}

class VehicleDealer
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    // Menambahkan kendaraan ke diler
    public void AddVehicle(string model, int price, int stock)
    {
        Vehicle vehicle = new Vehicle(model, price, stock);
        vehicles.Add(vehicle);
    }

    // Menampilkan semua kendaraan yang tersedia
    public void DisplayVehicles()
    {
        if (vehicles.Count == 0)
        {
            Console.WriteLine("Tidak ada kendaraan di diler.");
            return;
        }

        Console.WriteLine("\nKendaraan yang Tersedia di Diler:");
        for (int i = 0; i < vehicles.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            vehicles[i].DisplayInfo();
        }
    }

    // Pembelian kendaraan
    public void PurchaseVehicle()
    {
        DisplayVehicles();
        if (vehicles.Count == 0) return;

        try
        {
            Console.Write("\nPilih kendaraan (masukkan nomor): ");
            int choice = int.Parse(Console.ReadLine());
            Console.Write("Berapa banyak yang ingin dibeli? ");
            int quantity = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > vehicles.Count)
            {
                Console.WriteLine("Pilihan tidak valid.");
                return;
            }

            Vehicle selectedVehicle = vehicles[choice - 1];
            if (selectedVehicle.IsAvailable(quantity))
            {
                int totalPrice = selectedVehicle.Price * quantity;
                Console.WriteLine($"\nPembelian Sukses! Total Harga: Rp{totalPrice}");
                selectedVehicle.UpdateStock(quantity);
            }
            else
            {
                Console.WriteLine("\nStok tidak cukup.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Input tidak valid.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        VehicleDealer dealer = new VehicleDealer();

        // Menambahkan beberapa kendaraan ke diler
        dealer.AddVehicle("Mobil Sedan", 300000000, 10);
        dealer.AddVehicle("Motor Sport", 100000000, 5);
        dealer.AddVehicle("Mobil SUV", 500000000, 3);

        while (true)
        {
            Console.WriteLine("\n--- Menu Diler Kendaraan ---");
            Console.WriteLine("1. Lihat kendaraan yang tersedia");
            Console.WriteLine("2. Pembelian kendaraan");
            Console.WriteLine("3. Keluar");

            Console.Write("\nPilih menu: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        dealer.DisplayVehicles();
                        break;
                    case 2:
                        dealer.PurchaseVehicle();
                        break;
                    case 3:
                        Console.WriteLine("Terima kasih telah mengunjungi diler kami!");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Masukkan pilihan yang valid.");
            }
        }
    }
}