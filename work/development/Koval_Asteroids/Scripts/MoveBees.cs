using UnityEngine;
using System.Collections;

/// <summary>
/// Claire Koval
/// Moves bee object according to direction hive is pointing
/// On bee prefab
/// </summary>

public class MoveBees : MonoBehaviour
{
    //ATTRIBUTES\\

    //Vectors for the bee movement
    public Vector3 beeLoc;
    public Vector3 velocity;
    public GameObject hive;
    public Vector3 direction;

    public float speed;
    public float angleOfRotation;

    //Camera attributes
    Camera cam;
    float height;
    float width;


    void Start()
    {
        //Initialize values 
        beeLoc = transform.position;
        velocity = new Vector3(0, 0, 0);
        speed = 5;

        //Get reference to bee object, inherit angle of rotation and direction for the bee from the hive
        hive = GameObject.Find("BeeHive");
        angleOfRotation = hive.GetComponent<HiveMovement>().angleOfRotation;
        direction = hive.GetComponent<HiveMovement>().direction;

        //Set height and width of screen according to camera properties
        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        //Call those helper functions!
        Edge();
        SetTransform();
    }

    /// <summary>
    /// void Edge();
    /// Params: none.
    /// Returns: none.
    /// Checks bee location, if it is going out of camera view, it destroys the bee object
    /// </summary>
    void Edge()
    {
        if (beeLoc.x > width || beeLoc.x < -width)
        {
            GameObject.Find("Manager").GetComponent<CollisionDetection>().bees.Remove(gameObject);
            Destroy(gameObject);
        }
        else if (beeLoc.y > height || beeLoc.y < -height)
        {
            GameObject.Find("Manager").GetComponent<CollisionDetection>().bees.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// void SetTransform();
    /// Params: none.
    /// Returns: none.
    /// Sets attrubutes of bee according to the inherited values from the hive
    /// </summary>
    void SetTransform()
    {
        velocity = (direction.normalized * speed);
        beeLoc += velocity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
        transform.position = beeLoc;
    }
}