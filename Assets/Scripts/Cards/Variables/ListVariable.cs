using System.Collections.Generic;
using UnityEngine;

public class ListVariable : VariableCard
{
    public override string Name => "List";
    public override string Description => "A list variable that can hold multiple values.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }
    public List<object> value = new();

    void Start()
    {
        int a = GameController.instance.seed.RandomInt(1, 9);
        for (int i = 0; i < a; i++)
        {
            int type = GameController.instance.seed.RandomInt(0, 3);
            if (type == 0)
            {
                value.Add(GameController.instance.seed.RandomInt(1, 9)); // int
            }
            else if (type == 1)
            {
                value.Add(GameController.instance.seed.RandomInt(1, 9)); // float
            }
            else
            {
                int strLength = GameController.instance.seed.RandomInt(1, 9);
                string strValue = "";
                for (int j = 0; j < strLength; j++)
                {
                    strValue += (char)GameController.instance.seed.RandomInt(97, 123);
                }
                value.Add(strValue); // string
            }
        }
        N1 = value.Count;
        N2 = 0;
        N3 = 1;
        StartVariable();
    }
}
