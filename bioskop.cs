using System;

class Program
{
    // Menampilkan daftar film yang tersedia
    static void ShowFilms()
    {
        Console.WriteLine("Daftar Film yang Tersedia:");
        Console.WriteLine("1. Film A - Harga: Rp 50000");
        Console.WriteLine("2. Film B - Harga: Rp 60000");
        Console.WriteLine("3. Film C - Harga: Rp 70000");
        Console.WriteLine("4. Film D - Harga: Rp 55000");
    }

    // Memilih film yang diinginkan oleh pengguna
    static int PilihFilm()
    {
        int pilihan;
        while (true)
        {
            Console.Write("\nPilih film (1-4): ");
            if (int.TryParse(Console.ReadLine(), out pilihan) && pilihan >= 1 && pilihan <= 4)
            {
                return pilihan;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }

    // Proses membeli tiket
    static void BeliTiket()
    {
        int pilihan, jumlahTiket, totalHarga;
        
        while (true)
        {
            ShowFilms();
            pilihan = PilihFilm();
            
            // Menghitung harga berdasarkan film yang dipilih
            switch (pilihan)
            {
                case 1:
                    totalHarga = 50000;
                    break;
                case 2:
                    totalHarga = 60000;
                    break;
                case 3:
                    totalHarga = 70000;
                    break;
                case 4:
                    totalHarga = 55000;
                    break;
                default:
                    totalHarga = 0;
                    break;
            }

            // Input jumlah tiket
            Console.Write("Masukkan jumlah tiket yang ingin dibeli: ");
            while (!int.TryParse(Console.ReadLine(), out jumlahTiket) || jumlahTiket <= 0)
            {
                Console.Write("Jumlah tiket tidak valid, coba lagi: ");
            }
            
            totalHarga *= jumlahTiket; // Menghitung total harga
            
            // Menampilkan hasil pembelian
            Console.WriteLine($"\nTiket untuk film {GetFilmName(pilihan)} ({jumlahTiket} tiket) berhasil dipesan.");
            Console.WriteLine($"Total harga: Rp {totalHarga}");

            // Tanya apakah ingin membeli tiket lagi
            Console.Write("\nApakah Anda ingin membeli tiket lagi? (y/t): ");
            char lagi = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (lagi == 't')
            {
                Console.WriteLine("Terima kasih telah membeli tiket di bioskop kami!");
                break;
            }
        }
    }

    // Mendapatkan nama film berdasarkan pilihan
    static string GetFilmName(int pilihan)
    {
        switch (pilihan)
        {
            case 1: return "Film A";
            case 2: return "Film B";
            case 3: return "Film C";
            case 4: return "Film D";
            default: return "Film Tidak Diketahui";
        }
    }

    // Program utama
    static void Main()
    {
        BeliTiket();
    }
}