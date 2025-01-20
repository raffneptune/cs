using System;
using System.Collections.Generic;

class Program
{
    // Struktur untuk menyimpan data pengguna
    public class User
    {
        public string Name { get; set; }
        public int Kredit { get; set; }
        public List<string> Permainan { get; set; }

        public User(string name)
        {
            Name = name;
            Kredit = 0;
            Permainan = new List<string>();
        }
    }

    // Daftar pengguna
    static List<User> users = new List<User>();

    // Fungsi untuk mendaftar pengguna baru
    static void RegisterUser()
    {
        Console.Write("Masukkan nama pengguna: ");
        string name = Console.ReadLine();

        // Cek apakah pengguna sudah terdaftar
        foreach (var user in users)
        {
            if (user.Name == name)
            {
                Console.WriteLine($"Pengguna dengan nama {name} sudah terdaftar.");
                return;
            }
        }

        // Menambahkan pengguna baru
        users.Add(new User(name));
        Console.WriteLine($"Selamat datang, {name}! Akun Anda telah dibuat.");
    }

    // Fungsi untuk membeli kredit
    static void BuyCredits(string userName)
    {
        Console.Write("Berapa banyak kredit yang ingin Anda beli? (1 kredit = 5000 IDR): ");
        int creditAmount = int.Parse(Console.ReadLine());

        // Cari pengguna berdasarkan nama
        foreach (var user in users)
        {
            if (user.Name == userName)
            {
                user.Kredit += creditAmount;
                Console.WriteLine($"{creditAmount} kredit telah ditambahkan ke akun Anda.");
                return;
            }
        }

        Console.WriteLine("Pengguna tidak ditemukan. Silakan mendaftar terlebih dahulu.");
    }

    // Fungsi untuk bermain game
    static void PlayGame(string userName)
    {
        // Cari pengguna berdasarkan nama
        foreach (var user in users)
        {
            if (user.Name == userName)
            {
                if (user.Kredit < 1)
                {
                    Console.WriteLine("Anda tidak memiliki kredit cukup untuk bermain game. Silakan beli kredit terlebih dahulu.");
                    return;
                }

                Console.WriteLine("Pilih permainan yang ingin dimainkan:");
                Console.WriteLine("1. Pac-Man (1 kredit)");
                Console.WriteLine("2. Street Fighter (2 kredit)");
                Console.WriteLine("3. Racing Game (3 kredit)");

                int gameChoice = int.Parse(Console.ReadLine());

                if (gameChoice == 1 && user.Kredit >= 1)
                {
                    user.Kredit -= 1;
                    Console.WriteLine("Anda sedang bermain Pac-Man! Semoga berhasil!");
                }
                else if (gameChoice == 2 && user.Kredit >= 2)
                {
                    user.Kredit -= 2;
                    Console.WriteLine("Anda sedang bermain Street Fighter! Bertarunglah dengan kuat!");
                }
                else if (gameChoice == 3 && user.Kredit >= 3)
                {
                    user.Kredit -= 3;
                    Console.WriteLine("Anda sedang bermain Racing Game! Gaspol!");
                }
                else
                {
                    Console.WriteLine("Anda tidak memiliki kredit cukup untuk memilih permainan ini.");
                    return;
                }

                // Simulasi hasil permainan (acak)
                Random rand = new Random();
                int result = rand.Next(0, 2); // 0 = Kalah, 1 = Menang
                Console.WriteLine("Memulai permainan...");
                Console.WriteLine("Hasil permainan: " + (result == 1 ? "Menang" : "Kalah"));
                user.Permainan.Add(result == 1 ? "Menang" : "Kalah");
                return;
            }
        }

        Console.WriteLine("Pengguna tidak ditemukan. Silakan mendaftar terlebih dahulu.");
    }

    // Fungsi untuk mengecek saldo kredit
    static void CheckBalance(string userName)
    {
        // Cari pengguna berdasarkan nama
        foreach (var user in users)
        {
            if (user.Name == userName)
            {
                Console.WriteLine($"Sisa kredit Anda: {user.Kredit} kredit.");
                return;
            }
        }

        Console.WriteLine("Pengguna tidak ditemukan. Silakan mendaftar terlebih dahulu.");
    }

    // Menu utama
    static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di Timezone Mall!");

        while (true)
        {
            Console.WriteLine("\nMenu Utama:");
            Console.WriteLine("1. Daftar pengguna baru");
            Console.WriteLine("2. Beli kredit");
            Console.WriteLine("3. Mainkan game");
            Console.WriteLine("4. Cek saldo kredit");
            Console.WriteLine("5. Keluar");

            Console.Write("Pilih menu (1/2/3/4/5): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                RegisterUser();
            }
            else if (choice == 2)
            {
                Console.Write("Masukkan nama pengguna untuk membeli kredit: ");
                string userName = Console.ReadLine();
                BuyCredits(userName);
            }
            else if (choice == 3)
            {
                Console.Write("Masukkan nama pengguna untuk bermain game: ");
                string userName = Console.ReadLine();
                PlayGame(userName);
            }
            else if (choice == 4)
            {
                Console.Write("Masukkan nama pengguna untuk cek saldo: ");
                string userName = Console.ReadLine();
                CheckBalance(userName);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Terima kasih telah bermain di Timezone Mall! Sampai jumpa lagi!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
            }
        }
    }
}