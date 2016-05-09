using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public int maxEnemies;
}

public class EnemySpawn : MonoBehaviour {
    public GameObject[] waypoints;
    public Wave[] waves;

    private GameManager gameManager;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        // get index of current wave
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            // can spawn enemy
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if ((timeInterval > spawnInterval) && 
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // spawn enemy
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)  
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<EnemyMove>().waypoints = waypoints;
                enemiesSpawned++;
            }
            // finish wave 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Score += gameManager.Gold;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
                if (gameManager.Wave < waves.Length)
                {
                    // finish wave
                    Time.timeScale = 0;
                    gameManager.started = false;
                    gameManager.readyButton.gameObject.SetActive(true);
                }
                else
                {
                    // win game
                    gameManager.gameOver = true;
                    gameManager.winCanvas.enabled = true;
                }
            }
        }
    }
}
