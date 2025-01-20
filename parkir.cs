using System;
using System.Collections.Generic;

class Parkir
{
    private int kapasitas;
    private List<string> kendaraanParkir;

    public Parkir(int kapasitas)
    {
        this.kapasitas = kapasitas;
        kendaraanParkir = new List<string>();
    }

    public void MasukkanKendaraan(string kendaraan)
    {
        if (kendaraanParkir.Count < kapasitas)
        {
            kendaraanParkir.Add(kendaraan);
            Console.WriteLine($"{kendaraan} berhasil masuk ke area parkir.");
        }
        else
        {
            Console.WriteLine("Parkir sudah penuh!");
        }
    }

    public void KeluarkanKendaraan(string kendaraan)
    {
        if (kendaraanParkir.Contains(kendaraan))
        {
            kendaraanParkir.Remove(kendaraan);
            Console.WriteLine($"{kendaraan} telah keluar dari area parkir.");
        }
        else
        {
            Console.WriteLine($"{kendaraan} tidak ditemukan di parkir.");
        }
    }

    public void StatusParkir()
    {
        if (kendaraanParkir.Count > 0)
        {
            Console.WriteLine("Kendaraan yang terparkir:");
            foreach (var kendaraan in kendaraanParkir)
            {
                Console.WriteLine(kendaraan);
            }
        }
        else
        {
            Console.WriteLine("Area parkir kosong.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Masukkan kapasitas parkir: ");
        int kapasitasParkir = int.Parse(Console.ReadLine());

        Parkir parkir = new Parkir(kapasitasParkir);

        while (true)
        {
            Console.WriteLine("\nPilih menu:");
            Console.WriteLine("1. Masukkan kendaraan");
            Console.WriteLine("2. Keluarkan kendaraan");
            Console.WriteLine("3. Lihat status parkir");
            Console.WriteLine("4. Keluar");

            Console.Write("Pilihan Anda: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                Console.Write("Masukkan nama kendaraan yang ingin parkir: ");
                string kendaraan = Console.ReadLine();
                parkir.MasukkanKendaraan(kendaraan);
            }
            else if (pilihan == "2")
            {
                Console.Write("Masukkan nama kendaraan yang ingin keluar: ");
                string kendaraan = Console.ReadLine();
                parkir.KeluarkanKendaraan(kendaraan);
            }
            else if (pilihan == "3")
            {
                parkir.StatusParkir();
            }
            else if (pilihan == "4")
            {
                Console.WriteLine("Terima kasih telah menggunakan sistem parkir!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }
}