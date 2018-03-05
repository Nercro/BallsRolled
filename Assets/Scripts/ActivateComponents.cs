using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateComponents : MonoBehaviour {

    public GameObject[] gameObjects;
    public bool hasAnimator = true;
    public bool hasGameObjects = true;
    public bool hasParticleSystem = true;
    public bool winGamePlatform = false;

    private ParticleSystem particleStart;

    private void Start()
    {
        ParticleSystem particleStart = gameObject.GetComponent<ParticleSystem>();
        particleStart.enableEmission = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasAnimator)
        {
            Animator animationStart = GetComponent<Animator>();
            animationStart.enabled = true;
        }

        if (hasGameObjects)
        {
            foreach (GameObject go in gameObjects)
            {
                go.gameObject.SetActive(true);
            }
        }

        if (hasParticleSystem)
        {
            ParticleSystem particleStart = gameObject.GetComponent<ParticleSystem>();
            particleStart.enableEmission = true;
            
        }

        if (winGamePlatform)
        {
            GameManager.Instance.WinLevel();
        }
        
    }
}
