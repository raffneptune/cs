using System;
using System.Collections.Generic;

class Cafe
{
    // Menyimpan menu dan harga
    private Dictionary<string, int> menu;
    // Menyimpan pesanan dan jumlah item
    private Dictionary<string, int> pesanan;

    public Cafe()
    {
        // Inisialisasi menu kafe dengan harga
        menu = new Dictionary<string, int>
        {
            { "Kopi", 15000 },
            { "Teh", 10000 },
            { "Espresso", 20000 },
            { "Cappuccino", 25000 },
            { "Kue", 12000 }
        };
        
        pesanan = new Dictionary<string, int>();
    }

    // Menampilkan menu kafe
    public void TampilkanMenu()
    {
        Console.WriteLine("\n--- Menu Kafe ---");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: Rp {item.Value}");
        }
    }

    // Menambah pesanan
    public void TambahPesanan()
    {
        while (true)
        {
            TampilkanMenu();
            Console.Write("\nMasukkan nama item yang ingin dipesan (ketik 'selesai' untuk mengakhiri): ");
            string pesananItem = Console.ReadLine().Trim();

            if (pesananItem.ToLower() == "selesai")
            {
                break;
            }

            if (menu.ContainsKey(pesananItem))
            {
                Console.Write($"Berapa banyak {pesananItem} yang ingin dipesan? ");
                int jumlah;
                if (int.TryParse(Console.ReadLine(), out jumlah) && jumlah > 0)
                {
                    if (pesanan.ContainsKey(pesananItem))
                    {
                        pesanan[pesananItem] += jumlah;
                    }
                    else
                    {
                        pesanan[pesananItem] = jumlah;
                    }
                    Console.WriteLine($"{jumlah} {pesananItem} telah ditambahkan ke pesanan.");
                }
                else
                {
                    Console.WriteLine("Jumlah tidak valid. Silakan coba lagi.");
                }
            }
            else
            {
                Console.WriteLine("Item tidak ada dalam menu. Silakan coba lagi.");
            }
        }
    }

    // Menghitung total harga pesanan
    public int HitungTotal()
    {
        int total = 0;
        foreach (var item in pesanan)
        {
            total += menu[item.Key] * item.Value;
        }
        return total;
    }

    // Menampilkan pesanan dan total harga
    public void TampilkanPesanan()
    {
        if (pesanan.Count == 0)
        {
            Console.WriteLine("\nTidak ada pesanan.");
        }
        else
        {
            Console.WriteLine("\n--- Pesanan Anda ---");
            foreach (var item in pesanan)
            {
                Console.WriteLine($"{item.Key} x {item.Value} = Rp {menu[item.Key] * item.Value}");
            }
            Console.WriteLine($"\nTotal yang harus dibayar: Rp {HitungTotal()}");
        }
    }
}

class Program
{
    static void Main()
    {
        Cafe cafe = new Cafe();
        int pilihan;

        while (true)
        {
            Console.WriteLine("\n--- Selamat Datang di Kafe! ---");
            Console.WriteLine("1. Lihat Menu");
            Console.WriteLine("2. Tambah Pesanan");
            Console.WriteLine("3. Lihat Pesanan dan Total");
            Console.WriteLine("4. Keluar");

            Console.Write("Pilih menu (1-4): ");
            if (int.TryParse(Console.ReadLine(), out pilihan))
            {
                switch (pilihan)
                {
                    case 1:
                        cafe.TampilkanMenu();
                        break;
                    case 2:
                        cafe.TambahPesanan();
                        break;
                    case 3:
                        cafe.TampilkanPesanan();
                        break;
                    case 4:
                        Console.WriteLine("Terima kasih telah mengunjungi kafe kami. Sampai jumpa!");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }
        }
    }
}