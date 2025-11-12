using System.Collections.Generic;
using UnityEngine;
public class VariableCardData
{
    public CardType cardType;
    public string description;
    public bool booleanValue;
    public float floatValue;
    public int integerValue;
    public List<object> listValue = new();
    public string stringValue;
    public int N1;
    public int N2;
    public int N3;

    public VariableCardData(CardType type)
    {
        cardType = type;
        StartCard();
    }

    public void StartCard()
    {
        void StartBoolean()
        {
            description = "A boolean variable that can hold true or false.";
            booleanValue = GameController.instance.seed.RandomInt(0, 1) == 1;
            N1 = 10;
            N2 = booleanValue ? 0 : 1;
            N3 = booleanValue ? 1 : 0;
        }
        void StartFloat()
        {
            description = "A float variable that can hold a decimal value.";
            floatValue = GameController.instance.seed.RandomInt(1, 9);
            N1 = (int)Mathf.Ceil(floatValue);
            N2 = 1;
            N3 = 0;
        }
        void StartInteger()
        {
            description = "An integer variable that can hold a whole number.";
            integerValue = GameController.instance.seed.RandomInt(1, 9);
            N1 = integerValue;
            N2 = 0;
            N3 = 1;
        }
        void StartList()
        {
            description = "A list variable that can hold multiple values.";
            int a = GameController.instance.seed.RandomInt(1, 9);
            for (int i = 0; i < a; i++)
            {
                int type = GameController.instance.seed.RandomInt(0, 3);
                if (type == 0)
                {
                    listValue.Add(GameController.instance.seed.RandomInt(1, 9)); // int
                }
                else if (type == 1)
                {
                    listValue.Add(GameController.instance.seed.RandomInt(1, 9)); // float
                }
                else
                {
                    int strLength = GameController.instance.seed.RandomInt(1, 9);
                    string strValue = "";
                    for (int j = 0; j < strLength; j++)
                    {
                        strValue += (char)GameController.instance.seed.RandomInt(97, 123);
                    }
                    listValue.Add(strValue); // string
                }
            }
            N1 = listValue.Count;
            N2 = 1;
            N3 = 0;
        }
        void StartNull()
        {
            description = "A null variable that represents the absence of a value.";
            N1 = 20;
            N2 = 1;
            N3 = 1;
        }
        void StartString()
        {
            description = "A string variable that can hold text.";
            int a = GameController.instance.seed.RandomInt(1, 9);
            for (int i = 0; i < a; i++)
            {
                stringValue += (char)GameController.instance.seed.RandomInt(97, 123);
            }
            N1 = stringValue.Length;
            N2 = 1;
            N3 = 0;
        }

        switch (cardType)
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
    }
}