using UnityEngine;

public class NullVariable : VariableCard
{
    public override string Name => "Null";
    public override string Description => "A null variable that represents the absence of a value.";
    public override int N1 { get; set; }
    public override int N2 { get; set; }
    public override int N3 { get; set; }

    void Start()
    {
        N1 = 25;
        N2 = 1;
        N3 = 1;
        StartVariable();
    }
}
