using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetTraining : MonoBehaviour
{
    public GameObject[]trainTarget;

    private float spawnXtargetPosition = 3;
    private float spawnZposTarget = 10;
    private float spawnYposTarget = 3;

    private float spawnRangePosX;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.V))
        {
            SpawnTarget();
        }*/
    }
    void SpawnTarget()
    {
           // Vector3 spawnPos = new Vector3(Random.Range(-spawnXtargetPosition,spawnXtargetPosition),( ,spawnYposTarget),(spawnZposTarget));
             int targetIndex = Random.Range(0, trainTarget.Length);
           
             Instantiate(trainTarget[targetIndex],new Vector3(Random.Range( -8 ,8), Random.Range(2, 6), Random.Range(5,20)), trainTarget[targetIndex].transform.rotation);

    }
}
