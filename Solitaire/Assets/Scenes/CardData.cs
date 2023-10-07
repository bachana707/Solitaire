using UnityEngine;

[CreateAssetMenu(menuName = "Card Game/Card Data")]
public class CardData : ScriptableObject
{
  public enum Suit { Hearts, Diamonds, Clubs, Spades }
  public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

  public Suit cardSuit;
  public Rank cardRank;
  public Material cardMaterial; // assuming you want to use a different image for each card
}