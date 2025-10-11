using UnityEngine;

public class BooleanVariable : VariableCard
{
    public override string Name => "Boolean";
    public override string Description => "A boolean variable that can hold true or false.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }
    public bool value;

    void Start()
    {
        value = GameController.instance.seed.RandomInt(0, 1) == 1;
        N1 = 10;
        N2 = value ? 2 : 3;
        N3 = value ? 3 : 2;
        ChangeDescription();
    }
}
