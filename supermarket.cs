using System;
using System.Collections.Generic;

class Program
{
    // Daftar produk dan harga
    struct Produk
    {
        public string Nama;
        public int Harga;

        public Produk(string nama, int harga)
        {
            Nama = nama;
            Harga = harga;
        }
    }

    // Daftar produk yang tersedia
    static Produk[] produk = new Produk[]
    {
        new Produk("Apel", 10000),
        new Produk("Pisang", 8000),
        new Produk("Jeruk", 12000),
        new Produk("Mangga", 15000),
        new Produk("Semangka", 20000)
    };

    static int totalProduk = produk.Length;

    // Fungsi untuk menampilkan daftar produk
    static void TampilkanProduk()
    {
        Console.WriteLine("\nDaftar Produk Supermarket:");
        for (int i = 0; i < totalProduk; i++)
        {
            Console.WriteLine($"{produk[i].Nama}: Rp {produk[i].Harga}");
        }
    }

    // Fungsi untuk menambah barang ke keranjang
    static void TambahKeKeranjang(ref List<string> keranjang, ref List<int> jumlah, string produkNama, int produkJumlah)
    {
        int index = keranjang.IndexOf(produkNama);
        if (index >= 0)
        {
            jumlah[index] += produkJumlah;
        }
        else
        {
            keranjang.Add(produkNama);
            jumlah.Add(produkJumlah);
        }
    }

    // Fungsi untuk menghitung total belanjaan
    static int HitungTotal(List<string> keranjang, List<int> jumlah)
    {
        int total = 0;
        for (int i = 0; i < keranjang.Count; i++)
        {
            for (int j = 0; j < totalProduk; j++)
            {
                if (produk[j].Nama == keranjang[i])
                {
                    total += produk[j].Harga * jumlah[i];
                    break;
                }
            }
        }
        return total;
    }

    static void Main()
    {
        List<string> keranjang = new List<string>();
        List<int> jumlah = new List<int>();
        string pilihan;
        
        while (true)
        {
            TampilkanProduk();
            Console.Write("\nMasukkan nama produk yang ingin dibeli (atau ketik 'selesai' untuk keluar): ");
            pilihan = Console.ReadLine();

            if (pilihan.ToLower() == "selesai")
            {
                break;
            }

            bool ditemukan = false;
            for (int i = 0; i < totalProduk; i++)
            {
                if (produk[i].Nama.Equals(pilihan, StringComparison.OrdinalIgnoreCase))
                {
                    ditemukan = true;
                    Console.Write($"Berapa banyak {pilihan} yang ingin Anda beli? ");
                    int jumlahBarang = int.Parse(Console.ReadLine());
                    TambahKeKeranjang(ref keranjang, ref jumlah, produk[i].Nama, jumlahBarang);
                    break;
                }
            }

            if (!ditemukan)
            {
                Console.WriteLine("Produk tidak tersedia. Silakan pilih produk yang ada.");
            }
        }

        // Menampilkan keranjang belanja
        Console.WriteLine("\nKeranjang Belanja Anda:");
        int total = 0;
        for (int i = 0; i < keranjang.Count; i++)
        {
            for (int j = 0; j < totalProduk; j++)
            {
                if (produk[j].Nama == keranjang[i])
                {
                    int subtotal = produk[j].Harga * jumlah[i];
                    Console.WriteLine($"{keranjang[i]}: {jumlah[i]} x Rp {produk[j].Harga} = Rp {subtotal}");
                    total += subtotal;
                    break;
                }
            }
        }

        Console.WriteLine($"\nTotal Belanja: Rp {total}");
    }
}