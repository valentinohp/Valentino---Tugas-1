using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPointMin;
    public Transform spawnPointMax;
    public float interval = 1f;
    private float timer = 0f;

    private void Start() 
    {
        SpawnEnemy();
    }

    private void Update() 
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(spawnPointMin.position.x, spawnPointMax.position.x), transform.position.y, 0);
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
