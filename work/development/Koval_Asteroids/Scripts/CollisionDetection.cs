
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Claire Koval
/// Checks if objects are colliding, spawns flowers
/// On manager object
/// </summary>

public class CollisionDetection : MonoBehaviour
{
    //ATTRIBUTES\\

    //Lists of flowers and bee bullets
    public List<GameObject> flowers;
    public List<GameObject> bees;

    //Sprites for invincibility and regular appearance
    public Sprite invincibleShip;
    public Sprite regularShip;

    //Floats for times of invincibility
    public float elapsedTime;
    public float invincibilityTime;

    public GameObject hive;


    void Start()
    {
        //Initialize lists with game objects
        flowers = new List<GameObject>();
        bees = new List<GameObject>();
        invincibilityTime = 5;
    }

    void Update()
    {

        //Check if collisions are enabled and if the game is not over
        if ((gameObject.GetComponent<ManageScoring>().collisions) && (!gameObject.GetComponent<ManageScoring>().gameOver))
        {
            elapsedTime = 0;

            //If there are flowers, check collisions
            if (flowers.Count > 0)
            {
                // Check to see if there are bees. if so, check if they are colliding with the flowers
                if (bees.Count > 0)
                {
                    for (int b = 0; b < bees.Count; b++)
                    {
                        for (int a = 0; a < flowers.Count; a++) //Check collisions for all flowers in list
                        {
                            if (CircleCollision(flowers[a], bees[b]))
                            {
                                if (flowers[a].GetComponent<DestroyFlower>().isFlower)
                                {
                                    GetComponent<ManageScoring>().score += 20; //Adjust scoring depending on what is destroyed
                                }
                                else
                                {
                                    GetComponent<ManageScoring>().score += 50;
                                }
                                flowers[a].GetComponent<DestroyFlower>().DestroyFlowerPopulateLeaves(); //Destroy flower and create dead leaves
                            }
                        }
                    }
                }
            }
            // Checks To See If Asteroids Are Colliding With The Ship And So Calls Lost Life Procedures
            for (int a = 0; a < flowers.Count; a++)
            {
                if (CircleCollision(flowers[a], hive))
                {
                    if (hive.transform.position == Vector3.zero)
                    {

                    }
                    else
                    {
                        GetComponent<ManageScoring>().LostLife();
                    }

                }
            }
            //Check to see if flowers are colliding. If so, make them "bounce" off of each other
            if (flowers.Count > 10)
            {
                for (int a = 0; a < flowers.Count - 1; a++)
                {
                    for (int b = 1; b < flowers.Count; b++)
                    {
                        if (CircleCollision(flowers[a], flowers[b]))
                        {
                            flowers[a].GetComponent<FlowerMovement>().velocity *= -1;
                            flowers[b].GetComponent<FlowerMovement>().velocity *= -1;
                        }
                    }
                }
            }

            //If there are no flowers on screen, become temporarily invincible and spawn new asteroids
            else
            {
                gameObject.GetComponent<ManageScoring>().collisions = false;
                gameObject.GetComponent<GenerateFlower>().SpawnFlowers();
                GameObject.Find("BeeHive").GetComponent<SpriteRenderer>().sprite = invincibleShip;
            }
        }

        //Run invincibility
        else
        {
            //Obly be invincible for 5sec
            elapsedTime += Time.deltaTime;
            if (elapsedTime > invincibilityTime)
            {
                gameObject.GetComponent<ManageScoring>().collisions = true;
                GameObject.Find("BeeHive").GetComponent<SpriteRenderer>().sprite = regularShip;
            }
        }
    }



    /// <summary>
    /// bool CircleCollision();
    /// Params: Takes in 2 game objects
    /// Returns: Checks if location of objects are within the pythagorean theorem location and adds the raddii
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public bool CircleCollision(GameObject a, GameObject b)
    {
        //Get information on sprites
        SpriteInfo aInfo = a.GetComponent<SpriteInfo>();
        SpriteInfo bInfo = b.GetComponent<SpriteInfo>();

        //Check location using pythagorean theorem, check if less than the sum of the radii
        if (Mathf.Sqrt((aInfo.xCoord - bInfo.xCoord) * (aInfo.xCoord - bInfo.xCoord) + (aInfo.yCoord - bInfo.yCoord) * (aInfo.yCoord - bInfo.yCoord)) < (aInfo.radius + bInfo.radius))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

