using System;
using System.Collections.Generic;

class Guesses
{
  private int LowerRange;
  private int HigherRange;
  private bool gameOver;
  private int MyNumber;

  public Guesses(int low = 0, int high = 100, bool over = false, int number = 0)
  {
    LowerRange = low;
    HigherRange = high;
    gameOver = over;
    MyNumber = number;
  }

  public int GetLowerRange()
  {
    return LowerRange;
  }
  public int GetHigherRange()
  {
    return HigherRange;
  }
  public bool IsGameOver(){
    return gameOver;
  }
  public void SetNumber(int number)
  {
    MyNumber = number;
  }
  public void AIGuess(int number)
  {
    Console.WriteLine("Is your number higher or lower than " + number + "? (higher/lower/correct)");
    string input = Console.ReadLine();
    if(input == "higher")
    {
      LowerRange = number;
    } else if(input == "lower")
    {
      HigherRange = number;
    } else if(input == "correct")
    {
      gameOver = true;
    } else
    {
      Console.WriteLine("I don't understand.");
    }
  }

  public void UserGuess()
  {
    Console.WriteLine("Take a guess at computer number 1-100.");
    int userGuess = int.Parse(Console.ReadLine());
    if(MyNumber > userGuess)
    {
      Console.WriteLine("Higher");
    } else if (MyNumber < userGuess)
    {
      Console.WriteLine("Lower");
    } else
    {
      gameOver = true;
    }
  }
}

public class Program
{
  public static void Main()
  {
    Guesses guess = new Guesses();
    Console.WriteLine("Would you like to play the higher/lower game? (Y/N)");
    string input = Console.ReadLine();
    if(input == "Y" || input == "y")
    {
      Console.WriteLine("Which game mode would you like to play:");
      Console.WriteLine("1 = Computer Guess");
      Console.WriteLine("2 = User Guess");
      input = Console.ReadLine();
      if(input == "1")
      {
        while(!guess.IsGameOver())
        {
          int midGuess = (guess.GetLowerRange() + guess.GetHigherRange())/2;
          guess.AIGuess(midGuess);
        }
        Console.WriteLine("Great! I guessed your number. Would you like to play again? (Y/N)");
        input = Console.ReadLine();
        if(input == "Y" || input == "y")
        {
          Main();
        }
      } else
      {
        Random rnd = new Random();
        int randomNumber = rnd.Next(1,101);
        guess.SetNumber(randomNumber);
        while(!guess.IsGameOver())
        {
          guess.UserGuess();
        }
        Console.WriteLine("Great! You guessed my number. Would you like to play again? (Y/N)");
        input = Console.ReadLine();
        if(input == "Y" || input == "y")
        {
          Main();
        }
      }
    }
  }
}
