using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
    private float lastSpawn = 0.0f;
    private float gameTimer = 0.0f;
    private bool gameIsRunning = false;

    [SerializeField]
    private GameObject platformPrefab;
    [SerializeField]
    private float delayBetweenSpawns = 5.0f;
    [SerializeField]
    private Transform spawnPoint;

	// For initialization
	void Start () {
      
	}
	
	// Update
	void Update () {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1.0f) {
            gameIsRunning = true;
        }
        if (gameIsRunning){
            lastSpawn += Time.deltaTime;
            if (lastSpawn >= delayBetweenSpawns){ 
                Instantiate(platformPrefab, spawnPoint);
                lastSpawn = 0.0f;
            }
        }
	}
}
