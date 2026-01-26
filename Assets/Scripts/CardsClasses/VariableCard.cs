using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Lean.Localization;

public class VariableCard : MonoBehaviour
{
    [Header("Dados da Carta")]
    public VariableCardData data; // Referência aos dados da carta

    public bool canShowDescription = true;

    [Header("Index dos GameObjects Filhos")]
    public static int scoreTextIndex = 0;
    public static int cardSpiteIndex = 1;
    public static int descriptionGameObjectIndex = 2;
    public static int selectedCardNumberIndex = 3;
    

    public void Start()
    {
        ChangeInformation();
    }

    void Update()
    {
    }

    public void OnMouseDown()
    {
        SelectCard();
    }

    public void OnMouseEnter()
    {
        GetCanvas().GetChild(descriptionGameObjectIndex).gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        GetCanvas().GetChild(descriptionGameObjectIndex).gameObject.SetActive(false);
    }

    public void SelectCard()
    {
        if (CardController.instance.selectedCards.Contains(data))
        {
            LeanTween.cancel(gameObject);
            LeanTween.moveLocalY(gameObject, 0f, 0.5f);
            CardController.instance.selectedCards.Remove(data);
            GetCanvas().GetChild(selectedCardNumberIndex).gameObject.SetActive(false);
            for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
            {
                GameObject selectedCard = (GameObject)CardController.instance.selectedCards[i];
                selectedCard.transform.GetChild(0).GetChild(selectedCardNumberIndex).GetComponent<TMP_Text>().text = (i + 1).ToString();
            }
        }
        else if (CardController.instance.selectedCards.Count >= 4) 
        {
            return;
        }
        else
        {
            LeanTween.moveLocalY(gameObject, 0.5f, 0.5f);
            CardController.instance.selectedCards.Add(data, gameObject);
            GetCanvas().GetChild(selectedCardNumberIndex).gameObject.SetActive(true);
            GetCanvas().GetChild(selectedCardNumberIndex).GetComponent<TMP_Text>().text = CardController.instance.selectedCards.Count.ToString();
        }
    }
    
    private void ChangeInformation()
    {
        GetCanvas().GetChild(cardSpiteIndex).GetComponent<Image>().color = data.color;
        TMP_Text cardText = transform.GetChild(0).GetChild(cardSpiteIndex).GetChild(0).GetComponentInChildren<TMP_Text>();
        switch(data.cardType)
        {
            case CardType.Boolean:
                cardText.text = "BOOL";
                break;
            case CardType.Float:
                cardText.text = "FLOAT";
                break;
            case CardType.Integer:
                cardText.text = "INT";
                break;
            case CardType.List:
                cardText.text = "LIST";
                break;
            case CardType.Null:
                cardText.text = "NULL";
                break;
            case CardType.String:
                cardText.text = "STR";
                break;
        }

        GetCanvas().GetChild(descriptionGameObjectIndex).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = data.cardType.ToString();
        GetCanvas().GetChild(descriptionGameObjectIndex).GetChild(1).GetComponent<TMP_Text>().text = data.N1.ToString();
        GetCanvas().GetChild(descriptionGameObjectIndex).GetChild(2).GetComponent<LeanLocalizedTextMeshProUGUI>().TranslationName = data.descriptionTranslationName;
    }

    private Transform GetCanvas()
    {
        return transform.GetChild(0);
    }
}


