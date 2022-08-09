using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public TMP_Text waveText;
    public GameObject[] spawnList;
    public Transform spawnPointMin;
    public Transform spawnPointMax;
    public float interval = 1f;
    public int waveNumber = 1;
    public int clearedThisWave = 0;
    private float timer = 0f;
    private int spawned = 0;
    private int spawnThisWave = 3;
    private bool waveSpawned = false;
    private bool waveCleared = false;

    private void Start() 
    {
        SpawnEnemy();
    }

    private void Update() 
    {
        HandleWave();
        Time.timeScale += Time.deltaTime / 100;
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(spawnPointMin.position.x, spawnPointMax.position.x), transform.position.y, 0);
        GameObject obj = Instantiate(spawnList[Random.Range(0, spawnList.Length)], spawnPoint, Quaternion.identity);
        obj.SetActive(true);
        spawned++;
    }

    private void HandleWave()
    {
        if (!waveSpawned)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                SpawnEnemy();
                timer = 0f;
            }

            if (spawned == spawnThisWave)
            {
                waveSpawned = true;
            }
        }

        if (clearedThisWave == spawnThisWave)
        {
            waveCleared = true;
            waveNumber++;
            clearedThisWave = 0;
        }

        if (waveCleared)
        {
            spawnThisWave = waveNumber + Random.Range(1, 5);
            waveSpawned = false;
            waveText.text = "Wave " + waveNumber;
            waveCleared = false;
            spawned = 0;
        }
    }
}
