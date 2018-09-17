using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Destroys flower object and spawns leaves
/// On flower prefab
/// </summary>

public class DestroyFlower : MonoBehaviour
{
    //ATTRIBUTES\\

    public bool isFlower; //Boolean to determine if it is a flower or leaf
    private int leaves;
    public GameObject leaf;    

    void Start()
    {
    }

    void Update()
    {

    }

    /// <summary>
    /// void DestroyFlowerPopulateLeaves();
    /// Params: none.
    /// Returns: none.
    /// Destroys game object, if game object is a flower, populates leaves
    /// </summary>
    public void DestroyFlowerPopulateLeaves()
    {
        //Remove flower from list of flowers in collision detection component
        GameObject.Find("Manager").GetComponent<CollisionDetection>().flowers.Remove(gameObject);

        //If object is a flower, destroy the flower and add leaves
        if (isFlower)
        {
            int randLeaves = Random.Range(2, 5);
            for (int i = 0; i < randLeaves; i++)
            {
                GameObject newLeaf = GameObject.Instantiate(leaf, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation);
                newLeaf.GetComponent<ChooseFlower>().TextureFlower(4);
                newLeaf.GetComponent<FlowerMovement>().velocity = new Vector3(gameObject.GetComponent<FlowerMovement>().velocity.x + Random.Range(-.05f, .05f), gameObject.GetComponent<FlowerMovement>().velocity.y + Random.Range(-.05f, .05f));
            }
            isFlower = false;
            Destroy(gameObject);
        }
        else
        {
            isFlower = false;
            Destroy(gameObject);
        }
    }
}
