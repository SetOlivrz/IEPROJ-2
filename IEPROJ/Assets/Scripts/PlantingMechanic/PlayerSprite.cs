using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] Sprite Up;
    [SerializeField] Sprite Down;
    [SerializeField] Sprite Right;
    [SerializeField] Sprite Left;

    string PlayerDirection;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDirection = "DOWN";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerDirection = "UP";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerDirection = "DOWN";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerDirection = "LEFT";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerDirection = "RIGHT";
        }

        ChangeSprite();
    }

    void ChangeSprite()
    {
        switch (PlayerDirection)
        {
            case "UP": this.GetComponent<SpriteRenderer>().sprite = Up; break;
            case "DOWN": this.GetComponent<SpriteRenderer>().sprite = Down; break;
            case "LEFT": this.GetComponent<SpriteRenderer>().sprite = Left; break;
            case "RIGHT": this.GetComponent<SpriteRenderer>().sprite = Right; break;
        }
    }
}
