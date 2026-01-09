using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OrganizeCards : MonoBehaviour
{
    public static OrganizeCards instance;

    public bool canOrganize = true;

    [Header("Layout")]
    public float cardSize = 1.5f;
    public float spacing = 0.2f;
    public int maxCardsWithoutOverlap = 6;
    public float smoothSpeed = 10f;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (canOrganize)
            Organize();
    }

    public List<Vector3> Organize()
    {
        int cardCount = transform.childCount;
        List<Vector3> positions = new(cardCount);
        if (cardCount == 0) return positions;

        float usedSpacing = spacing;

        if (cardCount > maxCardsWithoutOverlap)
        {
            float maxWidth = (maxCardsWithoutOverlap - 1) * (cardSize + spacing);
            usedSpacing = (maxWidth / (cardCount - 1)) - cardSize;
        }

        float totalWidth = (cardCount - 1) * (cardSize + usedSpacing);
        float startX = -totalWidth / 2f;

        for (int i = 0; i < cardCount; i++)
        {
            Transform card = transform.GetChild(i);
            float targetX = startX + i * (cardSize + usedSpacing);
            Vector3 pos = card.localPosition;
            pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * smoothSpeed);
            card.localPosition = pos;
            positions.Add(card.localPosition);
        }

        return positions;
    }

    // Retorna as posições alvo para cada filho sem modificar seus transforms
    public List<Vector3> GetTargetPositions()
    {
        int cardCount = transform.childCount;
        List<Vector3> positions = new(cardCount);
        if (cardCount == 0) return positions;

        float usedSpacing = spacing;

        if (cardCount > maxCardsWithoutOverlap)
        {
            float maxWidth = (maxCardsWithoutOverlap - 1) * (cardSize + spacing);
            usedSpacing = (maxWidth / (cardCount - 1)) - cardSize;
        }

        float totalWidth = (cardCount - 1) * (cardSize + usedSpacing);
        float startX = -totalWidth / 2f;

        for (int i = 0; i < cardCount; i++)
        {
            Transform card = transform.GetChild(i);
            float targetX = startX + i * (cardSize + usedSpacing);
            Vector3 pos = card.localPosition;
            pos.x = targetX;
            pos.y = 0f;
            positions.Add(pos);
        }

        return positions;
    }
}
