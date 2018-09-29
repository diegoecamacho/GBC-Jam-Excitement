using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueGuardScript : MonoBehaviour {

    SpawnerController spawnerController;

    private void Start()
    {
        spawnerController = GameObject.Find("GameManager").GetComponent<SpawnerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Platform"))
        {
            spawnerController.NotifyAddPlatform(other.gameObject);
        }
    }
}
