using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Layout/Instant Horizontal Layout Group", 151)]
public class InstantHorizontalLayoutGroup : HorizontalLayoutGroup
{
    /// <summary>
    /// Recalcula o layout imediatamente, no mesmo frame.
    /// </summary>
    public void RebuildImmediate()
    {
        if (!isActiveAndEnabled)
            return;

        // Garante que a lista de filhos está atualizada
        rectChildren.Clear();
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            RectTransform child = rectTransform.GetChild(i) as RectTransform;
            if (child == null || !child.gameObject.activeInHierarchy)
                continue;

            rectChildren.Add(child);
        }

        // Chama o pipeline completo manualmente
        CalculateLayoutInputHorizontal();
        CalculateLayoutInputVertical();

        SetLayoutHorizontal();
        SetLayoutVertical();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        RebuildImmediate();
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        RebuildImmediate();
    }
#endif
}
