using System;
using System.Collections.Generic;

class Buku
{
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }

    public Buku(string judul, string penulis, int tahunTerbit)
    {
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
    }

    public override string ToString()
    {
        return $"Judul: {Judul}, Penulis: {Penulis}, Tahun Terbit: {TahunTerbit}";
    }
}

class Perpustakaan
{
    private List<Buku> daftarBuku = new List<Buku>();

    public void TambahBuku(Buku buku)
    {
        daftarBuku.Add(buku);
        Console.WriteLine($"Buku '{buku.Judul}' berhasil ditambahkan.");
    }

    public void HapusBuku(string judul)
    {
        Buku bukuUntukDihapus = daftarBuku.Find(buku => buku.Judul.Equals(judul, StringComparison.OrdinalIgnoreCase));

        if (bukuUntukDihapus != null)
        {
            daftarBuku.Remove(bukuUntukDihapus);
            Console.WriteLine($"Buku '{judul}' berhasil dihapus.");
        }
        else
        {
            Console.WriteLine($"Buku '{judul}' tidak ditemukan.");
        }
    }

    public void TampilkanBuku()
    {
        if (daftarBuku.Count == 0)
        {
            Console.WriteLine("Tidak ada buku di perpustakaan.");
        }
        else
        {
            Console.WriteLine("Daftar Buku Perpustakaan:");
            foreach (Buku buku in daftarBuku)
            {
                Console.WriteLine(buku);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        while (true)
        {
            Console.WriteLine("\nMenu Perpustakaan:");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Hapus Buku");
            Console.WriteLine("3. Tampilkan Daftar Buku");
            Console.WriteLine("4. Keluar");

            Console.Write("Pilih menu (1/2/3/4): ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("Masukkan judul buku: ");
                    string judulTambah = Console.ReadLine();

                    Console.Write("Masukkan penulis buku: ");
                    string penulisTambah = Console.ReadLine();

                    Console.Write("Masukkan tahun terbit buku: ");
                    int tahunTerbitTambah = int.Parse(Console.ReadLine());

                    Buku bukuBaru = new Buku(judulTambah, penulisTambah, tahunTerbitTambah);
                    perpustakaan.TambahBuku(bukuBaru);
                    break;

                case "2":
                    Console.Write("Masukkan judul buku yang akan dihapus: ");
                    string judulHapus = Console.ReadLine();
                    perpustakaan.HapusBuku(judulHapus);
                    break;

                case "3":
                    perpustakaan.TampilkanBuku();
                    break;

                case "4":
                    Console.WriteLine("Terima kasih! Keluar dari program.");
                    return;

                default:
                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                    break;
            }
        }
    }
}