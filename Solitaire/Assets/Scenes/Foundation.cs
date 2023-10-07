using UnityEngine;
using System.Collections.Generic;

public class Foundation : MonoBehaviour {
  public CardData.Suit foundationSuit;
  public List<Card> cardsInPile = new List<Card>();

  public bool IsMoveValid(Card card) {
    // Check for the correct suit
    if (card.cardData.cardSuit != foundationSuit) {
      return false;
    }

    // If pile is empty, only Ace can be placed
    if (cardsInPile.Count == 0) {
      return card.cardData.cardRank == CardData.Rank.Ace;
    }

    Card topCard = cardsInPile[cardsInPile.Count - 1];

    // Card should be one rank higher than the top card
    return card.cardData.cardRank == topCard.cardData.cardRank + 1;
  }
}