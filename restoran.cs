using System;
using System.Collections.Generic;

class Menu
{
    public string Nama { get; set; }
    public int Harga { get; set; }

    public Menu(string nama, int harga)
    {
        Nama = nama;
        Harga = harga;
    }
}

class Restoran
{
    private List<Menu> menu;
    private List<Tuple<Menu, int>> pesanan;

    public Restoran()
    {
        menu = new List<Menu>
        {
            new Menu("Nasi Goreng", 25000),
            new Menu("Mie Goreng", 20000),
            new Menu("Sate Ayam", 30000),
            new Menu("Ayam Penyet", 35000),
            new Menu("Es Teh", 5000),
            new Menu("Es Jeruk", 7000)
        };
        pesanan = new List<Tuple<Menu, int>>();
    }

    public void TampilkanMenu()
    {
        Console.WriteLine("\nMenu Restoran:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].Nama} - Rp{menu[i].Harga}");
        }
    }

    public void TambahPesanan()
    {
        TampilkanMenu();
        Console.Write("\nPilih nomor menu untuk dipesan (0 untuk selesai): ");
        int pilihan = int.Parse(Console.ReadLine());

        if (pilihan == 0) return;

        if (pilihan > 0 && pilihan <= menu.Count)
        {
            Console.Write($"Berapa banyak {menu[pilihan - 1].Nama} yang ingin dipesan? ");
            int jumlah = int.Parse(Console.ReadLine());
            pesanan.Add(new Tuple<Menu, int>(menu[pilihan - 1], jumlah));
            Console.WriteLine($"{jumlah} {menu[pilihan - 1].Nama} ditambahkan ke pesanan.");
        }
        else
        {
            Console.WriteLine("Nomor menu tidak valid!");
        }
    }

    public int HitungTotal()
    {
        int total = 0;
        foreach (var p in pesanan)
        {
            total += p.Item1.Harga * p.Item2;
        }
        return total;
    }

    public void TampilkanPesanan()
    {
        if (pesanan.Count == 0)
        {
            Console.WriteLine("\nBelum ada pesanan.");
        }
        else
        {
            Console.WriteLine("\nPesanan Anda:");
            foreach (var p in pesanan)
            {
                Console.WriteLine($"{p.Item1.Nama} x {p.Item2} - Rp{p.Item1.Harga * p.Item2}");
            }
            Console.WriteLine($"Total Harga: Rp{HitungTotal()}");
        }
    }
}

class Program
{
    static void Main()
    {
        Restoran restoran = new Restoran();
        int pilihan;

        while (true)
        {
            Console.WriteLine("\n-- Menu Utama --");
            Console.WriteLine("1. Lihat Menu");
            Console.WriteLine("2. Tambah Pesanan");
            Console.WriteLine("3. Tampilkan Pesanan");
            Console.WriteLine("4. Hitung Total");
            Console.WriteLine("5. Keluar");

            Console.Write("Pilih opsi (1-5): ");
            pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    restoran.TampilkanMenu();
                    break;
                case 2:
                    restoran.TambahPesanan();
                    break;
                case 3:
                    restoran.TampilkanPesanan();
                    break;
                case 4:
                    Console.WriteLine($"Total Harga: Rp{restoran.HitungTotal()}");
                    break;
                case 5:
                    Console.WriteLine("Terima kasih telah berkunjung!");
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid!");
                    break;
            }
        }
    }
}