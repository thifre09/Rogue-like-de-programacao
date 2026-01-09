public enum CardType
{
    Boolean,
    Float,
    Integer,
    List,
    Null,
    String
}

public enum ColorType
{
    Red,
    Blue,
    Green,
    Yellow,
    Black,
    White
}

public enum WhenEffectIsApplied
{
    Passive,
    OnPlay,
    OnDiscard,
    AfterCardPlayed,
    OnEnd
}

public enum OperatorType
{
    Equal,
    NotEqual,
    GreaterThan,
    LessThan,
    GreaterThanOrEqual,
    LessThanOrEqual
}

public enum UsefulVariables
{
    Round,
    MaxDiscards,
    Discards,
    MaxAttempts,
    Attempts,
    Money,
    HandSize,
    MaxSelectedCards,
    ScoreNeeded,
    N1,
    N2,
    N3
}

public enum EvaluationMode
{
    AllMustBeTrue, // AND
    OneMustBeTrue   // OR
}

public enum Rarity
{
    Commom,
    Rare,
    Epic,
    Legendary,
    Exotic,
    Especial
}

public enum OperationType
{
    Add,
    Subtract,
    Multiply,
    Divide,
    SetValue
}