using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance;
    public static int maxHandCards = 6;
    public static int maxSelectedCards = 4;
    public List<VariableCardData> deckCards = new(); // All cards
    public List<VariableCardData> availableCards = new(); //All cards that can be drawn
    public OrderedDictionary selectedCards = new(); // Cards selected
    public List<FunctionScriptableObject> functionCards = new(); // Function cards
    
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

        InstantiateVariableCard(GameController.instance.variableCardsOnPlay, maxHandCards);
        GameController.instance.functionCardsOnPlay.transform.GetChild(0).GetComponent<FunctionCard>().data = functionCards[1];
    }

    public void InstantiateVariableCard(GameObject parent, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject cardPrefab = Instantiate(Prefabs.instance.variableCard, parent.transform);
            int dataIndex = GameController.instance.seed.RandomInt(0, availableCards.Count);
            cardPrefab.GetComponent<VariableCard>().data = availableCards[dataIndex];
            availableCards.RemoveAt(dataIndex);  
        }
    }

    public void InstantiateFunctionCard(GameObject parent)
    {
        FunctionScriptableObject functionScriptableObject = functionCards[GameController.instance.seed.RandomInt(0, functionCards.Count)];
        GameObject cardPrefab = Instantiate(Prefabs.instance.functionCard, parent.transform);
        cardPrefab.GetComponent<FunctionCard>().data = functionScriptableObject;
    }
}
