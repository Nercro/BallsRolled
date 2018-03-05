using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTrigger : MonoBehaviour
{

    public GameObject[] targ;
    public string enemyName;
    private FollowTarget followTarget;

    private void Start()
    {

        targ = GameObject.FindGameObjectsWithTag(enemyName);

        
    }

    private void OnCollisionStay(Collision collision)
    {
        
        foreach (GameObject tar in targ) 
        {
            if (tar != null)
            {
                followTarget = tar.GetComponent<FollowTarget>();
                followTarget.EnemyMove();
            }
            
            
        }
        
        
    }

}
