using System.Collections.Generic;
using UnityEngine;

public enum TriggerConditionType
{
    IdleTooLong,
    SpecificInteraction
}

[CreateAssetMenu(fileName = "NewTriggerData", menuName = "ScriptableObjects/SelfTalking/Trigger", order = 1)]
public class SelfTalkingTriggerData : ScriptableObject
{
   public TriggerConditionType condition;
   public string requiredValue;
   public List<string> lines;
   public int priority;
}
