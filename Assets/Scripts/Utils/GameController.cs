using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public RandomSeed seed;
    void Awake()
    {
        instance = this;
        seed = new RandomSeed(42);
    }
    public string FormatNumber(double number)
    {
        if (number == 0)
            return "0";

        // Calcula o expoente (base 10)
        int exponent = (int)Math.Floor(Math.Log10(Math.Abs(number)));

        // Normaliza o número para [1,10)
        double mantissa = number / Math.Pow(10, exponent);

        // Formata: mantissa + "e" + expoente
        return mantissa.ToString($"F2") + "e" + exponent;
    }

    public Coroutine Wait(float seconds, Action action)
    {
        return StartCoroutine(WaitRoutine(seconds, action));
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
}
