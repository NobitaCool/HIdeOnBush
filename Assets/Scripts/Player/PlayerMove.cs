using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5;
    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string UP = "up";
    public const string DOWN = "down";

    string buttonPressed;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            buttonPressed = DOWN;
        }
        else
        {
            buttonPressed = null;
        }
    }

    private void FixedUpdate()
    {
        if(buttonPressed == RIGHT)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        else if(buttonPressed == LEFT)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
        else if (buttonPressed == DOWN)
        {
            rb2d.velocity = new Vector2(0, -moveSpeed);
        }
        else if (buttonPressed == UP)
        {
            rb2d.velocity = new Vector2(0, moveSpeed);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        
    }
}
