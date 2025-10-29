using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Legacy;
using UnityEngine;
using UnityEngine.UI;

public class PlayCards : MonoBehaviour
{
    public GameObject playedCardsParent;
    private readonly List<Vector2> playedCardsOriginalPosition = new();
    private readonly List<Vector2> handCardsPosition = new();
    public void PlaySelectedCards()
    {
        for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
        {
            GameObject card = CardController.instance.selectedCards[i];

            RectTransform rectTransform = card.GetComponent<RectTransform>();
            Vector2 originalPosition = rectTransform.position;
            playedCardsOriginalPosition.Add(originalPosition);

            OrganizeCards.instance.canOrganize = false;
            GameController.instance.Wait(0.5f + (0.5f * CardController.instance.selectedCards.Count), () =>
            {
                OrganizeCards.instance.canOrganize = true;
            });

            CardController.instance.handCards.Remove(card);
            card.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "";
            card.transform.SetParent(playedCardsParent.transform);

        }

        foreach (GameObject card in CardController.instance.handCards)
        {
            handCardsPosition.Add(card.GetComponent<RectTransform>().position);
        }

        StartCoroutine(GameController.FreezeCam());
        GameController.instance.Wait(0f, () =>
        {
            GameController.UnfreezeCam();
            for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
            {
                GameObject card = CardController.instance.selectedCards[i];
                RectTransform rectTransform = card.GetComponent<RectTransform>();
                Vector2 newPosition = rectTransform.position;
                Vector2 originalPosition = playedCardsOriginalPosition[i];

                rectTransform.position = playedCardsOriginalPosition[i];

                // Capture o valor de i em uma variável local
                int index = i;
                GameController.instance.Wait(0.5f * index + 0.5f, () =>
                {
                    LeanTween.move(card, newPosition, 0.5f * GameController.timeScale).setFrom(originalPosition).setEaseInOutCubic();
                });
            }

            for (int i = 0; i < CardController.instance.handCards.Count; i++)
            {
                GameObject card = CardController.instance.handCards[i];
                card.GetComponent<RectTransform>().position = handCardsPosition[i];
            }
            CardController.instance.selectedCards.Clear();

            GameController.instance.Wait(1.5f + (0.5f * playedCardsParent.transform.childCount), Score);
        });
    }

    void Score()
    {
        // Get all VariableCard components from children
        for (int i = 0; i < playedCardsParent.transform.childCount; i++)
        {
            Transform cardTransform = playedCardsParent.transform.GetChild(i);
            GameController.instance.Wait(3 * ((0.3f * GameController.timeScale) + 0.4f) * i, () =>
            {
                if (cardTransform.TryGetComponent<VariableCard>(out var variableCard))
                {
                    GameObject card = cardTransform.GetChild(3).gameObject;
                    Debug.Log(cardTransform.name);
                    Debug.Log(card.name);
                    card.SetActive(true);

                    card.GetComponent<TMP_Text>().color = new Color32(255, 40, 40, 255);
                    card.GetComponent<TMP_Text>().text = GameController.FormatNumber(cardTransform.GetComponent<VariableCard>().N1);
                    LeanTween.moveY(card, card.transform.position.y, 0.3f * GameController.timeScale)
                    .setFrom(card.transform.position.y - 100f).setEaseOutCubic();
                    GameController.instance.Wait(0.4f, () =>
                    {
                        ScoreController.N1 += variableCard.N1;
                        ScoreController.UpdateN1();
                    });

                    GameController.instance.Wait((0.3f * GameController.timeScale) + 0.4f, () =>
                    {
                        card.GetComponent<TMP_Text>().color = new Color32(40, 255, 40, 255);
                        card.GetComponent<TMP_Text>().text = GameController.FormatNumber(cardTransform.GetComponent<VariableCard>().N2);
                        LeanTween.moveY(card, card.transform.position.y, 0.3f * GameController.timeScale)
                        .setFrom(card.transform.position.y - 100f).setEaseOutCubic();
                        GameController.instance.Wait(0.4f, () =>
                        {
                            ScoreController.N2 += variableCard.N2;
                            ScoreController.UpdateN2();
                        });
                    });

                    GameController.instance.Wait(2 * ((0.3f * GameController.timeScale) + 0.4f), () =>
                    {
                        card.GetComponent<TMP_Text>().color = new Color32(40, 40, 255, 255);
                        card.GetComponent<TMP_Text>().text = GameController.FormatNumber(cardTransform.GetComponent<VariableCard>().N3);
                        LeanTween.moveY(card, card.transform.position.y, 0.3f * GameController.timeScale)
                        .setFrom(card.transform.position.y - 100f).setEaseOutCubic();
                        GameController.instance.Wait(0.4f, () =>
                        {
                            ScoreController.N3 += variableCard.N3;
                            ScoreController.UpdateN3();
                            card.SetActive(false);
                        });
                        ScoreController.UpdateTexts();
                    });
                }
            });

        }
    }
}
