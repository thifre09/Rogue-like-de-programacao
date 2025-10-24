using UnityEngine;

public class PlayCards : MonoBehaviour
{
    public GameObject playedCardsParent;
    public void PlaySelectedCards()
    {
        foreach (GameObject card in CardController.instance.selectedCards)
        {
            
        }
        CardController.instance.selectedCards.Clear();
    }
}
