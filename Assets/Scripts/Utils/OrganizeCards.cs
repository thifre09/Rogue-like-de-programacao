using UnityEngine;
using UnityEngine.UI;

public class OrganizeCards : MonoBehaviour
{
    public static OrganizeCards instance;
    public bool canOrganize = true;
    public float cardSize = 210f;
    private HorizontalLayoutGroup HLG;
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        HLG = GetComponent<HorizontalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canOrganize)
            Organize();
    }

    void Organize()
    {
        int childrenCount = rectTransform.childCount;
        float spacing = cardSize * (1f / (childrenCount - 1) * (childrenCount - 5));
        if (childrenCount == 1) spacing = 0;
        if (HLG.transform.childCount < 5)
        {
            spacing = (spacing * (HLG.transform.childCount - 1) * -1) - HLG.transform.childCount * 10;
        }
        HLG.spacing = -spacing;
    }
}
