using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float speedPlayer = 10.0f;
    /*public float leftBoundary = -10.0f;
    public float rightBoundary = 10.0f;*/
    public float xRangeBoundary = 10.0f;

    private Rigidbody playerRB;
    public GameObject projectilePref;
    

    public float jumpForse;
    public float gravityModifier;
    public bool isGrounded = true;

    public bool isGameOver = false;

    public AudioClip shootSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.8f * gravityModifier, 0);
       // Physics.gravity *= gravityModifier; // doesnt work
        //playerRB.AddForce(Vector3.up * 1000);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing on Player! Add an AudioSource component.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isPaused || PlayerManager.isGameOver)// paused procces in the shooting
            return;

        if (transform.position.x < -xRangeBoundary)
        {
            transform.position =new Vector3(-xRangeBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRangeBoundary)
        {
            transform.position = new Vector3(xRangeBoundary, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speedPlayer);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRB.AddForce(Vector3.up * jumpForse, ForceMode.Impulse);
                isGrounded = false;
            }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.K) )
        {
            Instantiate(projectilePref, transform.position, projectilePref.transform.rotation);
            //Play shooting sound
            //audioSource.PlayOneShot(shootSound);
            if (shootSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
            else
            {
                Debug.LogError("Shoot sound or AudioSource is missing! Check assignments.");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Damage the Shuttle");
            isGameOver = true;
        }

    }
}
