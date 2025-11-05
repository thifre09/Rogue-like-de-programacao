using TMPro;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public static int problemScoreNeeded = 1000;
    public static int maxDiscards = 3;
    public static int discards = 3;
    public static int maxAttempts = 3;
    public static int attempts = 3;
    public static int money = 0;
    public static int round = 1;

    [Header("UI references")]
    public TMP_Text problemScoreNeededText;
    public TMP_Text discardsText;
    public TMP_Text attemptsText;
    public TMP_Text moneyText;
    public TMP_Text roundText;

    public void Start()
    {
        problemScoreNeededText.text = problemScoreNeeded.ToString();
        discardsText.text = discards.ToString();
        attemptsText.text = attempts.ToString();
        moneyText.text = money.ToString();
        roundText.text = round.ToString();
    }
}
