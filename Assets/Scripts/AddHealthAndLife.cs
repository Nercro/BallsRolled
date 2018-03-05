using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthAndLife : MonoBehaviour {

    public enum AddState
    {
        AddHealth,
        AddLife
    }
    public float healthValue = 5.0f;
    public int lifeAmount = 1;
    public AddState chooseState = AddState.AddHealth;
    public AudioClip addHealthSoundSFX;
    public AudioClip addLifeSoundSFX;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();

        if (other.gameObject.tag == "Player")
        {
            switch (chooseState)
            {
                case AddState.AddHealth:
                    healthManager.ApplyHeal(healthValue);
                    Destroy(gameObject);
                    break;

                case AddState.AddLife:
                    healthManager.AddBounsLife(lifeAmount);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
