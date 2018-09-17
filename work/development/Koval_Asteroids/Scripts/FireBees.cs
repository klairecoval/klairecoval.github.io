using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Checks if enough time has passed to avoid spamming bees, fires them.
/// On hive object
/// </summary>

public class FireBees : MonoBehaviour
{

    //ATTRIBUTES\\
    public GameObject shooterBee;
    public GameObject gameManager;

    //Floats for timing to prevent rapid fire
    private float timeElapsed;
    private float timeToFire;

    //Booleam to check if bee/bullet can be fired
    private bool canFire;

    //Audio Information For Laser Sound
    private AudioSource audio;
    public AudioClip pew;


    void Start()
    {
        canFire = true;
        timeElapsed = 0;
        timeToFire = 0.5f;

        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Check if the space bar is pressed. if it is, creates a bee object that moves in the direction the hive is pointing
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canFire)
        {
            Debug.Log("pew pew");
            //Instantiate and position bee, set velocity
            GameObject bee = (GameObject)Instantiate(shooterBee, gameObject.transform.position, gameObject.transform.rotation);
            gameManager.GetComponent<CollisionDetection>().bees.Add(bee);
            shooterBee.GetComponent<MoveBees>().velocity = gameObject.GetComponent<HiveMovement>().direction * .15f;
            //Play pew sound
            audio.PlayOneShot(pew, 0.7f);
            canFire = false;
        }
        // Tracks Firing Delay And Resets Laser When Complete
        else
        {
            //Check time elapsed against time of frames to toggle firing boolean
            timeElapsed += Time.deltaTime;

            if (timeElapsed > timeToFire)
            {
                timeElapsed = 0;
                canFire = true;
            }
        }
    }
}
