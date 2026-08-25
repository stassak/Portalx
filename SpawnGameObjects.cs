using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
    public GameObject[] spawnGameObjects;

    //Capture part
    private PlayerManager captureManager;

    private float spawnRangePosX = 10;
    private float spawnPosZ = 45;

    private float startDelay = 0.5f;
    private float spawnInterval = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObjects", startDelay, spawnInterval);
       //captureManager = GameObject.Find("Player Manager").GetComponent<PlayerManager>();// Checking from unity level design
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            SpawnRandomObjects();
        }
    }

    void SpawnRandomObjects()
    {
        int enemyIndex = Random.Range(0, spawnGameObjects.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangePosX, spawnRangePosX), 1.5f, spawnPosZ);

        Instantiate(spawnGameObjects[enemyIndex], spawnPos, spawnGameObjects[enemyIndex].transform.rotation);
    }
}
