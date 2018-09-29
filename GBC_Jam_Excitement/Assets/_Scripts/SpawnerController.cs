using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    [Header("Spawn Properties")]
    private bool gameIsRunning = false;
    private float lastSpawn = 0.0f;
    private float gameTimer = 0.0f;
    [SerializeField]
    private float delayBetweenSpawns = 5.0f;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject platformPrefab;

    // Queue Properties
    Queue<GameObject> UnfilledPlatformQueue;


    // For initialization
    private void Start () {
        UnfilledPlatformQueue = new Queue<GameObject>();
	}
	
	// Update
	private void Update ()
    {
        SpawnPlatforms();
    }

    // Constantly spawns platforms given a delay
    private void SpawnPlatforms()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1.0f)
        {
            gameIsRunning = true;
        }
        if (gameIsRunning)
        {
            lastSpawn += Time.deltaTime;
            if (lastSpawn >= delayBetweenSpawns)
            {
                GameObject spawnedPlatform = Instantiate(platformPrefab, spawnPoint) as GameObject;

                lastSpawn = 0.0f; //reset spawn time
            }
        }
    }

    // returns the current position of the most recent unfilled platform
    public Transform GetThrowablePosition()
    {
        if (UnfilledPlatformQueue.Count == 0) //if queue is empty
            return null;

        return UnfilledPlatformQueue.Peek().transform;
    }

    public void NotifyAddPlatform(GameObject PlatformToAdd)
    {
        UnfilledPlatformQueue.Enqueue(PlatformToAdd);
    }

    // Removes the notified object from the queue. Called by PlatformScripts
    public void NotifyRemovePlatform()
    {
        UnfilledPlatformQueue.Dequeue();
    }
}
