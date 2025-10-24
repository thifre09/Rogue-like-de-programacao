using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance;
    public int maxHandCards = 6;
    public int maxCardsPlayable = 4;
    public List<GameObject> functionCards = new();
    public List<GameObject> deckCards = new();
    public List<GameObject> handCards = new();
    public List<GameObject> selectedCards = new();
    public GameObject cimaObj;
    public GameObject centroObj;
    public GameObject baixoObj;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject boolCard = Instantiate(Prefabs.instance.booleanVariableCard, baixoObj.transform);
            GameObject floatCard = Instantiate(Prefabs.instance.floatVariableCard, baixoObj.transform);
            GameObject intCard = Instantiate(Prefabs.instance.intVariableCard, baixoObj.transform);
            GameObject listCard = Instantiate(Prefabs.instance.listVariableCard, baixoObj.transform);
            GameObject nullCard = Instantiate(Prefabs.instance.nullVariableCard, baixoObj.transform);
            GameObject stringCard = Instantiate(Prefabs.instance.stringVariableCard, baixoObj.transform);

            boolCard.SetActive(false);
            floatCard.SetActive(false);
            intCard.SetActive(false);
            listCard.SetActive(false);
            nullCard.SetActive(false);
            stringCard.SetActive(false);

            deckCards.Add(boolCard);
            deckCards.Add(floatCard);
            deckCards.Add(intCard);
            deckCards.Add(listCard);
            deckCards.Add(nullCard);
            deckCards.Add(stringCard);
        }

        DrawCard(maxHandCards);
    }

    void DrawCard(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject chosenCard = deckCards[GameController.instance.seed.RandomInt(0, deckCards.Count - 1)];
            while (handCards.Contains(chosenCard))
            {
                chosenCard = deckCards[GameController.instance.seed.RandomInt(0, deckCards.Count - 1)];
            }
            handCards.Add(chosenCard);
            chosenCard.SetActive(true);
            chosenCard.transform.SetParent(baixoObj.transform.GetChild(0).GetChild(0));
        }
    }
}
