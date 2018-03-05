using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coinPrefab;
    public float spawnInterval = 1.0f;
    public int howMannyCoins = 1;
    private int _alreadySpawned = 0;
    public bool shouldSpawn = true;
    

    [SerializeField]
    private float _stopwatch = 0.0f;

    void Awake()
    {
        //InvokeRepeating("SpawnCoin", 0.0f, spawnInterval);
    }

    void Update()
    {
        _stopwatch += Time.deltaTime;

        if ((_stopwatch >= spawnInterval) && shouldSpawn && _alreadySpawned < howMannyCoins ) 
        {
            _stopwatch = 0.0f;
            SpawnCoin ();
            _alreadySpawned++;
        }
    }
    private void SpawnCoin()
    {
        GameObject coinClone = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coinClone.transform.parent = transform;
    }
}
