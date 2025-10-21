using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card3DEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovered;
    Vector3 direction;
    public void OnPointerEnter(PointerEventData eventData) => isHovered = true;
    public void OnPointerExit(PointerEventData eventData) => isHovered = false;
    void Update()
    {
        if (isHovered)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                gameObject.GetComponent<RectTransform>(),
                mousePos,
                null, // para Screen Space Overlay
                out Vector2 localMousePos
            );

            Vector3 localMousePos3D = new Vector3(localMousePos.x, localMousePos.y, 1000f);
            Debug.Log(localMousePos3D.x + " , " + localMousePos3D.y + " , " + localMousePos3D.z);

            direction = (localMousePos3D - transform.localPosition).normalized;

            transform.rotation = Quaternion.LookRotation(direction, transform.up);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);   
        }
    }

    void OnDrawGizmos()
    {
        if (isHovered)
        {
            Gizmos.color = Color.red;
            Vector3 start = transform.position;
            Vector3 end = start + direction * 100f; // Multiply by some length to make it visible
            Gizmos.DrawLine(start, end);
            // Draw an arrow head
            Gizmos.DrawWireSphere(end, 5f);
        }
    }

}
