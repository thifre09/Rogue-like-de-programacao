using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class VariableCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int N1 { get; set; }
    public abstract int N2 { get; set; }
    public abstract int N3 { get; set; }

    private bool isHovered;
    private Vector2 originalPosition;
    private bool firstTime = true;
    RectTransform rectTransform;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (firstTime)
        {
            originalPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
            firstTime = false;
        }
        isHovered = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ShowDescription();
    }

    protected void StartVariable()
    {
        rectTransform = GetComponent<RectTransform>();

        TMP_Text title = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        title.text = Name;

        TMP_Text valueN1 = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        valueN1.text = "N1: " + N1;

        TMP_Text valueN2e3 = transform.GetChild(1).GetChild(2).GetComponent<TMP_Text>();
        valueN2e3.text = "N2: " + N2 + " N3: " + N3;

        TMP_Text description = transform.GetChild(1).GetChild(3).GetComponent<TMP_Text>();
        description.text = Description;

        transform.GetChild(1).gameObject.SetActive(false);

        transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(SelectCard);
    }

    public void SelectCard()
    {
        if (CardController.instance.selectedCards.Contains(gameObject))
        {
            CardController.instance.selectedCards.Remove(gameObject);
            LeanTween.cancel(gameObject); // Cancela qualquer animação anterior
            LeanTween.moveY(rectTransform, originalPosition.y, 0.5f).setEase(LeanTweenType.easeOutSine);
            transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "";
            foreach (GameObject card in CardController.instance.selectedCards)
            {
                int index = CardController.instance.selectedCards.IndexOf(card);
                card.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = (index + 1).ToString();
            }
        }
        else if (!CardController.instance.selectedCards.Contains(gameObject) && CardController.instance.selectedCards.Count < CardController.instance.maxCardsPlayable)
        {
            CardController.instance.selectedCards.Add(gameObject);
            LeanTween.cancel(gameObject); // Cancela qualquer animação anterior
            LeanTween.moveY(rectTransform, originalPosition.y + 50f, 0.5f).setEase(LeanTweenType.easeOutSine);
            transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = CardController.instance.selectedCards.Count.ToString();
        }
    }

    public void ShowDescription()
    {
        if (isHovered)
        {
            transform.GetChild(1).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);

        }
    }
}
