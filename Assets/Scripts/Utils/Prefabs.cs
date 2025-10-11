using UnityEngine;

public class Prefabs : MonoBehaviour
{
    [Header("Variables")]
    public GameObject booleanVariableCard;
    
    public GameObject floatVariableCard;
    public GameObject intVariableCard;
    public GameObject listVariableCard;
    public GameObject nullVariableCard;
    public GameObject stringVariableCard;
    
    public static Prefabs instance;
    void Awake()
    {
        instance = this;
    }
}
