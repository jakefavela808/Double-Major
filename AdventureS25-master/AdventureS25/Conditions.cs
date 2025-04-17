namespace AdventureS25;

public static class Conditions
{
    public static Dictionary<ConditionTypes, Condition> conditions 
        = new Dictionary<ConditionTypes, Condition>();
    
    public static void Initialize()
    {
        Condition isDrunk = new Condition(ConditionTypes.IsDrunk);
        isDrunk.AddToActivateList(ConditionActions.WriteOutput("Hic!"));
        Add(isDrunk);

        Condition beerMe = new Condition(ConditionTypes.IsBeerMed);
        beerMe.AddToActivateList(ConditionActions.AddItemToInventory("beer"));
        beerMe.AddToDeactivateList(ConditionActions.RemoveItemFromInventory("beer"));
        Add(beerMe);

        Condition isHungover = new Condition(ConditionTypes.IsHungover);
        isHungover.AddToActivateList(ConditionActions.AddItemToLocation("puke", 
            "Entrance"));
        Add(isHungover);

        Condition isTidyedUp = new Condition(ConditionTypes.IsTidiedUp);
        isTidyedUp.AddToActivateList(ConditionActions.RemoveItemFromLocation("puke",
            "Entrance"));
        Add(isTidyedUp);
    }

    public static void ChangeCondition(ConditionTypes conditionType,
        bool isSettingToTrue)
    {
        if (NotInDictionary(conditionType))
        {
            return;
        }
        
        // if setting to true AND we're currently false
        if (isSettingToTrue && IsFalse(conditionType))
        {
            Condition condition = conditions[conditionType];
            condition.Activate();
        }
        // if not setting to true and we're current true
        else if (!isSettingToTrue && IsTrue(conditionType))
        {
            Condition condition = conditions[conditionType];
            condition.Deactivate();
        }

    }

    public static void Add(Condition condition)
    {
        conditions.Add(condition.Type, condition);
    }

    public static bool IsTrue(ConditionTypes conditionType) 
    {
        if (NotInDictionary(conditionType))
        {
            return false;
        }

        return conditions[conditionType].IsActive;
    }

    public static bool IsFalse(ConditionTypes conditionType)
    {
        if (NotInDictionary(conditionType))
        {
            return true;
        }
        return !conditions[conditionType].IsActive;
    }

    private static bool NotInDictionary(ConditionTypes conditionType)
    {
        return !conditions.ContainsKey(conditionType);
    }
}