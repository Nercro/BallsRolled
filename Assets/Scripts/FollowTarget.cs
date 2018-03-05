using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float Speed = 30.0f;
    public float distanceToKeep = 0.0f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void EnemyMove()
    {
        
        if (target == null)
        {
            print("target je null");
            return;
        }
            

        _transform.LookAt(target);

        float distanceToTarget = Vector3.Distance(target.position, _transform.position);

        if (distanceToTarget > distanceToKeep)
        {
            _transform.position += _transform.forward * Speed * Time.deltaTime;
        }
    }
} 

