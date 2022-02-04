using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    void Start()
    {
        PopulatePool();
        StartCoroutine(SpawnEnemies());    
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for(int i= 0; i < poolSize; i++)
            {
                if(!pool[i].activeInHierarchy)
                    pool[i].SetActive(true);
                yield return new WaitForSeconds(spawnTime);
            }  
        }
    }
}
