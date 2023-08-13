using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruitsPrefab;
    public GameObject[] spawnAnchors;
    public float spawnTimer = 1f;
    public float _spawnTimer = 0;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if(_spawnTimer >= spawnTimer)
        {
            _spawnTimer = 0;
            SpawnFruit();
        }
    }
    void SpawnFruit()
    {
        int rand = Random.Range(0, fruitsPrefab.Length);
        int rand2 = Random.Range(0, spawnAnchors.Length);
        Instantiate(fruitsPrefab[rand], spawnAnchors[rand2].transform);
    }
}
