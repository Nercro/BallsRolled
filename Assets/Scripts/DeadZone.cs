using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    // vidit u manualu za triggere
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            //pogledat za screen manager u maualu
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
