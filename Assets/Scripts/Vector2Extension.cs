using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extension  {

    public static float RandomValue(this Vector2 v2)
    {
        float randomValue = Random.Range(v2.x, v2.y);

        return randomValue;
    }
}
