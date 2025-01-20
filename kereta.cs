using System;
using System.Collections.Generic;

class Kereta
{
    public string NamaKereta { get; set; }
    public string Tujuan { get; set; }
    public string WaktuBerangkat { get; set; }
    public int Kapasitas { get; set; }
    public int Terisi { get; set; }

    public Kereta(string namaKereta, string tujuan, string waktuBerangkat, int kapasitas)
    {
        NamaKereta = namaKereta;
        Tujuan = tujuan;
        WaktuBerangkat = waktuBerangkat;
        Kapasitas = kapasitas;
        Terisi = 0;
    }

    public void TampilkanInfo()
    {
        Console.WriteLine($"Nama Kereta: {NamaKereta}");
        Console.WriteLine($"Tujuan: {Tujuan}");
        Console.WriteLine($"Waktu Berangkat: {WaktuBerangkat}");
        Console.WriteLine($"Kapasitas: {Kapasitas}");
        Console.WriteLine($"Terisi: {Terisi}/{Kapasitas}");
        Console.WriteLine();
    }

    public void PesanTiket(int jumlahTiket)
    {
        if (Terisi + jumlahTiket <= Kapasitas)
        {
            Terisi += jumlahTiket;
            Console.WriteLine($"Berhasil memesan {jumlahTiket} tiket untuk {NamaKereta}.");
        }
        else
        {
            Console.WriteLine($"Maaf, hanya tersisa {Kapasitas - Terisi} tiket untuk {NamaKereta}.");
        }
    }
}

class SistemKereta
{
    private List<Kereta> keretaList;

    public SistemKereta()
    {
        keretaList = new List<Kereta>();
    }

    public void TambahKereta(Kereta kereta)
    {
        keretaList.Add(kereta);
    }

    public void TampilkanJadwal()
    {
        Console.WriteLine("Jadwal Kereta:");
        foreach (var kereta in keretaList)
        {
            kereta.TampilkanInfo();
        }
    }

    public void PesanTiketKereta(string namaKereta, int jumlahTiket)
    {
        bool ditemukan = false;
        foreach (var kereta in keretaList)
        {
            if (kereta.NamaKereta == namaKereta)
            {
                kereta.PesanTiket(jumlahTiket);
                ditemukan = true;
                break;
            }
        }

        if (!ditemukan)
        {
            Console.WriteLine($"Kereta dengan nama {namaKereta} tidak ditemukan.");
        }
    }
}

class Program
{
    static void Main()
    {
        SistemKereta sistemKereta = new SistemKereta();

        // Menambahkan kereta ke sistem
        Kereta kereta1 = new Kereta("Ekspres Jakarta", "Bandung", "10:00", 100);
        Kereta kereta2 = new Kereta("Argo Bromo", "Surabaya", "15:00", 150);
        Kereta kereta3 = new Kereta("Kelas Ekonomi", "Yogyakarta", "12:00", 200);

        sistemKereta.TambahKereta(kereta1);
        sistemKereta.TambahKereta(kereta2);
        sistemKereta.TambahKereta(kereta3);

        int pilihan;
        string namaKereta;
        int jumlahTiket;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tampilkan Jadwal Kereta");
            Console.WriteLine("2. Pesan Tiket Kereta");
            Console.WriteLine("3. Keluar");

            Console.Write("Pilih menu (1/2/3): ");
            pilihan = int.Parse(Console.ReadLine());

            if (pilihan == 1)
            {
                sistemKereta.TampilkanJadwal();
            }
            else if (pilihan == 2)
            {
                Console.Write("Masukkan nama kereta yang ingin dipesan: ");
                namaKereta = Console.ReadLine();
                Console.Write("Masukkan jumlah tiket yang ingin dipesan: ");
                jumlahTiket = int.Parse(Console.ReadLine());
                sistemKereta.PesanTiketKereta(namaKereta, jumlahTiket);
            }
            else if (pilihan == 3)
            {
                Console.WriteLine("Terima kasih telah menggunakan sistem kereta.");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }
        }
    }
}