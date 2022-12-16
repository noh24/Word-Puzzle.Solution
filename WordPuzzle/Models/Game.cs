using System;
using System.Collections.Generic;


namespace WordPuzzle.Models
{
  public class Game
  {
    public string Word { get; set; }
    public string[] Words = new string[] { "cluck", "yourmother", "dinosaur", "stranger", "danger", "request", "file", "brian", "tin", "helmet", "guitar" };
    public char[] GuessedLetters { get; set; }
    public int GuessesLeft { get; set; }
    public int LettersLeft { get; set; }
    public List<char> AllLettersGuessed { get; set; }
    public static Game MyGame { get; set; }

    public Game()
    {
      Random random = new Random();
      Word = Words[random.Next(Words.Length - 1)];
      GuessedLetters = new char[Word.Length];
      GuessesLeft = Word.Length + 2;
      LettersLeft = Word.Length;
      AllLettersGuessed = new List<char> { };
      MyGame = this;
    }
    //replaces null indicies with "_" and returns GuessedLetters in string format 
    public string DisplayWord() //{null,null,null} = "___" {c,null,t} = "c_t
    {
      string replaced = "";
      for (int i = 0; i < Word.Length; i++)
      {
        if (GuessedLetters[i] == Word[i])
        {
          replaced += Word[i];
        }
        else
        {
          replaced += "_";
        }
      }
      return replaced;
    }

    public int ReassignLetters(char ch)
    {
      int containsChar = 0;
      for (int i = 0; i < Word.Length; i++)
      {
        if (Word[i] == ch)
        {
          GuessedLetters[i] = ch;
          containsChar++;
        }
      }
      return containsChar;
    }

    public void AddToAllGuessedLetters(char letter)
    {
      AllLettersGuessed.Add(letter);
    }

    public int EndGame()
    {
      if (LettersLeft == 0)
      {
        return 1;
      }
      else if (GuessesLeft == 0)
      {
        return 2;
      }
      return 0;
    }
    public void Guess(char guess)
    {
      guess = Char.ToLower(guess);
      if (guess < 97 || guess > 122)
      {
        return;
      }
      if (EndGame() == 0 && !AllLettersGuessed.Contains(guess))
      {
        int letters = ReassignLetters(guess);
        AddToAllGuessedLetters(guess);
        GuessesLeft--;
        LettersLeft -= letters;
      }
    }
  }
}

//gameCategory
//game
//string word 
//char[] guessedLetter {w,o,r,d}
//int totalGuessedLetters {}
//int correctLetters = 4 ---win condition
//int tries = 6 ---- LOSE condition : 0 


//method to replace letters with _ 
// method to reassign correct guess letters
//char[] guessedLetter {w,o,r,d}

// abstraction umbrella method
//method to add all guess letters to
//int AllGuessedLetters {}

//endgame method check for 0
//int correctLetters = 4 ---win condition
//int tries = 6 ---- LOSE condition : 0
// 0 continue, 1 correctLetters WIN, 2 tries LOSE