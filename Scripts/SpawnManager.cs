using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField] float spawnRangeX = 13.5f;
    [SerializeField] float spawnPosY = 0.66f;
    [SerializeField] float spawnPosZ = 9.5f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.isGameActive)
        {
            InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
