using System;
using System.Collections.Generic;

public class Barang
{
    public string Nama { get; set; }
    public double Harga { get; set; }
    public int Jumlah { get; set; }
    public double Total { get; set; }
}

class Program
{
    static void Main()
    {
        List<Barang> daftarBarang = new List<Barang>();
        double totalHarga = 0;
        int pilihan;
        string namaBarang;
        double harga;
        int jumlah;
        double uangDibayar;

        while (true)
        {
            Console.WriteLine("\nMenu Kasir");
            Console.WriteLine("1. Tambah barang");
            Console.WriteLine("2. Tampilkan rincian belanja");
            Console.WriteLine("3. Bayar");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu (1/2/3/4): ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            if (pilihan == 1)
            {
                Console.Write("Masukkan nama barang: ");
                namaBarang = Console.ReadLine();

                Console.Write("Masukkan harga barang: ");
                harga = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan jumlah barang: ");
                jumlah = Convert.ToInt32(Console.ReadLine());

                // Tambah barang
                Barang barang = new Barang
                {
                    Nama = namaBarang,
                    Harga = harga,
                    Jumlah = jumlah,
                    Total = harga * jumlah
                };

                daftarBarang.Add(barang);
                totalHarga += barang.Total;

                Console.WriteLine($"{namaBarang} x{jumlah} ditambahkan ke daftar belanja.");
            }
            else if (pilihan == 2)
            {
                // Tampilkan rincian belanja
                Console.WriteLine("\n--- Rincian Belanja ---");
                foreach (var barang in daftarBarang)
                {
                    Console.WriteLine($"{barang.Nama} - Harga: {barang.Harga:F2} - Jumlah: {barang.Jumlah} - Total: {barang.Total:F2}");
                }
                Console.WriteLine($"\nTotal Belanja: {totalHarga:F2}");
            }
            else if (pilihan == 3)
            {
                // Tampilkan rincian belanja dan proses pembayaran
                Console.WriteLine("\n--- Rincian Belanja ---");
                foreach (var barang in daftarBarang)
                {
                    Console.WriteLine($"{barang.Nama} - Harga: {barang.Harga:F2} - Jumlah: {barang.Jumlah} - Total: {barang.Total:F2}");
                }
                Console.WriteLine($"\nTotal Belanja: {totalHarga:F2}");

                Console.Write("Masukkan uang yang dibayar: ");
                uangDibayar = Convert.ToDouble(Console.ReadLine());

                if (uangDibayar >= totalHarga)
                {
                    double kembalian = uangDibayar - totalHarga;
                    Console.WriteLine($"\nTotal yang harus dibayar: {totalHarga:F2}");
                    Console.WriteLine($"Uang yang dibayar: {uangDibayar:F2}");
                    Console.WriteLine($"Kembalian: {kembalian:F2}");
                }
                else
                {
                    Console.WriteLine("\nUang yang dibayar kurang dari total belanja. Transaksi dibatalkan.");
                }
            }
            else if (pilihan == 4)
            {
                Console.WriteLine("Terima kasih, sampai jumpa!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }
}