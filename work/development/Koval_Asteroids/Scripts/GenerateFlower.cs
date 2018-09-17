using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Generates flower prefab with randomly assigned sprite texture
/// On manager object
/// </summary>

public class GenerateFlower : MonoBehaviour
{
    //ATTRIBUTES\\

    private int startingFlowers;
    public GameObject flower;


    void Start()
    {
        SpawnFlowers();
    }

    void Update()
    {

    }

    /// <summary>
    /// void SpawnFlowers();
    /// Params: none.
    /// Returns: none.
    /// Randomly spawns 5-10 flowers and randomly assigns their texture
    /// </summary>
    public void SpawnFlowers()
    {
        // Sets A Random Number Of Asteroids To Spawn
        startingFlowers = (int)Random.Range(10, 15);

        for (int a = 0; a < startingFlowers; a++)
        {
            GameObject asteroid = (GameObject)Instantiate(flower, new Vector3(Random.Range(-6, 6), Random.Range(-6, 6)), gameObject.transform.rotation);
            asteroid.GetComponent<ChooseFlower>().TextureFlower(Random.Range(0, 4)); //Randomly assign a Sprite for the Game Object
            asteroid.GetComponent<FlowerMovement>().velocity = new Vector3(Random.Range(-.01f, .01f), Random.Range(-.01f, .01f)); //Move flower randomly
        }
    }
}