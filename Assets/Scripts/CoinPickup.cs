using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int coinValue = 5;
    public AudioClip coinPickupSoundSFX;


    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            OnCoinPickup();
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnCoinPickup();
        }
    }

    public void OnCoinPickup()
    {
        Debug.Log("coin collected" + coinValue);
        AudioSource.PlayClipAtPoint(coinPickupSoundSFX, transform.position, 1f);
        GameManager.Instance.AddScore(coinValue);
        Destroy(gameObject);
    }
}
