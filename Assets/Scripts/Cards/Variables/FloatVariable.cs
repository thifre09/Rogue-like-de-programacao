using UnityEngine;

public class FloatVariable : VariableCard
{
    public override string Name => "Float";
    public override string Description => "A float variable that can hold a decimal value.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }
    public float value;

    void Start()
    {
        value = GameController.instance.seed.RandomInt(1, 9);
        N1 = (int)Mathf.Ceil(value);
        N2 = 1;
        N3 = 0;
        StartVariable();
    }
}
