using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPuzzle.Models;
using System;
using System.Collections.Generic;

namespace WordPuzzle.Tests
{
  [TestClass]
  public class GameTests 
  {
    [TestMethod]
    public void GameConstructor_InstanceOfGame_GameProperties()
    { 
      List<char> charList = new List<char> {};
      char[] letters = new char[5];
      Game wordPuzzle = new Game("apple");
      Assert.AreEqual(5, wordPuzzle.LettersLeft);
      Assert.AreEqual("apple", wordPuzzle.Word);
      Assert.AreEqual(6, wordPuzzle.GuessesLeft);
      CollectionAssert.AreEqual(charList, wordPuzzle.AllLettersGuessed);
      CollectionAssert.AreEqual(letters, wordPuzzle.GuessedLetters);
    }

    [TestMethod]
    public void DisplayWord_ReturnsStringOfUnderscore_String()
    {
      Game wordPuzzle = new Game("apple");
      Assert.AreEqual("_____", wordPuzzle.DisplayWord());
    }
    [TestMethod]
    public void ReassignLetters_ChangesLettersAndReturnNumberOfChangeLetters_Int()
    {
      Game wordPuzzle = new Game("apple");
      int results = wordPuzzle.ReassignLetters('p');
      Assert.AreEqual("_pp__", wordPuzzle.DisplayWord());
      Assert.AreEqual(2, results);
    }
    [TestMethod]
    public void AddToAllGuessedLetters_AddLettersToList_List()
    {
      Game wordPuzzle = new Game("apple");
      wordPuzzle.AddToAllGuessedLetters('a');
      List<char> expected = new List<char> { 'a' };
      CollectionAssert.AreEqual(expected, wordPuzzle.AllLettersGuessed);
    }
    [TestMethod]
    public void EndGame_ReturnZero_Int()
    {
      Game wordPuzzle = new Game("apple");
      Assert.AreEqual(0, wordPuzzle.EndGame());
    }
    [TestMethod]
    public void EndGame_ReturnOne_Int()
    {
      Game wordPuzzle = new Game("apple");
      wordPuzzle.LettersLeft = 0;
      Assert.AreEqual(1, wordPuzzle.EndGame());
    }
    [TestMethod]
    public void EndGame_ReturnTwo_Int()
    {
      Game wordPuzzle = new Game("apple");
      wordPuzzle.GuessesLeft = 0;
      Assert.AreEqual(2, wordPuzzle.EndGame());
    }
  }
}
