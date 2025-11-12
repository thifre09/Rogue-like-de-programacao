using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance;
    public static int maxHandCards = 6;
    public static int maxCardsPlayable = 4;
    public List<VariableCardData> deckCards = new(); // All cards
    public List<VariableCardData> availableCards = new(); //All cards that can be drawn
    public Dictionary<VariableCardData, GameObject> handCards = new(); // Cards in hand
    public Dictionary<VariableCardData, GameObject> selectedCards = new(); // Cards selected

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
            VariableCardData booleanCardData = new(CardType.Boolean);
            VariableCardData floatCardData = new(CardType.Float);
            VariableCardData integerCardData = new(CardType.Integer);
            VariableCardData listCardData = new(CardType.List);
            VariableCardData nullCardData = new(CardType.Null);
            VariableCardData stringCardData = new(CardType.String);

            deckCards.Add(booleanCardData);
            deckCards.Add(floatCardData);
            deckCards.Add(integerCardData);
            deckCards.Add(listCardData);
            deckCards.Add(nullCardData);
            deckCards.Add(stringCardData);
            availableCards.Add(booleanCardData);
            availableCards.Add(floatCardData);
            availableCards.Add(integerCardData);
            availableCards.Add(listCardData);
            availableCards.Add(nullCardData);
            availableCards.Add(stringCardData);
        }

        DrawCard(maxHandCards);
    }

    public void DrawCard(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            VariableCardData chosenCard = availableCards[GameController.instance.seed.RandomInt(0, availableCards.Count - 1)];
            while (handCards.ContainsKey(chosenCard))
            {
                chosenCard = availableCards[GameController.instance.seed.RandomInt(0, availableCards.Count - 1)];
            }
            GameObject cardObj = Instantiate(Prefabs.instance.variableCard, baixoObj.transform.GetChild(0).GetChild(0));
            handCards.Add(chosenCard, cardObj);
        }
    }
}
