using System;
using System.Collections.Generic;

class Barbershop
{
    private List<string> antrian;  // List untuk menyimpan nama pelanggan
    private bool buka;  // Status barbershop

    public Barbershop()
    {
        antrian = new List<string>();
        buka = true;
    }

    // Fungsi untuk membuka Barbershop
    public void BukaBarbershop()
    {
        Console.WriteLine("Barbershop sedang buka, silakan masuk!");
    }

    // Fungsi untuk menutup Barbershop
    public void TutupBarbershop()
    {
        buka = false;
        Console.WriteLine("Barbershop sudah tutup. Terima kasih sudah datang!");
    }

    // Fungsi untuk menambah pelanggan ke dalam antrian
    public void TambahPelanggan(string nama)
    {
        if (buka)
        {
            if (antrian.Count < 10)  // Maksimal antrian 10 pelanggan
            {
                antrian.Add(nama);
                Console.WriteLine($"{nama} telah masuk ke antrian.");
            }
            else
            {
                Console.WriteLine("Antrian sudah penuh!");
            }
        }
        else
        {
            Console.WriteLine("Barbershop sudah tutup. Anda tidak bisa mendaftar.");
        }
    }

    // Fungsi untuk memproses pelanggan
    public void ProsesPelanggan()
    {
        if (antrian.Count > 0)
        {
            string pelanggan = antrian[0];
            Console.WriteLine($"Sedang melayani {pelanggan}...");
            System.Threading.Thread.Sleep(2000);  // Simulasi waktu pemotongan rambut
            Console.WriteLine($"{pelanggan} telah selesai dilayani.");

            // Menghapus pelanggan dari antrian
            antrian.RemoveAt(0);
        }
        else
        {
            Console.WriteLine("Tidak ada pelanggan di antrian.");
        }
    }

    // Fungsi untuk menampilkan antrian
    public void TampilkanAntrian()
    {
        if (antrian.Count > 0)
        {
            Console.WriteLine("Antrian pelanggan:");
            for (int i = 0; i < antrian.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {antrian[i]}");
            }
        }
        else
        {
            Console.WriteLine("Tidak ada pelanggan di antrian.");
        }
    }
}

class Program
{
    static void Main()
    {
        Barbershop barbershop = new Barbershop();
        barbershop.BukaBarbershop();

        while (true)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Tambah Pelanggan");
            Console.WriteLine("2. Proses Pelanggan");
            Console.WriteLine("3. Lihat Antrian");
            Console.WriteLine("4. Tutup Barbershop");
            Console.WriteLine("5. Keluar");

            Console.Write("Pilih menu (1-5): ");
            int pilihan = int.Parse(Console.ReadLine());

            if (pilihan == 1)
            {
                Console.Write("Masukkan nama pelanggan: ");
                string nama = Console.ReadLine();
                barbershop.TambahPelanggan(nama);
            }
            else if (pilihan == 2)
            {
                barbershop.ProsesPelanggan();
            }
            else if (pilihan == 3)
            {
                barbershop.TampilkanAntrian();
            }
            else if (pilihan == 4)
            {
                barbershop.TutupBarbershop();
                break;
            }
            else if (pilihan == 5)
            {
                Console.WriteLine("Terima kasih telah menggunakan program ini!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }
}