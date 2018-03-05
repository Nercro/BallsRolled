using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {

    public float TimeToDestroy = 2.0f;

    private void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }
}
