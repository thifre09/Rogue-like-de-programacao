using UnityEngine;

public class StringVariable : VariableCard
{
    public override string Name => "String";
    public override string Description => "A string variable that can hold text.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }
    public string value;

    void Start()
    {
        int a = GameController.instance.seed.RandomInt(1, 9);
        for (int i = 0; i < a; i++)
        {
            value += (char)GameController.instance.seed.RandomInt(97, 123);
        }
        N1 = value.Length;
        N2 = 1;
        N3 = 2;
        ChangeDescription();
    }
}
