using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "FunctionScriptableObject", menuName = "Scriptable Objects/FunctionScriptableObject")]
public class FunctionScriptableObject : ScriptableObject
{
    public GameObject functionName;
    public GameObject description;
    public Sprite sprite;
    public Rarity rarity;
    public bool useCustomScript;
    [HideIf("useCustomScript")] public int maxActivations = 0; //0 means infinite
    [HideIf("useCustomScript")] public WhenEffectIsApplied whenEffectIsApplied;
    [HideIf(EConditionOperator.Or, "useCustomScript", nameof(hasLessThanOneCondition))] public EvaluationMode EvaluationMode;
    [HideIf("useCustomScript")][OnValueChanged(nameof(HasLessThan))] public List<CondicaoF> conditions;
    [HideIf("useCustomScript")] public List<EfeitoF> effects;

    [Serializable]
    public struct CondicaoF
    {

        public bool compareToVariable;
        public OperatorType operatorType;
        public UsefulVariables value1;
        [ShowIf(nameof(compareToVariable))][AllowNesting] public UsefulVariables value2Variable;
        [HideIf(nameof(compareToVariable))][AllowNesting] public int value2Int;
    }

    [Serializable]
    public struct EfeitoF
    {
        public OperationType operationType;
        public UsefulVariables VariableAffected;
        public bool useVariable;
        [ShowIf(nameof(useVariable))][AllowNesting]public UsefulVariables valueVariable;
        [HideIf(nameof(useVariable))][AllowNesting]public int valueInt;
    }

    private bool hasLessThanOneCondition = true;
    private void HasLessThan()
    {
        if (conditions != null && conditions.Count > 1)
            hasLessThanOneCondition = false;
        else
            hasLessThanOneCondition = true;
        
        bool a = hasLessThanOneCondition;
    }
}