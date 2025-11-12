using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

public class VariableCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Dados da Carta")]
    public VariableCardData data; // Referência aos dados da carta

    private bool isHovered;
    private bool firstTime = true;
    private RectTransform rectTransform;
    public bool canShowDescription = true;
    public Vector2 originalPosition;

    [Header("Index dos GameObjects Filhos")]

    public static int scoreGameObjectIndex = 0;
    public static int cardGameObjectIndex = 1;
    public static int descriptionGameObjectIndex = 2;
    public static int positionGameObjectIndex = 3;

    void Start()
    {
        StartVariable();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (firstTime)
        {
            originalPosition = GetComponent<RectTransform>().anchoredPosition;
            firstTime = false;
        }
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    void Update()
    {
        ShowDescription();
    }

    private void StartVariable()
    {
        void StartBoolean()
        {
            data.description = "A boolean variable that can hold true or false.";
            data.booleanValue = GameController.instance.seed.RandomInt(0, 1) == 1;
            data.N1 = 10;
            data.N2 = data.booleanValue ? 0 : 1;
            data.N3 = data.booleanValue ? 1 : 0;
        }
        void StartFloat()
        {
            data.description = "A float variable that can hold a decimal value.";
            data.floatValue = GameController.instance.seed.RandomInt(1, 9);
            data.N1 = (int)Mathf.Ceil(data.floatValue);
            data.N2 = 1;
            data.N3 = 0;
        }
        void StartInteger()
        {
            data.description = "An integer variable that can hold a whole number.";
            data.integerValue = GameController.instance.seed.RandomInt(1, 9);
            data.N1 = data.integerValue;
            data.N2 = 0;
            data.N3 = 1;
        }
        void StartList()
        {
            data.description = "A list variable that can hold multiple values.";
            int a = GameController.instance.seed.RandomInt(1, 9);
            for (int i = 0; i < a; i++)
            {
                int type = GameController.instance.seed.RandomInt(0, 3);
                if (type == 0)
                {
                    data.listValue.Add(GameController.instance.seed.RandomInt(1, 9)); // int
                }
                else if (type == 1)
                {
                    data.listValue.Add(GameController.instance.seed.RandomInt(1, 9)); // float
                }
                else
                {
                    int strLength = GameController.instance.seed.RandomInt(1, 9);
                    string strValue = "";
                    for (int j = 0; j < strLength; j++)
                    {
                        strValue += (char)GameController.instance.seed.RandomInt(97, 123);
                    }
                    data.listValue.Add(strValue); // string
                }
            }
            data.N1 = data.listValue.Count;
            data.N2 = 1;
            data.N3 = 0;
        }
        void StartNull()
        {
            data.description = "A null variable that represents the absence of a value.";
            data.N1 = 20;
            data.N2 = 1;
            data.N3 = 1;
        }
        void StartString()
        {
            data.description = "A string variable that can hold text.";
            int a = GameController.instance.seed.RandomInt(1, 9);
            for (int i = 0; i < a; i++)
            {
                data.stringValue += (char)GameController.instance.seed.RandomInt(97, 123);
            }
            data.N1 = data.stringValue.Length;
            data.N2 = 1;
            data.N3 = 0;
        }

        switch (data.cardType)
        {
            case CardType.Boolean:
                StartBoolean();
                break;
            case CardType.Float:
                StartFloat();
                break;
            case CardType.Integer:
                StartInteger();
                break;
            case CardType.List:
                StartList();
                break;
            case CardType.Null:
                StartNull();
                break;
            case CardType.String:
                StartString();
                break;
        }
        TMP_Text title = transform.GetChild(descriptionGameObjectIndex).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        title.text = data.cardType.ToString();

        TMP_Text valueN1 = transform.GetChild(descriptionGameObjectIndex).GetChild(1).GetComponent<TMP_Text>();
        valueN1.text = "N1: " + data.N1;

        TMP_Text valueN2e3 = transform.GetChild(descriptionGameObjectIndex).GetChild(2).GetComponent<TMP_Text>();
        valueN2e3.text = $"N2: {data.N2} N3: {data.N3}";

        TMP_Text desc = transform.GetChild(descriptionGameObjectIndex).GetChild(3).GetComponent<TMP_Text>();
        desc.text = data.description;

        transform.GetChild(descriptionGameObjectIndex).gameObject.SetActive(false);

        transform.GetChild(cardGameObjectIndex).GetComponent<Button>().onClick.AddListener(SelectCard);
    }
    
    public void SelectCard()
    {
        // if (CardController.instance.selectedCards.ContainsKey(data))
        // {
        //     CardController.instance.selectedCards.Remove(data);
        //     LeanTween.moveY(rectTransform, originalPosition.y, 0.5f).setEase(LeanTweenType.easeOutSine);
        //     transform.GetChild(positionGameObjectIndex).GetComponent<TMP_Text>().text = "";
        //     foreach (VariableCardData cardData in CardController.instance.selectedCards.Keys)
        //     {
        //         int index = CardController.instance.selectedCards.;
        //         card.transform.GetChild(positionGameObjectIndex).GetComponent<TMP_Text>().text = (index + 1).ToString();
        //     }
        // }
        // else if (!CardController.instance.selectedCards.Contains(data)
        //     && CardController.instance.selectedCards.Count < CardController.maxCardsPlayable
        //     && CardController.instance.handCards.Contains(data))
        // {
        //     CardController.instance.selectedCards.Add(gameObject);
        //     LeanTween.moveY(rectTransform, originalPosition.y + 50f, 0.5f).setEase(LeanTweenType.easeOutSine);
        //     transform.GetChild(positionGameObjectIndex).GetComponent<TMP_Text>().text = CardController.instance.selectedCards.Count.ToString();
        // }
    }

    private void ShowDescription()
    {
        // bool shouldShow = isHovered && CardController.instance.handCards.Contains(gameObject) && canShowDescription;
        // transform.GetChild(descriptionGameObjectIndex).gameObject.SetActive(shouldShow);
    }
}


