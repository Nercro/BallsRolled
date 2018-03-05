using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {


    public enum OnDeathAction {
        reloadLevel,
        gameOver,
        destroySelf,
        doNothing
    }
    public float Health = 10.0f;
    public int numOfLives = 2;
    public OnDeathAction OnAllLivesGone = OnDeathAction.doNothing;
  
    private static Vector3 _respawnPosition;
    private float _respawnHealth;
    private Rigidbody _rigidBody;
    public Text displayLives;

    public GameObject hitSmoke;
    public AudioClip onDeathSoundSFX;
    
    private void Awake()
    {
        
        _respawnPosition = transform.position;
        _respawnHealth = Health;
        _rigidBody = GetComponent<Rigidbody>();

        if (gameObject.tag == "Player")
        {
            displayLives.text = "Lives: " + numOfLives;
        }
       
        
    }
    // Update is called once per frame
    void Update () {
        
        

	}
    //TODO: vidit kako to ukalupit u jedno sa lose life metoodom
    public void DamageHandler() {
        
        
        if (Health <= 0)
        {   // mora biti child
            GameObject hitSomkeOnKill = Instantiate(hitSmoke, transform.position, Quaternion.identity) as GameObject;
            hitSomkeOnKill.GetComponent<ParticleSystemRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
            
            looseLife(1);
  
        }
           
    }
    

    public void ApplyDamage(float amount) {

        Health -= amount;
        DamageHandler();
        
    }

    public void ApplyHeal(float amount) {

        Health += amount;
    }

    public void AddBounsLife(int amount) {

        numOfLives += amount;
        if (gameObject.tag == "Player")
        {
            displayLives.text = "Lives: " + numOfLives;
        }
    }

    public void respawnOnDeath(Vector3 respawnValue) {
        _respawnPosition = respawnValue;
    }

    public void looseLife(int amount) {
        numOfLives -= amount;
        Vector3 campos = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        AudioSource.PlayClipAtPoint(onDeathSoundSFX, campos, 1.0f);
        if (gameObject.tag == "Player")
        {
            displayLives.text = "Lives: " + numOfLives;
        }


        if (numOfLives > 0)
        {
            Health = _respawnHealth;
            transform.position = _respawnPosition;
            _rigidBody.velocity = Vector3.zero;
        }
        else
        {
            switch (OnAllLivesGone)
            {
                case OnDeathAction.reloadLevel:
                    Application.LoadLevel(Application.loadedLevel);
                    Debug.Log("restart lvl");
                    break;

                case OnDeathAction.gameOver:
                    GameManager.Instance.gameOver();
                    Destroy(gameObject);
                    break;

                case OnDeathAction.destroySelf:
                    Destroy(gameObject);
                    break;

                case OnDeathAction.doNothing:
                    Debug.Log("i didn nothing and still got paid");
                    break;

                default:
                    Debug.Log("Case not supported");
                    break;
            }

        }
    }
}
