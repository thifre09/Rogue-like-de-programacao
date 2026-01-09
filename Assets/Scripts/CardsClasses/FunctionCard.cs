using UnityEngine;
using UnityEngine.EventSystems;

public class FunctionCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public FunctionScriptableObject data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public int ReturnVariable(UsefulVariables usefulVariable)
    {
        switch (usefulVariable)
        {
            case UsefulVariables.Round:
                return MatchController.round;
            case UsefulVariables.MaxDiscards:
                return MatchController.maxDiscards;
            case UsefulVariables.Discards:
                return MatchController.discards;
            case UsefulVariables.MaxAttempts:
                return MatchController.maxAttempts;
            case UsefulVariables.Attempts:
                return MatchController.attempts;
            case UsefulVariables.Money:
                return MatchController.money;
            case UsefulVariables.HandSize:
                return CardController.maxHandCards;
            case UsefulVariables.MaxSelectedCards:
                return CardController.instance.selectedCards.Count;
            case UsefulVariables.ScoreNeeded:
                return MatchController.problemScoreNeeded;
            case UsefulVariables.N1:
                return (int)ScoreController.N1;
            case UsefulVariables.N2:
                return (int)ScoreController.N2;
            case UsefulVariables.N3:
                return (int)ScoreController.N3;
            default:
                UnityEngine.Debug.LogError("Variável útil não reconhecida!");
                return -1;
        }
    }
  
    public bool VerifyConditions()
    {
        foreach (var condition in data.conditions)
        {
            bool conditionMet = false;
            if(condition.compareToVariable)
            {
                switch(condition.operatorType)
                {
                    case OperatorType.Equal:
                        conditionMet = ReturnVariable(condition.value1) == ReturnVariable(condition.value2Variable);
                        return conditionMet;
                    case OperatorType.NotEqual:
                        conditionMet = ReturnVariable(condition.value1) != ReturnVariable(condition.value2Variable);
                        return conditionMet;
                    case OperatorType.GreaterThan:
                        conditionMet = ReturnVariable(condition.value1) > ReturnVariable(condition.value2Variable);
                        return conditionMet;
                    case OperatorType.LessThan:
                        conditionMet = ReturnVariable(condition.value1) < ReturnVariable(condition.value2Variable);
                        return conditionMet;
                    case OperatorType.GreaterThanOrEqual:
                        conditionMet = ReturnVariable(condition.value1) >= ReturnVariable(condition.value2Variable);
                        return conditionMet;
                    case OperatorType.LessThanOrEqual:
                        conditionMet = ReturnVariable(condition.value1) <= ReturnVariable(condition.value2Variable);
                        return conditionMet;
                }
                throw new System.Exception("OperatorType não reconhecido.");   
            }
            else if (!condition.compareToVariable)
            {
                switch(condition.operatorType)
                {
                    case OperatorType.Equal:
                        conditionMet = ReturnVariable(condition.value1) == condition.value2Int;
                        return conditionMet;
                    case OperatorType.NotEqual:
                        conditionMet = ReturnVariable(condition.value1) != condition.value2Int;
                        return conditionMet;
                    case OperatorType.GreaterThan:
                        conditionMet = ReturnVariable(condition.value1) > condition.value2Int;
                        return conditionMet;
                    case OperatorType.LessThan:
                        conditionMet = ReturnVariable(condition.value1) < condition.value2Int;
                        return conditionMet;
                    case OperatorType.GreaterThanOrEqual:
                        conditionMet = ReturnVariable(condition.value1) >= condition.value2Int;
                        return conditionMet;
                    case OperatorType.LessThanOrEqual:
                        conditionMet = ReturnVariable(condition.value1) <= condition.value2Int;
                        return conditionMet;
                }
                throw new System.Exception("OperatorType não reconhecido.");
            }         
        }
        return true;
    }

    public void ApplyEffects()
    {
        foreach (var effect in data.effects)
        {
            if (effect.useVariable)
            {
                switch(effect.operationType)
                {
                    case OperationType.Add:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Money:
                                MatchController.money += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 += ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 += ReturnVariable(effect.valueVariable);
                                break;
                        }
                        break;
                    case OperationType.Subtract:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Money:
                                MatchController.money -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 -= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 -= ReturnVariable(effect.valueVariable);
                                break;
                        }
                        break;
                    case OperationType.Multiply:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Money:
                                MatchController.money *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 *= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 *= ReturnVariable(effect.valueVariable);
                                break;
                        }
                        break;
                    case OperationType.Divide:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Money:
                                MatchController.money /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 /= ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 /= ReturnVariable(effect.valueVariable);
                                break;
                        }
                        break;
                    case OperationType.SetValue:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.Money:
                                MatchController.money = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 = ReturnVariable(effect.valueVariable);
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 = ReturnVariable(effect.valueVariable);
                                break;
                        }
                        break;
                }
            }
            else
            {
                switch(effect.operationType)
                {
                    case OperationType.Add:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards += effect.valueInt;
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards += effect.valueInt;
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts += effect.valueInt;
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts += effect.valueInt;
                                break;
                            case UsefulVariables.Money:
                                MatchController.money += effect.valueInt;
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards += effect.valueInt;
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards += effect.valueInt;
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded += effect.valueInt;
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 += effect.valueInt;
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 += effect.valueInt;
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 += effect.valueInt;
                                break;
                        }
                        break;
                    case OperationType.Subtract:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards -= effect.valueInt;
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards -= effect.valueInt;
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts -= effect.valueInt;
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts -= effect.valueInt;
                                break;
                            case UsefulVariables.Money:
                                MatchController.money -= effect.valueInt;
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards -= effect.valueInt;
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards -= effect.valueInt;
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded -= effect.valueInt;
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 -= effect.valueInt;
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 -= effect.valueInt;
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 -= effect.valueInt;
                                break;
                        }
                        break;
                    case OperationType.Multiply:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards *= effect.valueInt;
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards *= effect.valueInt;
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts *= effect.valueInt;
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts *= effect.valueInt;
                                break;
                            case UsefulVariables.Money:
                                MatchController.money *= effect.valueInt;
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards *= effect.valueInt;
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards *= effect.valueInt;
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded *= effect.valueInt;
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 *= effect.valueInt;
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 *= effect.valueInt;
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 *= effect.valueInt;
                                break;
                        }
                        break;
                    case OperationType.Divide:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards /= effect.valueInt;
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards /= effect.valueInt;
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts /= effect.valueInt;
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts /= effect.valueInt;
                                break;
                            case UsefulVariables.Money:
                                MatchController.money /= effect.valueInt;
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards /= effect.valueInt;
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards /= effect.valueInt;
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded /= effect.valueInt;
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 /= effect.valueInt;
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 /= effect.valueInt;
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 /= effect.valueInt;
                                break;
                        }
                        break;
                    case OperationType.SetValue:
                        switch(effect.VariableAffected)
                        {
                            case UsefulVariables.MaxDiscards:
                                MatchController.maxDiscards = effect.valueInt;
                                break;
                            case UsefulVariables.Discards:
                                MatchController.discards = effect.valueInt;
                                break;
                            case UsefulVariables.MaxAttempts:
                                MatchController.maxAttempts = effect.valueInt;
                                break;
                            case UsefulVariables.Attempts:
                                MatchController.attempts = effect.valueInt;
                                break;
                            case UsefulVariables.Money:
                                MatchController.money = effect.valueInt;
                                break;
                            case UsefulVariables.HandSize:
                                CardController.maxHandCards = effect.valueInt;
                                break;
                            case UsefulVariables.MaxSelectedCards:
                                CardController.maxSelectedCards = effect.valueInt;
                                break;
                            case UsefulVariables.ScoreNeeded:
                                MatchController.problemScoreNeeded = effect.valueInt;
                                break;
                            case UsefulVariables.N1:
                                ScoreController.N1 = effect.valueInt;
                                break;
                            case UsefulVariables.N2:
                                ScoreController.N2 = effect.valueInt;
                                break;
                            case UsefulVariables.N3:
                                ScoreController.N3 = effect.valueInt;
                                break;
                        }
                        break;
                }
            }           
        }
        MatchController.instance.UpdateUI();
    }
}
