using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public GameObject bloodOverlay;
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthBar;
    //public Image healthBar;
    public TextMeshProUGUI healthText;
    public GameObject gameOverScreen;  // Assign from the UI Canvas

    private Coroutine flashCoroutine;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
       UpdateHealthUI();
    }

    /*private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }*/

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        healthBar.fillAmount = currentHealth/100f;
        UpdateHealthUI();
        Debug.Log("Player took damage: " + damage + ", Health: " + currentHealth);

        //damage Screen from AI
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashBlood());


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashBlood()
    {
        bloodOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f); // How long the flash lasts
        bloodOverlay.SetActive(false);
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "%";
        }
    }


    void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");
        gameOverScreen.SetActive(true);  // Show Game Over UI
        GetComponent<Player>().enabled = false;


        FindObjectOfType<PlayerManager>().GameOver();
        gameOverScreen.SetActive(true);
        GetComponent<Player>().enabled = false;
        // Add this line
                                                      /*  // Stop all enemy sounds
                                                        AudioSource[] enemyAudioSources = FindObjectsOfType<AudioSource>();
                                                        foreach (AudioSource audio in enemyAudioSources)
                                                        {
                                                            if (audio.gameObject.CompareTag("Enemy"))
                                                            {
                                                                audio.Stop();
                                                            }
                                                        }

                                                        Time.timeScale = 0f;  // Freeze the game*/
    }
    /* void Die()
     {
         isDead = true;
         Debug.Log("Player has died!");
         gameOverScreen.SetActive(true);  // Show Game Over UI
         GetComponent<Player>().enabled = false;  // Disable movement & shooting

         FindObjectOfType<PlayerManager>().GameOver(); // Add this line to confirming the died player manager scripyt
     }*/

    void RestartScene()
    {

    }
}
