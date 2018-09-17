using UnityEngine;
using System.Collections;

/// <summary>
/// Claire Koval
/// Gets attributes of Sprites
/// Placed on all Sprites
/// </summary>

public class SpriteInfo : MonoBehaviour
{
    //Attributes\\
    public Sprite sprite;

    //For sprite location
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    //For sprite circle location
    public float radius;
    public float xCoord;
    public float yCoord;


    void Start()
    {
        //Get sprite info from the sprite the script is on
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        //Set x and y coordinates equal to the sprites x and y position
        xCoord = gameObject.transform.position.x;
        yCoord = gameObject.transform.position.y;

        //Set min and max values using the sprite bounds plus the location of the sprite
        xMin = xCoord + sprite.bounds.min.x;
        yMin = yCoord + sprite.bounds.min.y;
        xMax = xCoord + sprite.bounds.max.x;
        yMax = yCoord + sprite.bounds.max.y;

        //For circle collisions, check sprite bounds and set radius accordingly
        if (sprite.bounds.max.x < sprite.bounds.max.y)
        {
            radius = sprite.bounds.max.x;
        }
        else
        {
            radius = sprite.bounds.max.y;
        }
    }
}