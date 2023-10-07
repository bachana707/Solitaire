using UnityEngine;
using System.Collections.Generic;

public class Tableau : MonoBehaviour {
  public List<Card> cardsInPile = new List<Card>();

  public void AddCard(Card card) {
    cardsInPile.Add(card);
    // Update card's position and other UI elements here
  }

  public bool IsMoveValid(Card card) {
    // If the pile is empty, only King can be placed.
    if (cardsInPile.Count == 0) {
      Debug.Log("cardsInPile.Count == 0");
      return card.cardData.cardRank == CardData.Rank.King;
    }

    Card topCard = cardsInPile[cardsInPile.Count - 1];

    // Check for alternating colors:
    bool isDifferentColor = (IsRed(topCard) && !IsRed(card)) || (!IsRed(topCard) && IsRed(card));
    Debug.Log("isDifferentColor: " + isDifferentColor);
    // Check for descending order:
    bool isOneRankLower = card.cardData.cardRank == topCard.cardData.cardRank - 1;
    Debug.Log("isOneRankLower: " + isOneRankLower);
    return isDifferentColor && isOneRankLower;
  }

  bool IsRed(Card card) {
    return card.cardData.cardSuit == CardData.Suit.Hearts || card.cardData.cardSuit == CardData.Suit.Diamonds;
  }
}