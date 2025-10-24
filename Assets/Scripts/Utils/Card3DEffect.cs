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
            Vector2 mousePos = Mouse.current.position.ReadValue();


            Vector3 mousePos3D = new(mousePos.x, mousePos.y, 300f);
            Debug.Log(mousePos3D.x + " , " + mousePos3D.y + " , " + mousePos3D.z);

            direction = (mousePos3D - transform.position).normalized;

            transform.rotation = Quaternion.LookRotation(new Vector3(-direction.x, -direction.y, direction.z), new Vector3(0f, 1f, 0f));
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1f;
        }
    }
}
