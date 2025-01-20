using System;
using System.Linq;
using System.Threading;

class Komputer
{
    public int Nomor { get; set; }
    public bool Tersedia { get; set; }
    public DateTime? MulaiSewa { get; set; }
    public double DurasiSewa { get; set; }

    public Komputer(int nomor)
    {
        Nomor = nomor;
        Tersedia = true;
        MulaiSewa = null;
        DurasiSewa = 0;
    }

    public void Sewa()
    {
        if (Tersedia)
        {
            Tersedia = false;
            MulaiSewa = DateTime.Now;
            Console.WriteLine($"Komputer {Nomor} telah disewa.");
        }
        else
        {
            Console.WriteLine($"Komputer {Nomor} sedang disewa.");
        }
    }

    public void SelesaiSewa()
    {
        if (!Tersedia && MulaiSewa.HasValue)
        {
            var waktuSewa = DateTime.Now - MulaiSewa.Value;
            DurasiSewa = waktuSewa.TotalMinutes;
            double biaya = DurasiSewa * 2000; // Biaya per menit misalnya 2000 IDR
            Tersedia = true;
            MulaiSewa = null;
            Console.WriteLine($"Komputer {Nomor} selesai disewa. Durasi: {DurasiSewa:F2} menit.");
            Console.WriteLine($"Biaya yang harus dibayar: Rp {biaya:F2}");
        }
        else
        {
            Console.WriteLine($"Komputer {Nomor} belum disewa.");
        }
    }
}

class Warnet
{
    private Komputer[] komputer;

    public Warnet(int jumlahKomputer)
    {
        komputer = new Komputer[jumlahKomputer];
        for (int i = 0; i < jumlahKomputer; i++)
        {
            komputer[i] = new Komputer(i + 1);
        }
    }

    public void TampilkanKomputer()
    {
        Console.WriteLine("\nDaftar Komputer:");
        foreach (var kom in komputer)
        {
            string status = kom.Tersedia ? "Tersedia" : "Sedang disewa";
            Console.WriteLine($"Komputer {kom.Nomor}: {status}");
        }
    }

    public void SewaKomputer(int nomor)
    {
        if (nomor >= 1 && nomor <= komputer.Length)
        {
            komputer[nomor - 1].Sewa();
        }
        else
        {
            Console.WriteLine("Nomor komputer tidak valid!");
        }
    }

    public void SelesaiKomputer(int nomor)
    {
        if (nomor >= 1 && nomor <= komputer.Length)
        {
            komputer[nomor - 1].SelesaiSewa();
        }
        else
        {
            Console.WriteLine("Nomor komputer tidak valid!");
        }
    }
}

class Program
{
    static void Menu()
    {
        Warnet warnet = new Warnet(5); // Misalkan ada 5 komputer di warnet
        while (true)
        {
            Console.WriteLine("\n--- Menu Warnet ---");
            Console.WriteLine("1. Tampilkan Daftar Komputer");
            Console.WriteLine("2. Sewa Komputer");
            Console.WriteLine("3. Selesai Sewa Komputer");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    warnet.TampilkanKomputer();
                    break;
                case "2":
                    Console.Write("Masukkan nomor komputer yang ingin disewa: ");
                    if (int.TryParse(Console.ReadLine(), out int nomorSewa))
                    {
                        warnet.SewaKomputer(nomorSewa);
                    }
                    else
                    {
                        Console.WriteLine("Nomor yang dimasukkan tidak valid.");
                    }
                    break;
                case "3":
                    Console.Write("Masukkan nomor komputer yang selesai disewa: ");
                    if (int.TryParse(Console.ReadLine(), out int nomorSelesai))
                    {
                        warnet.SelesaiKomputer(nomorSelesai);
                    }
                    else
                    {
                        Console.WriteLine("Nomor yang dimasukkan tidak valid.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Terima kasih telah menggunakan layanan warnet!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }

            Thread.Sleep(1000); // Beri waktu 1 detik sebelum kembali ke menu
        }
    }

    static void Main(string[] args)
    {
        Menu();
    }
}