using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card3DEffect : MonoBehaviour
{
    public bool isHovered;
    Vector3 direction;

    void Update()
    {
        if (isHovered)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 MouseWorld = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 mousePos3D = new(MouseWorld.x, MouseWorld.y, 2f);
            direction = (mousePos3D - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(-direction.x, -direction.y, direction.z), new Vector3(0f, 1f, 0f));

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }
    }

    public void OnMouseEnter()
    {
        isHovered = true;
    }
    public void OnMouseExit()
    {
        isHovered = false;
    }
}
