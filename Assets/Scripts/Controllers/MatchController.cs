using TMPro;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public static MatchController instance;
    public static int problemScoreNeeded = 500;
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
        instance = this;
        problemScoreNeededText.text = problemScoreNeeded.ToString();
        discardsText.text = discards.ToString();
        attemptsText.text = attempts.ToString();
        moneyText.text = money.ToString();
        roundText.text = round.ToString();
    }

    public void UpdateUI()
    {
        problemScoreNeededText.text = problemScoreNeeded.ToString();
        discardsText.text = discards.ToString();
        attemptsText.text = attempts.ToString();
        moneyText.text = money.ToString();
        roundText.text = round.ToString();
    }

    public void NextRound()
    {
        // 500 -> 1000 -> 2000 -> 6000 -> 18.000 -> 72.000 -> 288.000
        int multiplier = 2;
        for (int i = 0; i < round; i++)
        {
            if (i % 2 == 0)
            {
                multiplier += 1;
            }
        }
        problemScoreNeeded *= multiplier;
        round++;
        discards = maxDiscards;
        attempts = maxAttempts;
        UpdateUI();
    }
}
