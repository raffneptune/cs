using System;

class Program
{
    // Menampilkan menu pilihan bahan bakar
    static void DisplayMenu()
    {
        Console.WriteLine("Selamat datang di SPBU!");
        Console.WriteLine("Pilih jenis bahan bakar:");
        Console.WriteLine("1. Premium (Rp 10.000 per liter)");
        Console.WriteLine("2. Pertalite (Rp 12.000 per liter)");
        Console.WriteLine("3. Pertamax (Rp 15.000 per liter)");
    }

    // Menghitung total harga berdasarkan jenis bahan bakar dan jumlah liter
    static double CalculateTotalPrice(int fuelType, double liters)
    {
        double pricePerLiter = 0;

        if (fuelType == 1)
        {
            pricePerLiter = 10000;  // Harga Premium
        }
        else if (fuelType == 2)
        {
            pricePerLiter = 12000;  // Harga Pertalite
        }
        else if (fuelType == 3)
        {
            pricePerLiter = 15000;  // Harga Pertamax
        }

        return pricePerLiter * liters;
    }

    // Program utama
    static void Main()
    {
        int fuelType;
        double liters, totalPrice;

        // Menampilkan menu dan meminta input jenis bahan bakar
        DisplayMenu();
        Console.Write("Masukkan pilihan (1/2/3): ");
        if (!int.TryParse(Console.ReadLine(), out fuelType) || (fuelType < 1 || fuelType > 3))
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        // Meminta input jumlah liter
        Console.Write("Masukkan jumlah liter: ");
        if (!double.TryParse(Console.ReadLine(), out liters) || liters <= 0)
        {
            Console.WriteLine("Jumlah liter tidak valid.");
            return;
        }

        // Menghitung total harga
        totalPrice = CalculateTotalPrice(fuelType, liters);

        // Menampilkan struk pembayaran
        Console.WriteLine("\n--- STRUK PEMBAYARAN ---");
        if (fuelType == 1)
        {
            Console.WriteLine("Bahan Bakar: Premium");
        }
        else if (fuelType == 2)
        {
            Console.WriteLine("Bahan Bakar: Pertalite");
        }
        else if (fuelType == 3)
        {
            Console.WriteLine("Bahan Bakar: Pertamax");
        }
        Console.WriteLine($"Jumlah Liter: {liters} liter");
        Console.WriteLine($"Total Pembayaran: Rp {totalPrice:N0}");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Terima kasih telah menggunakan layanan kami!");
    }
}