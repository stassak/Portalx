using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //  private int totalSceneNumber = SceneManager.sceneCountInBuildSettings; // built in functoin

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         SceneManager.LoadScene("BETA1Portal");
    }

    public void TrainingLevelPlay()
    {
         SceneManager.LoadScene("TrainingLevel"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }

  
}
