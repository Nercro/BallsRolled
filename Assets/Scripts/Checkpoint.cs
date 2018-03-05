using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();
        

        if (other.tag != null) {
            healthManager.respawnOnDeath(transform.position);
            (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
        }

    }
}
