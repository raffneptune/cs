using System;
using System.Collections.Generic;

class Kendaraan
{
    public string Nama { get; set; }
    public string Golongan { get; set; }

    public Kendaraan(string nama, string golongan)
    {
        Nama = nama;
        Golongan = golongan;
    }
}

class GerbangTol
{
    private List<Kendaraan> antrian;

    public GerbangTol()
    {
        antrian = new List<Kendaraan>();
    }

    // Menambah kendaraan ke antrian
    public void TambahAntrian(string nama, string golongan)
    {
        antrian.Add(new Kendaraan(nama, golongan));
        Console.WriteLine($"{nama} ditambahkan ke antrian.");
    }

    // Memproses kendaraan pertama dalam antrian
    public void ProsesKendaraan()
    {
        if (antrian.Count > 0)
        {
            Console.WriteLine($"{antrian[0].Nama} sedang diproses.");
            antrian.RemoveAt(0); // Hapus kendaraan pertama
        }
        else
        {
            Console.WriteLine("Antrian kosong, tidak ada kendaraan yang diproses.");
        }
    }

    // Menampilkan antrian kendaraan
    public void TampilkanAntrian()
    {
        if (antrian.Count > 0)
        {
            Console.WriteLine("Antrian kendaraan saat ini:");
            foreach (var kendaraan in antrian)
            {
                Console.WriteLine($"{kendaraan.Nama} - {kendaraan.Golongan}");
            }
        }
        else
        {
            Console.WriteLine("Antrian kosong.");
        }
    }
}

class SistemTol
{
    public int TarifGolongan1 { get; set; }
    public int TarifGolongan2 { get; set; }
    public int TarifGolongan3 { get; set; }

    public SistemTol()
    {
        TarifGolongan1 = 5000;
        TarifGolongan2 = 10000;
        TarifGolongan3 = 15000;
    }

    // Menghitung biaya tol berdasarkan golongan dan jarak
    public void HitungBiaya(string golongan, int jarak)
    {
        int tarif = 0;

        if (golongan == "golongan_1")
        {
            tarif = TarifGolongan1;
        }
        else if (golongan == "golongan_2")
        {
            tarif = TarifGolongan2;
        }
        else if (golongan == "golongan_3")
        {
            tarif = TarifGolongan3;
        }
        else
        {
            Console.WriteLine("Golongan kendaraan tidak valid!");
            return;
        }

        int biaya = tarif * jarak;
        Console.WriteLine($"Biaya tol untuk {golongan} dengan jarak {jarak} km adalah: {biaya} IDR");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerbangTol gerbang = new GerbangTol();
        SistemTol sistem = new SistemTol();

        // Menambah kendaraan ke antrian
        gerbang.TambahAntrian("Mobil Kecil - Golongan 1", "golongan_1");
        gerbang.TambahAntrian("Truk Kecil - Golongan 2", "golongan_2");
        gerbang.TambahAntrian("Truk Besar - Golongan 3", "golongan_3");

        // Menampilkan antrian kendaraan
        gerbang.TampilkanAntrian();

        // Proses kendaraan pertama
        gerbang.ProsesKendaraan();

        // Menghitung biaya tol untuk kendaraan pertama
        sistem.HitungBiaya("golongan_1", 10);  // Misalnya jarak 10 km
    }
}