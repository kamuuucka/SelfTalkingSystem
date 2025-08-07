using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelfTalkingManager : MonoBehaviour
{
    [SerializeField] private List<SelfTalkingTriggerData> triggers;

    private float _idleTimer;

    private void Update()
    {
        foreach (var trigger in triggers)
        {
            if (EvaluateTrigger(trigger))
            {
                DisplayText(trigger);
                break;
            }
        }
    }

    private void DisplayText(SelfTalkingTriggerData trigger)
    {
        Debug.Log(GetRandomNoRepetition.GetRandomValue(trigger.lines));
    }

    private bool EvaluateTrigger(SelfTalkingTriggerData trigger)
    {
        switch (trigger.condition)
        {
            case TriggerConditionType.IdleTooLong:
                var timer = float.Parse(trigger.requiredValue.Replace(',', '.'), CultureInfo.InvariantCulture);

                if (!Input.anyKey)
                {
                    _idleTimer += Time.deltaTime;
                    if (_idleTimer >= timer)
                    {
                        _idleTimer = 0;
                        return true;
                    }
                }
                else
                {
                    _idleTimer = 0f;
                }
                return false;
                
            case TriggerConditionType.SpecificInteraction:
                return false;
                
            default:
                return false;
        }
    }
    
}
