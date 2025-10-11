using UnityEngine;
using UnityEngine.EventSystems;


public class ShowDescripition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovered;
    private bool canMove = false;
    private Vector2 originalPosition;
    private bool firstTime = true;

    void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (firstTime)
        {
            originalPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
            firstTime = false;
        }
        isHovered = true;
        canMove = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        var rectTransform = GetComponent<RectTransform>();
        if (isHovered)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            if (canMove)
            {
                LeanTween.cancel(gameObject); // Cancela qualquer animação anterior
                LeanTween.moveY(rectTransform, originalPosition.y + 50f, 0.5f).setEase(LeanTweenType.easeOutSine);
                canMove = false;
            }
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
            if (canMove)
            {
                LeanTween.cancel(gameObject); // Cancela qualquer animação anterior
                LeanTween.moveY(rectTransform, originalPosition.y, 0.5f).setEase(LeanTweenType.easeOutSine);
                canMove = false;
            }
        }
    }
}
