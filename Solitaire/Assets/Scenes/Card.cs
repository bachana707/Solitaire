using UnityEngine;

public class Card : MonoBehaviour
{
  public Tableau currentTableau;
  public CardData cardData;
  public bool isFaceUp = false;
  private MeshRenderer meshRenderer;

  private bool isDragging = false;
  private Vector3 offset;
  private Vector3 initialPosition;
  private Card _otherCard;
  private void Awake()
  {
    meshRenderer = GetComponent<MeshRenderer>();
  }

  // Function to update card visuals

  void Update()
  {
    if (isDragging)
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, Mathf.Infinity))
      {
        transform.position = hit.point + offset;
      }
    }
  }

  void OnMouseDown()
  {
    isDragging = true;
    initialPosition = transform.position;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    {
      offset = transform.position - hit.point;
    }
  }

  void OnMouseUp()
  {
    isDragging = false;
    // Check collision or placement logic here...
    if (_otherCard!=null)
    {
      Debug.Log("Other Card not null");
      if (_otherCard.currentTableau.IsMoveValid(this))
      {
        Debug.Log("Valid Move");
        _otherCard.currentTableau.AddCard(this);  //ToDo remove this card from the previous tableau
        _otherCard = null;
      }
      else
      {
        MoveBackToInitialPosition();
      }
    }
    else
    {
      MoveBackToInitialPosition();
    }
  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Card")) {
      _otherCard = collision.gameObject.GetComponent<Card>();
    }
  }
  void MoveBackToInitialPosition()
  {
    transform.position = initialPosition;
  }
  // Flip the card
  public void Flip()
  {
    isFaceUp = !isFaceUp;
    UpdateCardVisual();
  }
  public void UpdateCardVisual()
  {
    if (isFaceUp)
    {
      meshRenderer.material = cardData.cardMaterial;
    }
    else
    {
      // Display the back of the card or a default image
      // spriteRenderer.sprite = backOfCardImage;
    }
  }
}