using UnityEngine;

public class IntVariable : VariableCard
{
    public override string Name => "Integer";
    public override string Description => "An integer variable that can hold whole numbers.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }
    public int value;

    void Start()
    {
        value = GameController.instance.seed.RandomInt(1, 9);
        N1 = value;
        N2 = 0;
        N3 = 1;
        StartVariable();
    }
}