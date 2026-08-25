using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    //public float levelTimer = 0f;// default timer with standart fixed time(1)
    public float minTime = 40f;
    public float maxTime = 80f;
    private float timer = 0.0f;
    public TextMeshProUGUI timerText;
    public GameObject levelCompleteScreen;

    public AudioSource interruptedProcess;

    private bool levelEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        //timer = levelTimer;//default timer with standart fixed time(1)

        timer = Random.Range(minTime, maxTime);
        if (interruptedProcess != null)
        {
            interruptedProcess.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerManager.isGameOver) return;

        if (levelEnded) return;
        // timer survival
      /*  timer += Time.deltaTime;
        timerText.text = "Survival time: " + Mathf.FloorToInt(timer).ToString(); // + " s";
        */
        // countdown 
       timer -= Time.deltaTime;//instance deltaTime .unscaledDeltaTime
        timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();

        if (timer <= 0f)
        {
            timer = 0;
            levelEnded = true;
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level Complete!");
        levelCompleteScreen.SetActive(true);

        FindObjectOfType<Player>().enabled = false;

        AudioSource[] enemyAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in enemyAudioSources)
        {
            if (audio.gameObject.CompareTag("Enemy"))
            {
                audio.Stop();
            }
        }

        Time.timeScale = 0f; // Pause the game
    }
}
