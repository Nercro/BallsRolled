using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundObject : MonoBehaviour {

    public Transform Target;
    public Vector3 axis;
    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(Target.position, axis, speed * Time.deltaTime);
		
	}
}
