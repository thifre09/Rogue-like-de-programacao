using UnityEngine;
using UnityEngine.UI;

public class OrganizeHand : MonoBehaviour
{
    public float cardSize = 210f;
    private HorizontalLayoutGroup HLG;
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HLG = GetComponent<HorizontalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Organize();
    }

    void Organize()
    {
        int childrenCount = rectTransform.childCount;
        float spacing = cardSize * (1f / (childrenCount-1) * (childrenCount - 5));
        HLG.spacing = -spacing;
    }
}
