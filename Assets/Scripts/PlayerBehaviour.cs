using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public Joystick joystick;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        //reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction when going left or right
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0,moveDelta.y*Time.deltaTime,0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x*Time.deltaTime, 0, 0);
        }

    }
}
