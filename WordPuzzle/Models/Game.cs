using System;
using System.Collections.Generic;


namespace WordPuzzle.Models
{
  public class Game
  {
    public string Word { get; set; }
    public char[] GuessedLetters { get; set; }
    public int GuessesLeft { get; set; }
    public int LettersLeft { get; set; }
    public List<char> AllLettersGuessed { get; set; }

    public Game(string word)
    {
      Word = word;
      GuessedLetters = new char[word.Length];
      GuessesLeft = 6;
      LettersLeft = word.Length;
      AllLettersGuessed = new List<char> { };
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