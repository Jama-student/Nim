using System;

class RealNimGame
{
    static void Main(string[] args)
    {
        int[] piles = { 3, 4, 5 };
        bool isPlayerTurn = true;

        Console.WriteLine("Welcome to The Real Nim Game!");

        while (!IsGameOver(piles))
        {
            DisplayPiles(piles);

            if (isPlayerTurn)
            {
                PlayerTurn(piles);
            }
            else
            {
                AITurn(piles);
            }

            isPlayerTurn = !isPlayerTurn;
        }

        DisplayPiles(piles);
        DeclareWinner(isPlayerTurn);
    }

    static void DisplayPiles(int[] piles)
    {
        Console.WriteLine("\nCurrent Piles:");
        for (int i = 0; i < piles.Length; i++)
        {
            Console.WriteLine($"Row {i + 1}: {new string('O', piles[i])} ({piles[i]} matches)");
        }
    }

    static void PlayerTurn(int[] piles)
    {
        int row, matches;
        Console.WriteLine("\nYour Turn:");
        do
        {
            Console.Write("Choose a row (1, 2, or 3): ");
            if (!int.TryParse(Console.ReadLine(), out row) || row < 1 || row > piles.Length || piles[row - 1] == 0)
            {
                Console.WriteLine("Invalid row. Please select a valid row with matches.");
                row = 0;
            }
        } while (row == 0);

        do
        {
            Console.Write("Choose the number of matches to remove (1-3): ");
            if (!int.TryParse(Console.ReadLine(), out matches) || matches < 1 || matches > 3 || matches > piles[row - 1])
            {
                Console.WriteLine("Invalid number. Please select a number between 1 and 3 that does not exceed the matches in the row.");
                matches = 0;
            }
        } while (matches == 0);

        piles[row - 1] -= matches;
    }

    static void AITurn(int[] piles)
    {
        Console.WriteLine("\nAI's Turn:");
        for (int i = 0; i < piles.Length; i++)
        {
            if (piles[i] > 0)
            {
                int matches = Math.Min(3, piles[i]);
                piles[i] -= matches;
                Console.WriteLine($"AI removes {matches} match(es) from Row {i + 1}.");
                return;
            }
        }
    }

    static bool IsGameOver(int[] piles)
    {
        foreach (int pile in piles)
        {
            if (pile > 0)
                return false;
        }
        return true;
    }

    static void DeclareWinner(bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            Console.WriteLine("\nYou drew the last match. You lose!");
        }
        else
        {
            Console.WriteLine("\nThe AI drew the last match. You win!");
        }
    }
}
