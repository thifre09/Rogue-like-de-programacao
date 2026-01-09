using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public static Prefabs instance;

    [Header("Cards")]
    public GameObject variableCard;
    public GameObject functionCard;
    void Awake()
    {
        instance = this;
    }
}
