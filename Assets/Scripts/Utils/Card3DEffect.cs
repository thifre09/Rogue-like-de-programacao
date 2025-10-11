using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card3DEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovered;
    public void OnPointerEnter(PointerEventData eventData) => isHovered = true;
    public void OnPointerExit(PointerEventData eventData) => isHovered = false;
    void a()
    {
        if (isHovered)
        {
            
        }
    }


}
