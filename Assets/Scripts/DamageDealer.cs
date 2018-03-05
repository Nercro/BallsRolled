using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    public float DamageValue = 5.0f;
    public int numOfLivesOnTrigger = 1;
    public bool damageOnCollision = true;
    public bool damageOnTrigger = false; //TODO: napraviti da kada je damageOnTrigger true da oduzima zivot u suprotnom da oduzima heaklthe
    public bool destroyOnDamage = true;

   

    //  Collider može davati damage i oduzimati živote  TODO: staviti u zasebnu metodu
    public void OnCollisionEnter(Collision other)
    {
       
       HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();
                                                                                       
       if (damageOnCollision == true && damageOnTrigger == false)                      
       {
            if (healthManager != null && destroyOnDamage == false)
            {
                healthManager.ApplyDamage(DamageValue);
            }
            else if (healthManager != null && destroyOnDamage == true)
            {
                healthManager.ApplyDamage(DamageValue);
                Destroy(gameObject);   
            }
            else
            {
                Debug.Log(other.gameObject.name + "Does not contain HealtManager component");
            }
       }
       else if (damageOnCollision == false && damageOnTrigger == true) {
       
           if (healthManager != null)
           {
               healthManager.looseLife(numOfLivesOnTrigger);
           }
           else
           {
               Debug.Log(other.gameObject.name + "Does not contain HealtManager component");
           }
       }
       else {
           Debug.Log("GameObject: " + gameObject.name + " both checkboxes cannot be checked or unchecked");
       }
        
        
    }
    //  Trigger može oduzimati živote i davati damage
    private void OnTriggerEnter(Collider other)
    {
       
       HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();
       
       if (damageOnCollision == false && damageOnTrigger == true)
       {
           if (healthManager != null)
           {
               healthManager.looseLife(numOfLivesOnTrigger);  
           }
           else
           {
               Debug.Log(other.gameObject.name + "Does not contain HealtManager component");
           }
       }
       else if (damageOnCollision == true && damageOnTrigger == false)
       {
           if (healthManager != null)
           {
               healthManager.ApplyDamage(DamageValue);
           }
           else
           {
               Debug.Log(other.gameObject.name + "Does not contain HealtManager component");
           }
       }
       else
       {
           Debug.Log("GameObject: " + gameObject.name + " both checkboxes cannot be checked or unchecked");
       }
        

        
    }

   


}
