using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    

    public GameObject enemyPrefab;

    public int numOfEnemyes = 1;
    private int _alreadySpawnedEnemyes = 0;
    public bool shouldSpawn = true;

    public IntervalValues minMaxValues;
  

    void Awake()
    {
        StartCoroutine(SpawnTimer());
    }

   

    private void SpawnEnemy()
    {
        GameObject enemyClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyClone.transform.parent = transform;
        _alreadySpawnedEnemyes++;

        GameObject player = GameObject.FindGameObjectWithTag("Player");         //ovo bi trebalo definirati u game manageru pa preko njega pitat

        FollowTargetConst followTarget = enemyClone.GetComponent<FollowTargetConst>();            //
        if (followTarget)                                                             // pozivanje druge skripte
        {                                                                             //
            followTarget.target = player.transform;                                                   //
           // followTarget.EnemyMove();
        }
    }

    private IEnumerator SpawnTimer()
    {   // ovo se vise ne odraduje kada se book ugasi pa upali....viditi za rijesenje
        while (shouldSpawn && (_alreadySpawnedEnemyes < numOfEnemyes))
        {
            float randomInterval = Random.Range(minMaxValues.minValue, minMaxValues.maxValue);
            yield return new WaitForSeconds(randomInterval);
            SpawnEnemy();
        }
       
    }
}
