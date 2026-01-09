// using System.Diagnostics;
// using System.Text.RegularExpressions;
// using UnityEngine;

// [System.Serializable]
// public class CondicaoF
// {
//     public bool compareToVariable;
//     public OperatorType operatorType;
//     public UsefulVariables value1;
//     public UsefulVariables value2;
//     public int compareValue;

//     public int ReturnVariable(UsefulVariables usefulVariable)
//     {
//         switch (value1)
//         {
//             case UsefulVariables.Round:
//                 return MatchController.round;
//             case UsefulVariables.MaxDiscards:
//                 return MatchController.maxDiscards;
//             case UsefulVariables.Discards:
//                 return MatchController.discards;
//             case UsefulVariables.MaxAttempts:
//                 return MatchController.maxAttempts;
//             case UsefulVariables.Attempts:
//                 return MatchController.attempts;
//             case UsefulVariables.Money:
//                 return MatchController.money;
//             case UsefulVariables.HandSize:
//                 return CardController.maxHandCards;
//             case UsefulVariables.SelectedCards:
//                 return CardController.instance.selectedCards.Count;
//             case UsefulVariables.ScoreNeeded:
//                 return MatchController.problemScoreNeeded;
//             case UsefulVariables.N1:
//                 return (int)ScoreController.N1;
//             case UsefulVariables.N2:
//                 return (int)ScoreController.N2;
//             case UsefulVariables.N3:
//                 return (int)ScoreController.N3;
//             default:
//                 UnityEngine.Debug.LogError("Variável útil não reconhecida!");
//                 return -1;
//         }
//     }
// }
