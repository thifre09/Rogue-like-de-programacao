using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayCards : MonoBehaviour
{
    public void PlaySelectedCards()
    {
        transform.GetComponent<Button>().interactable = false;
        MatchController.attempts--;
        MatchController.instance.UpdateUI();
        GameController.instance.variableCardsOnPlay.GetComponent<OrganizeCards>().canOrganize = false;
        GameController.instance.playedCards.GetComponent<OrganizeCards>().canOrganize = false;
        MoveCards(() =>
        {
            Score(() =>
            {
                PosScoreSetup();
            });
        });
    }

    void MoveCards(Action onComplete = null)
    {
        foreach (GameObject variableCard in CardController.instance.selectedCards.Values)
        {
            variableCard.transform.SetParent(GameController.instance.playedCards.transform);
            variableCard.transform.GetChild(0).GetChild(VariableCard.selectedCardNumberIndex).gameObject.SetActive(false);
        }

        List<Vector3> positions = GameController.instance.playedCards.GetComponent<OrganizeCards>().GetTargetPositions();
        int completed = 0;
        for (int i = 0; i < GameController.instance.playedCards.transform.childCount; i++)
        {
            Transform card = GameController.instance.playedCards.transform.GetChild(i);
            int index = i;
            LeanTween.move(card.gameObject, positions[index], 0.5f).setEaseInOutBack()
            .setDelay(index * 0.5f).setOnComplete(() =>
            {
                completed++;
                if (completed >= GameController.instance.playedCards.transform.childCount)
                    onComplete?.Invoke();

            });
        }
    }

    void Score(Action onComplete = null)
    {
        void AnimateScoreText(GameObject card, ColorType colorType, Action onComplete)
        {
            GameObject text = card.transform.GetChild(0).GetChild(VariableCard.scoreTextIndex).gameObject;          
            GameController.instance.Wait(0.1f, () => {
                Vector3 pos = text.transform.localPosition;
                text.transform.localPosition = new Vector3(pos.x, 0, pos.z);

                text.SetActive(true);
                text.GetComponent<DefaultColors>().color = colorType;
                if (colorType == ColorType.Red)
                    text.GetComponent<TMP_Text>().text = card.GetComponent<VariableCard>().data.N1.ToString();
                else if (colorType == ColorType.Green)
                    text.GetComponent<TMP_Text>().text = card.GetComponent<VariableCard>().data.N2.ToString();
                else if (colorType == ColorType.Blue)
                    text.GetComponent<TMP_Text>().text = card.GetComponent<VariableCard>().data.N3.ToString();

                LeanTween.moveLocalY(text, pos.y, 0.4f)
                .setEaseOutCubic().setOnComplete(() => {
                    if (colorType == ColorType.Red)
                        ScoreController.N1+= card.GetComponent<VariableCard>().data.N1;
                    else if (colorType == ColorType.Green)
                        ScoreController.N2 += card.GetComponent<VariableCard>().data.N2;
                    else if (colorType == ColorType.Blue)
                        ScoreController.N3 += card.GetComponent<VariableCard>().data.N3;

                    ScoreController.UpdateTexts();
                    onComplete?.Invoke();
                });
            });    
        }

        int completed = 0;
        for (int i = 0; i < GameController.instance.playedCards.transform.childCount; i++)
        {
            int index = i;
            Transform card = GameController.instance.playedCards.transform.GetChild(i);
            LeanTween.scale(card.gameObject, card.localScale * 1.2f, 0.2f).setDelay(index * (2 * 0.1f + 3 * 0.6f))
            .setEaseInBack().setOnComplete(() =>
            {
                AnimateScoreText(card.gameObject, ColorType.Red, () =>
                {
                    AnimateScoreText(card.gameObject, ColorType.Green, () =>
                    {
                        AnimateScoreText(card.gameObject, ColorType.Blue, () =>
                        {
                            completed++;
                            card.transform.GetChild(0).GetChild(VariableCard.scoreTextIndex).gameObject.SetActive(false);
                            LeanTween.scale(card.gameObject, card.localScale / 1.2f, 0.2f).setEaseInBack();
                            if (completed >= GameController.instance.playedCards.transform.childCount)
                            {
                                ScoreController.CaulculateScore();
                                ScoreController.UpdateTexts();
                                GameController.instance.Wait(0.5f, () =>
                                {
                                    onComplete?.Invoke();
                                });                               
                            }
                        });
                    });
                });
            });
        }
    }

    void PosScoreSetup(Action onComplete = null)
    {
        int completed = 0;
        for (int i = 0; i < GameController.instance.playedCards.transform.childCount; i++)
        {
            int index = i;
            Transform card = GameController.instance.playedCards.transform.GetChild(index);
            LeanTween.scale(card.gameObject, Vector3.zero, 0.5f).setDelay(index * 0.3f).setEaseInBack()
            .setOnComplete(() =>
            {
                Destroy(card.gameObject);
                completed++;
                if (completed >= CardController.instance.selectedCards.Count)
                {
                    CardController.instance.InstantiateVariableCard(GameController.instance.variableCardsOnPlay, CardController.instance.selectedCards.Count);
                    CardController.instance.selectedCards.Clear();
                    GameController.instance.variableCardsOnPlay.GetComponent<OrganizeCards>().canOrganize = true;
                    GameController.instance.playedCards.GetComponent<OrganizeCards>().canOrganize = true;
                    transform.GetComponent<Button>().interactable = true;
                    ScoreController.ResetScores();
                    onComplete?.Invoke();
                }
            });     
        }
    }

    void VerifyWin()
    {
        if (ScoreController.score >= MatchController.problemScoreNeeded)
        {
            Debug.Log("You win!");
        }
        else if (MatchController.attempts <= 0)
        {
            Debug.Log("You lose!");
        }
        else 
        {
            Debug.Log("Continue playing!");
        }
    }
}