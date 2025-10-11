using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class VariableCard : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int N1 { get; set; }
    public abstract int N2 { get; set; }
    public abstract int N3 { get; set; }

    protected void ChangeDescription()
    {
        TMP_Text title = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        title.text = Name;

        TMP_Text valueN1 = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        valueN1.text = "N1: " + N1;

        TMP_Text valueN2e3 = transform.GetChild(1).GetChild(2).GetComponent<TMP_Text>();
        valueN2e3.text = "N2: " + N2 + " N3: " + N3;

        TMP_Text description = transform.GetChild(1).GetChild(3).GetComponent<TMP_Text>();
        description.text = Description;
    }
}
