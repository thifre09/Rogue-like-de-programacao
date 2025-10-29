using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static float timeScale = 1f;
    public float time = 1f;
    public RandomSeed seed;
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

    public static IEnumerator FreezeCam()
    {
        //yield return null;
        Camera.main.clearFlags = CameraClearFlags.Nothing;
        yield return null;
        Camera.main.cullingMask = 0;
    }

    public static void UnfreezeCam()
    {
        Camera.main.cullingMask = -1;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
    }

    internal static string FormatNumber(string n1)
    {
        throw new NotImplementedException();
    }
}
