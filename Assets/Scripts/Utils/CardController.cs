using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance;
    public static int maxHandCards = 6;
    public static int maxCardsPlayable = 4;
    public List<GameObject> functionCards = new();
    public List<GameObject> deckCards = new();
    public List<GameObject> availableCards = new();
    public List<GameObject> handCards = new();
    public List<GameObject> selectedCards = new();

    [Header("Referências de UI")]
    public GameObject cimaObj;
    public GameObject centroObj;
    public GameObject baixoObj;
    public GameObject variableCardsContainer;
    public GameObject discartedCardsContainer;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject boolCard = Instantiate(Prefabs.instance.booleanVariableCard, variableCardsContainer.transform);
            GameObject floatCard = Instantiate(Prefabs.instance.floatVariableCard, variableCardsContainer.transform);
            GameObject intCard = Instantiate(Prefabs.instance.intVariableCard, variableCardsContainer.transform);
            GameObject listCard = Instantiate(Prefabs.instance.listVariableCard, variableCardsContainer.transform);
            GameObject nullCard = Instantiate(Prefabs.instance.nullVariableCard, variableCardsContainer.transform);
            GameObject stringCard = Instantiate(Prefabs.instance.stringVariableCard, variableCardsContainer.transform);

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
            availableCards.Add(boolCard);
            availableCards.Add(floatCard);
            availableCards.Add(intCard);
            availableCards.Add(listCard);
            availableCards.Add(nullCard);
            availableCards.Add(stringCard);
        }

        DrawCard(maxHandCards);
    }

    public void DrawCard(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject chosenCard = availableCards[GameController.instance.seed.RandomInt(0, availableCards.Count - 1)];
            while (handCards.Contains(chosenCard))
            {
                chosenCard = availableCards[GameController.instance.seed.RandomInt(0, availableCards.Count - 1)];
            }
            handCards.Add(chosenCard);
            chosenCard.SetActive(true);
            chosenCard.transform.SetParent(baixoObj.transform.GetChild(0).GetChild(0));
        }
    }
}
