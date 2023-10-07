using UnityEngine;
using System.Collections.Generic;
using System;
public class Deck : MonoBehaviour
{
  public List<Card> cards = new List<Card>();  // List of all cards in the deck
  public Transform drawPile;  // Where the deck is
  public Transform discardPile;  // Where the drawn cards go

  public void Shuffle()
  {
    int n = cards.Count;
    System.Random rnd = new System.Random();
    
    for (int i = n - 1; i > 0; i--)
    {
      int j = rnd.Next(i + 1); // Random number between 0 and i
      // Swap cards[i] with cards[j]
      Card temp = cards[i];
      cards[i] = cards[j];
      cards[j] = temp;
    }
  }


  public Card DrawCard()
  {
    if (cards.Count > 0)
    {
      Card drawnCard = cards[0];
      cards.RemoveAt(0);
      return drawnCard;
    }
    return null;
  }
}