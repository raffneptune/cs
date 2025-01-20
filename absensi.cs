using System;
using System.Collections.Generic;

class Program
{
    // Daftar nama siswa/pegawai
    static List<string> daftarNama = new List<string> { "Ali", "Budi", "Citra", "Dewi", "Eka" };
    
    // Menyimpan status absensi
    static Dictionary<string, string> absensi = new Dictionary<string, string>();

    // Fungsi untuk mencatat absensi
    static void CatatAbsensi()
    {
        Console.WriteLine("Daftar Nama:");
        for (int i = 0; i < daftarNama.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {daftarNama[i]}");
        }

        foreach (var nama in daftarNama)
        {
            Console.Write($"Apakah {nama} hadir? (y/n): ");
            string status = Console.ReadLine().Trim().ToLower();

            if (status == "y")
            {
                absensi[nama] = "Hadir";
            }
            else if (status == "n")
            {
                absensi[nama] = "Tidak Hadir";
            }
            else
            {
                absensi[nama] = "Status Tidak Valid";
            }
        }

        Console.WriteLine("\nAbsensi Hari Ini:");
        foreach (var entry in absensi)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    static void Main()
    {
        // Menjalankan fungsi untuk mencatat absensi
        CatatAbsensi();
    }
}