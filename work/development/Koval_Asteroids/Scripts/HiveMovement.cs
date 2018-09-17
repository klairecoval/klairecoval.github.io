using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Moves hive in direction set by arrow keys
/// Attatched to hive
/// </summary>

public class HiveMovement : MonoBehaviour
{
    //Attributes\\
    //Get local reference to vehical position
    public Vector3 hivePos;

    //Speed of vehicle - how many units per second
    public float speed = 1f;

    //Vectors and angles 
    public Vector3 velocity;
    public Vector3 direction;
    public Vector3 acceleration;
    public Quaternion angle;

    //Floats for movement
    public float angleOfRotation;
    public float accelRate;
    public float maxSpeed;

    //Camera attributes
    Camera cam;
    float height;
    float width;


    void Start()
    {
        //Start all vectors at initial value of (0,0,0)
        hivePos = Vector3.zero;
        velocity = Vector3.zero;

        //Position car upwards
        direction = Vector3.up;

        //Set angle at zero for starting
        angle = Quaternion.Euler(0, 0, 0);

        angleOfRotation = 0f;
        accelRate = 0.02f;
        maxSpeed = 1f;

        //Set height and width of screen according to camera properties
        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        //Call those helper functions!
        RotateHive();
        MoveHive();
        WrapHive();
        SetTransform();
    }

    /// <summary>
    /// void DriveVehicle();
    /// Params: none.
    /// Returns: none.
    /// Calculate the velocity and resulting position of the vehicle when UP ARROW pressed
    /// </summary>
    void MoveHive()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            acceleration = accelRate * direction * Time.deltaTime; //The time it took to complete last frame
            velocity += acceleration; //Accellerate
        }
        else
        {
            velocity = velocity * 0.99f; //Decellerate
        }

        //Make sure length is no larger than given argument 
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        hivePos += velocity;
    }

    /// <summary>
    /// void WrapVehicle();
    /// Params: none.
    /// Returns: none.
    /// Reposition this vehicle so it's always on screen by checking x and y positions against height and width of camera
    /// </summary>
    void WrapHive()
    {
        if (hivePos.x > width || hivePos.x < -width)
        {
            hivePos.x = -hivePos.x;
        }
        else if (hivePos.y > height || hivePos.y < -height)
        {
            hivePos.y = -hivePos.y;
        }
    }

    /// <summary>
    /// void RotateVehicle();
    /// Params: none.
    /// Returns: none.
    /// Rotate the direction the vehicle is pressing if user is pressing LEFT or RIGHT arrow keys
    /// </summary>
    void RotateHive()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Quaternion.Euler(0, 0, 1) * direction; //Rotate clockwise
            angleOfRotation += 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Quaternion.Euler(0, 0, -1) * direction; //Rotate counter-clockwise
            angleOfRotation -= 1f;
        }
    }

    /// <summary>
    /// void SetTransform();
    /// Params: none.
    /// Returns: none.
    /// Set the transformation for the rotation
    /// </summary>
    void SetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
        transform.position = hivePos; //Set vehicle position at the new transformed position based on angle
    }
}