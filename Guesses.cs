using System;
using System.Collections.Generic;

class Guesses
{
  private int LowerRange;
  private int HigherRange;
  private bool gameOver;

  public Guesses(int low = 0, int high = 100, bool over = false)
  {
    LowerRange = low;
    HigherRange = high;
    gameOver = over;
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

  public void makeGuess(int number)
  {
    Console.WriteLine("Is your number higher or lower than " + number + "? (higher/lower/correct)");
    string input = Console.ReadLine();
    if(input == "higher")
    {
      LowerRange = number;
    } else if(input == "lower")
    {
      HigherRange = number;
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
      Console.WriteLine("Okay");
      while(!guess.IsGameOver())
      {
        int midGuess = (guess.GetLowerRange() + guess.GetHigherRange())/2;
        guess.makeGuess(midGuess);
      }
      Console.WriteLine("Great! I guessed your number. Would you like to play again? (Y/N)");
      string playAgain = Console.ReadLine();
      if(playAgain == "Y" || playAgain == "y")
      {
        Main();
      }
    }
  }

}
