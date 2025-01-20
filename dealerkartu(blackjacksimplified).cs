using System;
using System.Collections.Generic;

class Blackjack
{
    // Daftar kartu dalam deck
    static List<string> deck = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    // Fungsi untuk menghitung nilai kartu
    static int CardValue(string card)
    {
        if (card == "J" || card == "Q" || card == "K")
        {
            return 10;
        }
        else if (card == "A")
        {
            return 11; // Menganggap Ace = 11 untuk kesederhanaan
        }
        else
        {
            return int.Parse(card); // Kartu angka (2-10)
        }
    }

    // Fungsi untuk membagikan kartu secara acak
    static string DealCard(ref List<string> deck)
    {
        Random rand = new Random();
        int index = rand.Next(deck.Count);
        string card = deck[index];
        deck.RemoveAt(index); // Hapus kartu yang sudah dibagikan
        return card;
    }

    // Fungsi untuk menghitung total nilai kartu dalam hand
    static int CalculateHand(List<string> hand)
    {
        int total = 0;
        foreach (string card in hand)
        {
            total += CardValue(card);
        }
        return total;
    }

    // Fungsi utama untuk menjalankan permainan
    static void StartGame()
    {
        List<string> deckCopy = new List<string>(deck); // Salinan deck untuk permainan

        // Kartu untuk pemain dan dealer
        List<string> playerHand = new List<string>();
        List<string> dealerHand = new List<string>();

        // Membagikan dua kartu untuk pemain dan dealer
        playerHand.Add(DealCard(ref deckCopy));
        playerHand.Add(DealCard(ref deckCopy));
        dealerHand.Add(DealCard(ref deckCopy));
        dealerHand.Add(DealCard(ref deckCopy));

        // Menampilkan kartu awal pemain dan dealer (satu kartu dealer tersembunyi)
        Console.WriteLine("Kartu Anda: " + string.Join(" ", playerHand) + " dengan nilai " + CalculateHand(playerHand));
        Console.WriteLine("Kartu Dealer: " + dealerHand[0] + " dan kartu tersembunyi");

        // Giliran pemain
        while (CalculateHand(playerHand) < 21)
        {
            Console.Write("Apakah Anda ingin 'Hit' atau 'Stand'? ");
            string action = Console.ReadLine().ToLower();
            if (action == "hit")
            {
                playerHand.Add(DealCard(ref deckCopy));
                Console.WriteLine("Kartu Anda sekarang: " + string.Join(" ", playerHand) + " dengan nilai " + CalculateHand(playerHand));
            }
            else if (action == "stand")
            {
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Pilih 'Hit' atau 'Stand'.");
            }
        }

        // Jika pemain melebihi 21
        if (CalculateHand(playerHand) > 21)
        {
            Console.WriteLine("Nilai kartu Anda melebihi 21! Anda kalah!");
            return;
        }

        // Giliran dealer (dealer akan 'hit' sampai total kartu >= 17)
        Console.WriteLine("Kartu Dealer sekarang: " + string.Join(" ", dealerHand) + " dengan nilai " + CalculateHand(dealerHand));
        while (CalculateHand(dealerHand) < 17)
        {
            Console.WriteLine("Dealer memukul kartu...");
            dealerHand.Add(DealCard(ref deckCopy));
            Console.WriteLine("Kartu Dealer sekarang: " + string.Join(" ", dealerHand) + " dengan nilai " + CalculateHand(dealerHand));
        }

        // Menentukan pemenang
        int playerTotal = CalculateHand(playerHand);
        int dealerTotal = CalculateHand(dealerHand);

        if (dealerTotal > 21)
        {
            Console.WriteLine("Dealer melebihi 21! Anda menang!");
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("Anda menang!");
        }
        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("Dealer menang!");
        }
        else
        {
            Console.WriteLine("Hasil seri!");
        }
    }

    // Fungsi utama untuk menjalankan permainan
    static void Main()
    {
        Console.WriteLine("Selamat datang di permainan Dealer Kartu!");
        StartGame();
    }
}