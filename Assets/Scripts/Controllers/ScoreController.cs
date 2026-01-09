using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static float score = 0f;
    public static float N1 = 0f;
    public static float N2 = 1f;
    public static float N3 = 1f;
    public static TMP_Text scoreText;
    public static TMP_Text N1Text;
    public static TMP_Text N2Text;
    public static TMP_Text N3Text;
    public TMP_Text scoreT;
    public TMP_Text N1T;
    public TMP_Text N2T;
    public TMP_Text N3T;

    void Start()
    {
        scoreText = scoreT;
        N1Text = N1T;
        N2Text = N2T;
        N3Text = N3T;
        UpdateTexts();
    }
    public static void UpdateTexts()
    {
        scoreText.text = GameController.FormatNumber(score);
        N1Text.text = GameController.FormatNumber(N1);
        N2Text.text = GameController.FormatNumber(N2);
        N3Text.text = GameController.FormatNumber(N3);
    }

    public static void CaulculateScore()
    {
        score += N1 * N2 * N3;
    }

    public static void ResetScores()
    {
        N1 = 0f;
        N2 = 1f;
        N3 = 1f;
        UpdateTexts();
    }

    public static void ResetAll()
    {
        score = 0f;
        N1 = 0f;
        N2 = 1f;
        N3 = 1f;
        UpdateTexts();
    }
}
