using System;

class Program
{
    // Fungsi untuk menghitung gaji total
    static double HitungGaji(double gajiPokok, double tunjangan, double potongan)
    {
        return gajiPokok + tunjangan - potongan;
    }

    static void Main()
    {
        double gajiPokok, tunjangan, potongan, gajiTotal;

        // Menampilkan judul program
        Console.WriteLine("Program Perhitungan Gaji Karyawan");

        // Input data
        Console.Write("Masukkan gaji pokok: Rp ");
        gajiPokok = Convert.ToDouble(Console.ReadLine());

        Console.Write("Masukkan tunjangan: Rp ");
        tunjangan = Convert.ToDouble(Console.ReadLine());

        Console.Write("Masukkan potongan: Rp ");
        potongan = Convert.ToDouble(Console.ReadLine());

        // Menghitung gaji total
        gajiTotal = HitungGaji(gajiPokok, tunjangan, potongan);

        // Menampilkan hasil perhitungan
        Console.WriteLine("\nRingkasan Gaji:");
        Console.WriteLine($"Gaji Pokok: Rp {gajiPokok}");
        Console.WriteLine($"Tunjangan: Rp {tunjangan}");
        Console.WriteLine($"Potongan: Rp {potongan}");
        Console.WriteLine($"Gaji Total: Rp {gajiTotal}");
    }
}