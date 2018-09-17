using UnityEngine;
using System.Collections;

/// <summary>
/// Claire Koval
/// Chooses random flower texture
/// On flower object?
/// </summary>

public class ChooseFlower : MonoBehaviour
{
    //ATTRIBUTES\\

    //Holds texture number/case number for randomly assigning sprites to the game object
    public int textureNumber;

    //The different sprites for the "asteroids" (flowers/leaves)
    public Sprite daisy;
    public Sprite daffodil;
    public Sprite sunFlower;
    public Sprite deadLeaf;


    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// void TextureFlower();
    /// Params: int texture
    /// Returns: none.
    /// Takes in integer to assign a texture to the flower game object
    /// </summary>
    /// <param name="texture"></param>
    public void TextureFlower(int texture)
    {
        textureNumber = texture;

        switch (texture)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = daisy;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = daffodil;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = sunFlower;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = deadLeaf;
                break;
            default:
                break;
        }
    }
}
