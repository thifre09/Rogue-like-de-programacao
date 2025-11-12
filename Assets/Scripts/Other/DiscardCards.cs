using UnityEngine;

public class DiscardCards : MonoBehaviour
{
    public void DiscardSelectedCards()
    {
        foreach (VariableCardData cardData in CardController.instance.selectedCards.Keys)
        {
            GameObject card = CardController.instance.selectedCards[cardData];
            LeanTween.cancel(card, true);
            CardController.instance.availableCards.Remove(cardData);
            CardController.instance.handCards.Remove(cardData);
            LeanTween.scale(card, Vector3.zero, 0.5f).setEaseInBack().setOnComplete(() =>
            {
                card.transform.SetParent(CardController.instance.discartedCardsContainer.transform);
                card.SetActive(false);
                CardController.instance.DrawCard(1);
            });
            
        }
    }
}
