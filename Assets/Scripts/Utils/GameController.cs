using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static float timeScale = 1f;
    public float time = 1f;
    public RandomSeed seed;
    [Header("Referência da UI")]
    public GameObject mainGame;
    public GameObject store;
    public GameObject startMenu;
    public GameObject postRoundInformation;
    void Awake()
    {
        instance = this;
        seed = new RandomSeed(42);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
        }

        timeScale = time;
    }

    public static string FormatNumber(double number)
    {
        if (number == 0)
            return "0";

        if (number < 100000)
            return number.ToString();

        // Calcula o expoente (base 10)
        int exponent = (int)Math.Floor(Math.Log10(Math.Abs(number)));

        // Normaliza o número para [1,10)
        double mantissa = number / Math.Pow(10, exponent);

        // Formata: mantissa + "e" + expoente
        return mantissa.ToString($"F2") + "e" + exponent;
    }

    public Coroutine Wait(float seconds, Action action)
    {
        return StartCoroutine(WaitRoutine(seconds * timeScale, action));
    }

    private IEnumerator WaitRoutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

    public Coroutine WaitRealTime(float seconds, Action action)
    {
        return StartCoroutine(WaitRoutineRealTime(seconds, action));
    }

    private IEnumerator WaitRoutineRealTime(float seconds, Action action)
    {
        yield return new WaitForSecondsRealtime(seconds);
        action?.Invoke();
    }

    public void GoToStore()
    {
        
        LeanTween.moveY(mainGame, -Screen.height - mainGame.GetComponent<RectTransform>().rect.height, 0.5f).setEaseInBack();
        LeanTween.moveY(postRoundInformation, -Screen.height - postRoundInformation.GetComponent<RectTransform>().rect.height, 0.5f).setEaseInBack().setOnComplete(() =>
        {    
            store.SetActive(true);
            LeanTween.moveY(store, store.transform.position.y, 1f).setFrom(-Screen.height - store.GetComponent<RectTransform>().rect.height).setEaseOutBack();
            mainGame.SetActive(false);
            postRoundInformation.SetActive(false);
        });
    }
}
