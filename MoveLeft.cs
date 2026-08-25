using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour
{
    
    public float speedObstacle = 10;
    private Player playerScript;
    private float backBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        int level = SceneManager.GetActiveScene().buildIndex;
        float levelMultiplier = 1f + (level * 0.25f);
        speedObstacle = speedObstacle * levelMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isGameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speedObstacle);
        }

        if (transform.position.z < backBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
