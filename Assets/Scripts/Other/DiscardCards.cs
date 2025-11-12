using UnityEngine;

public class DiscardCards : MonoBehaviour
{
    public void DiscardSelectedCards()
    {
        for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
        {
            GameObject card = CardController.instance.selectedCards[i];
            LeanTween.cancel(card, true);
            CardController.instance.availableCards.Remove(card);
            CardController.instance.handCards.Remove(card);
            LeanTween.scale(card, Vector3.zero, 0.5f).setEaseInBack().setOnComplete(() =>
            {
                card.transform.SetParent(CardController.instance.discartedCardsContainer.transform);
                card.SetActive(false);
                CardController.instance.DrawCard(1);
            });
            
        }
    }
}
