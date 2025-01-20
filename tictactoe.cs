using System;

class TicTacToe
{
    // Fungsi untuk menampilkan papan permainan
    static void PrintBoard(char[] board)
    {
        Console.WriteLine("\n");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {board[i * 3]} | {board[i * 3 + 1]} | {board[i * 3 + 2]} ");
            if (i < 2) Console.WriteLine("---|---|---");
        }
        Console.WriteLine("\n");
    }

    // Fungsi untuk mengecek apakah pemain menang
    static bool CheckWin(char[] board, char player)
    {
        int[,] winConditions = {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // baris
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // kolom
            {0, 4, 8}, {2, 4, 6}              // diagonal
        };

        for (int i = 0; i < 8; i++)
        {
            if (board[winConditions[i, 0]] == player &&
                board[winConditions[i, 1]] == player &&
                board[winConditions[i, 2]] == player)
            {
                return true;
            }
        }
        return false;
    }

    // Fungsi untuk mengecek apakah papan penuh
    static bool IsBoardFull(char[] board)
    {
        foreach (var space in board)
        {
            if (space == ' ') return false;
        }
        return true;
    }

    // Fungsi utama permainan
    static void PlayGame()
    {
        char[] board = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };  // papan Tic Tac Toe kosong
        char currentPlayer = 'X';

        while (true)
        {
            PrintBoard(board);

            // Meminta pemain untuk memilih posisi
            int move;
            Console.Write($"Player {currentPlayer}, pilih posisi (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move - 1] != ' ')
            {
                Console.WriteLine("Posisi tidak valid atau sudah terisi, coba lagi.");
                continue;
            }

            // Menandai posisi dengan simbol pemain saat ini
            board[move - 1] = currentPlayer;

            // Mengecek apakah pemain menang
            if (CheckWin(board, currentPlayer))
            {
                PrintBoard(board);
                Console.WriteLine($"Selamat! Pemain {currentPlayer} menang!");
                break;
            }

            // Mengecek apakah papan penuh (seri)
            if (IsBoardFull(board))
            {
                PrintBoard(board);
                Console.WriteLine("Permainan berakhir dengan seri!");
                break;
            }

            // Ganti giliran pemain
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    // Fungsi utama
    static void Main()
    {
        PlayGame();
    }
}