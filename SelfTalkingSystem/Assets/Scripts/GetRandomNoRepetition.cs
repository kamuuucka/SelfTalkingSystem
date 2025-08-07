using System.Collections.Generic;
using UnityEngine;

public class GetRandomNoRepetition
{
    public static T GetRandomValue<T>(List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}
