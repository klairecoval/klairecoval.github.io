using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Claire Koval
/// Manages scoring and checks how many lives the hive has left
/// On manger object
/// </summary>

public class ManageScoring : MonoBehaviour
{
    //ATTRIBUTES\\

    //Ints to hold number of lives, number of initial flowers, and score
    private int lives;
    private int startingFlowers;
    public int score;

    public GameObject flower;

    //Booleans for invincibility and game over
    public bool collisions;
    public bool gameOver;

    //String to hold rank of player, based on score
    private string rank;


    void Start()
    {
        //Start game in invincibility mode, collisions have no effect on the hice and lives
        collisions = false;
        gameOver = false;

        //Set initial number of lives, score, and rank
        lives = 3;
        score = 0;
        rank = "ROOT";
    }

    void Update()
    {
        if (score >= 1000 && score < 2000)
        {
            rank = "WEED";
        }
        if (score >= 2000 && score < 3000)
        {
            rank = "VINE";
        }
        if (score >= 3000 && score < 4000)
        {
            rank = "SPROUT";
        }
        if (score >= 4000 && score < 5000)
        {
            rank = "SAPLING";
        }
        if (score >= 5000 && score < 6000)
        {
            rank = "LEGUME";
        }
        if (score >= 6000 && score < 8000)
        {
            rank = "SUCCULENT";
        }
        if (score >= 8000 && score < 9000)
        {
            rank = "BAMBOO";
        }
        if (score >= 10000)
        {
            rank = "MIGHTY OAK";
        }
    }

    /// <summary>
    /// void OnGUI();
    /// Params: none.
    /// Returns: none.
    /// Make on screen box telling user what keys to use for controls, if game over, provide results and score
    /// </summary>
    private void OnGUI()
    {
        // Checks For Game Over And If So Displays Message To Restart
        if (gameOver)
        {
            GUI.color = Color.yellow;
            GUI.skin.box.fontSize = 12;
            GUI.Box(new Rect(20, 10, 160, 70), "Game Over! Restart To Play Again!\nYour Rank Was " + rank + " With " + score + " Points!");
        }
        else
        {
            GUI.color = Color.yellow;
            GUI.skin.box.fontSize = 12;
            GUI.Box(new Rect(10, 90, 160, 70), "Score: " + score + "\nLives: " + lives + "     Rank: " + rank);
            GUI.Box(new Rect(10, 10, 160, 70), "Use LEFT and RIGHT arrow keys to rotate. Use UP-ARROW to move. Press SPACE to fire.");
            GUI.skin.box.wordWrap = true;
        }
    }

    /// <summary>
    /// void LostLife();
    /// Params: none.
    /// Returns: none.
    /// Checks if a collision has occured. If so, removes a life and checks for end of game
    /// </summary>
    public void LostLife()
    {
        //Give temporary invincibility
        collisions = false;
        lives--;

        // checks For End Game
        if (lives == 0)
        {
            GameOver();
        }

        //Provide temporary invincibility
        GameObject.Find("BeeHive").GetComponent<SpriteRenderer>().sprite = GetComponent<CollisionDetection>().invincibleShip;

        //Reset hive to original spawning position
        GameObject.Find("BeeHive").GetComponent<HiveMovement>().hivePos = Vector3.zero;
        GameObject.Find("BeeHive").GetComponent<HiveMovement>().velocity = Vector3.zero;
        GameObject.Find("BeeHive").GetComponent<HiveMovement>().acceleration = Vector3.zero;
        GameObject.Find("BeeHive").GetComponent<HiveMovement>().acceleration = Vector3.up;
    }

    /// <summary>
    /// void GameOver();
    /// Params: none.
    /// Returns: none.
    /// Checks if game is over based on number of lives passed in from lost life
    /// </summary>
    public void GameOver()
    {
        gameOver = true;

        //Destroy hive
        Destroy(GameObject.Find("BeeHive"));
    }
}
