using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    
    public int maxCaptures = 10;
    private int captureProgress = 0;
    public TextMeshProUGUI captureLevelText;
    public Slider captureProgressBar;
    public GameObject captureScreen;

    public AudioSource levelStartAudioEnemyDetect;
    
    //public TextMeshProUGUI captureProgressText;

   // public static int playerHP = 100;
    public static bool isGameOver;
    public static bool isPaused;
   
    public GameObject pauseMenuScreen;
   // public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI gameOverText;

   /* public float levelDuration; // seconds to complete the level
    private float timer = 0f;*/

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       /* levelDuration = Random.Range(40f,65f);
        Debug.Log("Timer" + levelDuration);*/
        isGameOver = false;
        isPaused = false;
        captureProgress = 0;
        //  UpdateLevelCapture(0);
        //captureLevelText.text = "Capturing: " + captureProgress + "%"; //updated in the UpdateLevelCapture

        if (levelStartAudioEnemyDetect != null)
        {
            levelStartAudioEnemyDetect.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "TrainingLevel")
        {
            return;
        }

        // playerHPText.text = "+" + playerHP;
      /*  if (isGameOver) return;

        timer += Time.deltaTime;

        if (timer >= levelDuration)
        {
            CompleteLevel();
        }
        */
    }

    void CompleteLevel()
    {
        
        Debug.Log("Level Complete!");
        // Optional: show UI message or sound
        Invoke("LoadNextLevel", 5f); // Delay before switching
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenuScreen.SetActive(true);

      /*  // Disable player shooting
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerShooting shooting = player.GetComponent<PlayerShooting>();
            if (shooting != null)
                shooting.enabled = false;
        }*/
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenuScreen.SetActive(false);

        // Re-enable player shooting
     /*   GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerShooting shooting = player.GetComponent<PlayerShooting>();
            if (shooting != null)
                shooting.enabled = true;
        }*/
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    //work but theres no option to stop back ground procceses 
    public void GameOver()
    {
        if (isGameOver) return; //prevent double call
        Debug.Log("GameOver() called");
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        FindObjectOfType<Player>().enabled = false; // Disable player control



        Time.timeScale = 0f; // Optional: freeze everything
        //gameOverText.gameObject.SetActive(true);//shows only screen pof the game over panel
        //stops the logic in PlayerHealth Script Die method
        AudioSource[] enemyAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in enemyAudioSources)
        {
            if (audio.gameObject.CompareTag("Enemy"))
            {
                audio.Stop();
            }
        }

        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("BETA1Portal");//default logic to the level current level will be reset after reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//or .name); instead the index 
    }

    public void RestartTraining()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TrainingLevel");// restart default level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// upload next scene in the build
    }
    /*public void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            isGameOver = true;
        }
    }*/

    //from unity learning
    /*  void UpdateLevelCapture(int captureAdd)
      {
          captureProgress += captureAdd;
          captureLevelText.text = "Capturing: " + captureProgress + "%";

      }
      */

    public void MonsterCapture()
    {
        captureProgress++;
        UpdateCapturedUI();
        if ( captureProgress >= maxCaptures )
        {
            CaptureGameOver();
        }
    }

    private void UpdateCapturedUI()
    {
        float percent = (float)captureProgress / maxCaptures;
        captureProgressBar.value = captureProgress;
        captureLevelText.text = "Captured Level: " + captureProgress + "0%";
    }

    private void CaptureGameOver()
    {
        Debug.Log("Station Captured!");
        captureScreen.SetActive(true);
        isGameOver = true;
        gameOverText.text = "Station Captured";
        gameOverText.gameObject.SetActive(true);
        FindObjectOfType<Player>().enabled = false;

        AudioSource[] enemyAdioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in enemyAdioSources)
        {
            if (audio.gameObject.CompareTag("Enemy"))
            {
                audio.Stop();
            }
        }
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}