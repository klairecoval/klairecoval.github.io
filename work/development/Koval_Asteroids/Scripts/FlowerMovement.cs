using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Moves flowers around the screen. Rotates them
/// On flower prefab
/// </summary>

public class FlowerMovement : MonoBehaviour
{
    //ATTRIBUTES\\

    // Vectors for flower movement
    private Vector3 flowerLoc;
    public Vector3 velocity;
    public Vector3 direction;

    //Variables to handle rotation of flower
    public float angleOfRotation;
    public bool clockwiseRotation;

    //Camera attributes
    Camera cam;
    float height;
    float width;

    void Start()
    {
        //Set location of flower to the game objects position, instantiate
        flowerLoc = gameObject.transform.position;
        GameObject.Find("Manager").GetComponent<CollisionDetection>().flowers.Add(gameObject);
        angleOfRotation = 0f;
        velocity = new Vector3(0.01f, 0.01f, 0); //Move relativeley slowly

        //Choose direction to rotate flower
        clockwiseRotation = false;
        if ((int)Random.Range(1, 2) == 1)
        {
            clockwiseRotation = true;
        }

        //Set height and width of screen according to camera properties
        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        //Call those helper functions!
        RotateFlower();
        Bounce();
        Glide();
        SetTransform();
    }

    /// <summary>
    /// void Glide();
    /// Params: none.
    /// Returns: none.
    /// Add velocity to flower location to move them around
    /// </summary>
    void Glide()
    {
        flowerLoc += velocity;
    }

    /// <summary>
    /// void Bounce();
    /// Params: none.
    /// Returns: none.
    /// Check position of flower. If it is going out of camera view, bounce if off the side
    /// </summary>
    void Bounce()
    {
        // Checks To See If The Asteroid Is Hitting The Side
        if (flowerLoc.x > width || flowerLoc.x < -width)
        {
            velocity = new Vector3(-1 * velocity.x, velocity.y);
        }
        else if (flowerLoc.y > height || flowerLoc.y < -height)
        {
            velocity = new Vector3(velocity.x, -1 * velocity.y);
        }
    }

    /// <summary>
    /// void RotateFlower();
    /// Params: none.
    /// Returns: none.
    /// Check which direction to rotate the flower and choose direction accordingly
    /// </summary>
    void RotateFlower()
    {
        if (clockwiseRotation)
        {
            angleOfRotation += 1f;
        }
        else
        {
            angleOfRotation -= 1f;
        }
    }

    /// <summary>
    /// void SetTransform();
    /// Params: none.
    /// Returns: none.
    /// Set rotation and position of the flower
    /// </summary>
    void SetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
        transform.position = flowerLoc;
    }
}
