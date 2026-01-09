using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TMP_Text))]
public class DefaultColors : MonoBehaviour
{
    public ColorsScriptableObject CSO;
    public TMP_Text textComponent;
    public ColorType color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchColor(color);
    }

    void SwitchColor(ColorType color)
    {
        switch (color)
        {
            case ColorType.Red:
                textComponent.color = CSO.red;
                break;
            case ColorType.Blue:
                textComponent.color = CSO.blue;
                break;
            case ColorType.Green:
                textComponent.color = CSO.green;
                break;
            case ColorType.Yellow:
                textComponent.color = CSO.yellow;
                break;
            case ColorType.Black:
                textComponent.color = CSO.black;
                break;
            case ColorType.White:
                textComponent.color = CSO.white;
                break;
        }
    }
}
