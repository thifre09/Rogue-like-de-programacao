// using System;
// using System.Collections.Generic;
// using TMPro;
// using UnityEditor.ShaderGraph.Legacy;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayCards : MonoBehaviour
// {
//     public GameObject playedCardsParent;
//     private readonly List<Vector2> playedCardsOriginalPosition = new();
//     private readonly List<Vector2> handCardsPosition = new();
//     public void PlaySelectedCards()
//     {
//         playedCardsOriginalPosition.Clear();
//         handCardsPosition.Clear();
//         MatchController.attempts--;
//         for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
//         {
//             GameObject card = CardController.instance.selectedCards[i];
//             LeanTween.cancel(card, true);
//             CardController.instance.availableCards.Remove(card);
//         }
//         gameObject.GetComponent<Button>().interactable = false;
//         for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
//         {
//             GameObject card = CardController.instance.selectedCards[i];

//             RectTransform rectTransform = card.GetComponent<RectTransform>();
//             Vector2 originalPosition = rectTransform.position;
//             playedCardsOriginalPosition.Add(originalPosition);

//             OrganizeCards.instance.canOrganize = false;
//             GameController.instance.Wait(0.5f + (0.5f * CardController.instance.selectedCards.Count), () =>
//             {
//                 OrganizeCards.instance.canOrganize = true;
//             });

//             CardController.instance.handCards.Remove(card);
//             card.transform.GetChild(VariableCard.positionGameObjectIndex).gameObject.GetComponent<TMP_Text>().text = "";
//             card.transform.SetParent(playedCardsParent.transform);
//         }

//         foreach (GameObject card in CardController.instance.handCards)
//         {
//             handCardsPosition.Add(card.GetComponent<RectTransform>().position);
//             card.GetComponent<VariableCard>().canShowDescription = false;
//         }

//         GameController.instance.Wait(0f, () =>
//         {
//             for (int i = 0; i < CardController.instance.selectedCards.Count; i++)
//             {
//                 GameObject card = CardController.instance.selectedCards[i];
//                 RectTransform rectTransform = card.GetComponent<RectTransform>();
//                 Vector2 newPosition = rectTransform.position;
//                 Vector2 originalPosition = playedCardsOriginalPosition[i];

//                 rectTransform.position = playedCardsOriginalPosition[i];

//                 // Capture o valor de i em uma variável local
//                 int index = i;
//                 GameController.instance.Wait(0.5f * index + 0.5f, () =>
//                 {
//                     LeanTween.move(card, newPosition, 0.5f * GameController.timeScale).setFrom(originalPosition).setEaseInOutCubic();
//                 });
//             }

//             for (int i = 0; i < CardController.instance.handCards.Count; i++)
//             {
//                 GameObject card = CardController.instance.handCards[i];
//                 card.GetComponent<RectTransform>().position = handCardsPosition[i];
//             }
//             CardController.instance.selectedCards.Clear();

//             GameController.instance.Wait(1.5f + (0.5f * playedCardsParent.transform.childCount), Score);
//         });
//     }

//     void Score()
//     {
//         for (int i = 0; i < playedCardsParent.transform.childCount; i++)
//         {
//             // Captura local para evitar bug de referência dentro das lambdas
//             Transform currentCard = playedCardsParent.transform.GetChild(i);

//             // Delay baseado no índice da carta
//             float delay = 3 * 0.45f * i;

//             GameController.instance.Wait(delay, () =>
//             {
//                 if (currentCard.TryGetComponent<VariableCard>(out var variableCard))
//                 {
//                     LeanTween.scale(currentCard.gameObject, currentCard.localScale * 1.1f, 0.2f).setEaseInBack();

//                     GameObject scoreTextObject = currentCard.GetChild(VariableCard.scoreGameObjectIndex).gameObject;
//                     TMP_Text text = scoreTextObject.GetComponent<TMP_Text>();

//                     scoreTextObject.SetActive(true);

//                     // Função local auxiliar para animar e atualizar pontuação
//                     void AnimateStep(Color32 color, float value, Action onComplete)
//                     {
//                         text.color = color;
//                         text.text = GameController.FormatNumber(value);
//                         LeanTween.moveY(scoreTextObject, scoreTextObject.transform.position.y, 0.3f)
//                             .setFrom(scoreTextObject.transform.position.y - 100f)
//                             .setEaseOutCubic()
//                             .setOnComplete(onComplete);
//                     }

//                     // --- Sequência de animações ---
//                     AnimateStep(new Color32(255, 40, 40, 255), variableCard.data.N1, () =>
//                     {
//                         ScoreController.N1 += variableCard.data.N1;
//                         ScoreController.UpdateN1();

//                         GameController.instance.Wait(0.1f, () =>
//                         {
//                             AnimateStep(new Color32(40, 255, 40, 255), variableCard.data.N2, () =>
//                             {
//                                 ScoreController.N2 += variableCard.data.N2;
//                                 ScoreController.UpdateN2();

//                                 GameController.instance.Wait(0.1f, () =>
//                                 {
//                                     AnimateStep(new Color32(40, 40, 255, 255), variableCard.data.N3, () =>
//                                     {
//                                         ScoreController.N3 += variableCard.data.N3;
//                                         ScoreController.UpdateN3();
//                                         ScoreController.UpdateTexts();

//                                         GameController.instance.Wait(0.2f, () =>
//                                         {
//                                             scoreTextObject.SetActive(false);
//                                             LeanTween.scale(currentCard.gameObject, currentCard.localScale / 1.1f, 0.2f).setEaseInBack();
//                                         });
//                                     });
//                                 });
//                             });
//                         });
//                     });
//                 }
//             });
//         }

//         GameController.instance.Wait(3 * 0.5f * playedCardsParent.transform.childCount, () =>
//         {
//             ScoreController.CaulculateScore();
//             ScoreController.UpdateScoreText();
//             GameController.instance.Wait(0.5f, () =>
//             {
//                 int childCount = playedCardsParent.transform.childCount;
//                 for (int i = 0; i < childCount; i++)
//                 {
//                     Transform cardTransform = playedCardsParent.transform.GetChild(0);
//                     LeanTween.scale(cardTransform.gameObject, Vector3.zero, 0.5f).setEaseInBack();
//                     cardTransform.SetParent(CardController.instance.discartedCardsContainer.transform);
//                 }
//                 GameController.instance.Wait(0.8f, () =>
//                 {
//                     VerifyWin();
//                 });
//             });

//         });
//     }

//     void VerifyWin()
//     {
//         ScoreController.N1 = 0;
//         ScoreController.N2 = 1;
//         ScoreController.N3 = 1;
//         ScoreController.UpdateTexts();
//         if (ScoreController.score >= MatchController.problemScoreNeeded) //Win
//         {
//             GameController.instance.postRoundInformation.SetActive(true);
//             LeanTween.moveY(GameController.instance.postRoundInformation, GameController.instance.postRoundInformation.transform.position.y, 0.5f)
//             .setFrom(GameController.instance.postRoundInformation.transform.position.y)
//             .setEaseInBack();
//         }
//         else //Not win
//         {
//             CardController.instance.DrawCard(CardController.maxHandCards - CardController.instance.handCards.Count);
//             gameObject.GetComponent<Button>().interactable = true;
//             foreach (GameObject card in CardController.instance.handCards)
//             {
//                 card.GetComponent<VariableCard>().canShowDescription = true;
//             }
//         }
//     }

// }

