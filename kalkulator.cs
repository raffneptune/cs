using System;

class Program
{
    // Fungsi untuk penjumlahan
    static double Tambah(double x, double y)
    {
        return x + y;
    }

    // Fungsi untuk pengurangan
    static double Kurang(double x, double y)
    {
        return x - y;
    }

    // Fungsi untuk perkalian
    static double Kali(double x, double y)
    {
        return x * y;
    }

    // Fungsi untuk pembagian
    static double Bagi(double x, double y)
    {
        if (y != 0)
        {
            return x / y;
        }
        else
        {
            Console.WriteLine("Tidak bisa membagi dengan nol");
            return 0;  // Mengembalikan nilai 0 jika pembagian dengan nol
        }
    }

    static void Main()
    {
        int pilihan;
        double num1, num2;

        // Menampilkan menu operasi
        Console.WriteLine("Pilih operasi:");
        Console.WriteLine("1. Tambah");
        Console.WriteLine("2. Kurang");
        Console.WriteLine("3. Kali");
        Console.WriteLine("4. Bagi");

        // Meminta input pilihan operasi
        Console.Write("Masukkan pilihan (1/2/3/4): ");
        pilihan = int.Parse(Console.ReadLine());

        // Meminta input angka
        Console.Write("Masukkan angka pertama: ");
        num1 = double.Parse(Console.ReadLine());
        Console.Write("Masukkan angka kedua: ");
        num2 = double.Parse(Console.ReadLine());

        // Melakukan operasi sesuai dengan pilihan pengguna
        switch (pilihan)
        {
            case 1:
                Console.WriteLine("{0} + {1} = {2:F2}", num1, num2, Tambah(num1, num2));
                break;
            case 2:
                Console.WriteLine("{0} - {1} = {2:F2}", num1, num2, Kurang(num1, num2));
                break;
            case 3:
                Console.WriteLine("{0} * {1} = {2:F2}", num1, num2, Kali(num1, num2));
                break;
            case 4:
                double hasilBagi = Bagi(num1, num2);
                if (num2 != 0)  // Mengecek apakah pembagian berhasil
                {
                    Console.WriteLine("{0} / {1} = {2:F2}", num1, num2, hasilBagi);
                }
                break;
            default:
                Console.WriteLine("Pilihan tidak valid!");
                break;
        }
    }
}