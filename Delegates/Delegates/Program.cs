using System;

class Program
{
   
    delegate void SpinDelegate(int luckynumber,ref int energyLevel, ref int winningProbability);

    static void Main()
    {
        string playerName;
        int luckyNumber;

        Console.Write("Enter Your Name: ");
        playerName = Console.ReadLine();

        Console.Write("Enter Your Lucky Number from 1 to 10: ");
        luckyNumber = int.Parse(Console.ReadLine());

        int energyLevel = 1;
        int winningProbability = 100;
        int noOfSpins = 5;

        SpinDelegate spinDelegate = Spin; // Assign the spin function to the delegate

        for (int spinCount = 1; spinCount <= noOfSpins; spinCount++)
        {
            Console.WriteLine($"Spin {spinCount}:");
            spinDelegate.Invoke(luckyNumber, ref energyLevel, ref winningProbability);
        }

        DetermineResult(energyLevel, winningProbability);
        Console.ReadLine();
    }


    static void Spin(int LuckyNumber,ref int energyLevel, ref int winningProbability)
    {
        
        switch (LuckyNumber)
        {
            case 1:
                energyLevel += 1;
                winningProbability += 10;
                break;
            case 2:
                energyLevel += 2;
                winningProbability += 20;
                break;
            case 3:
                energyLevel -= 3;
                winningProbability -= 30;
                break;
            case 4:
                energyLevel += 4;
                winningProbability += 40;
                break;
            case 5:
                energyLevel += 5;
                winningProbability += 50;
                break;
            case 6:
                energyLevel -= 1;
                winningProbability -= 60;
                break;
            case 7:
                energyLevel += 1;
                winningProbability += 70;
                break;
            case 8:
                energyLevel -= 2;
                winningProbability -= 20;
                break;
            case 9:
                energyLevel -= 3;
                winningProbability -= 30;
                break;
            case 10:
                energyLevel -= 10;
                winningProbability -= 100;
                break;
        }

        Console.WriteLine($"Energy Level: {energyLevel}, Winning Probability: {winningProbability}");
    }


    static void DetermineResult(int energyLevel, int winningProbability)
    {
        Console.WriteLine("\nResult:");

        if (energyLevel >= 4 && winningProbability > 60)
        {
            Console.WriteLine("Winner!");
        }
        else if (energyLevel >= 1 && winningProbability > 50)
        {
            Console.WriteLine("Runner Up!");
        }
        else
        {
            Console.WriteLine("Loser!");
        }
    }
}
