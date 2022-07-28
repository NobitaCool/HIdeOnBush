using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelidOfView : MonoBehaviour
{

    [SerializeField]
    Transform castpoint;
    [SerializeField]
    Transform player;
    [SerializeField]
    float argroRange;
    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    bool isFacingleft;
    private bool isAgro = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distoPlayer = Vector2.Distance(transform.position, player.position);

        if (distoPlayer < argroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

        //if (CanSeePlayer(argroRange))
        //{
        //    isAgro = true;
        //    ChasePlayer();
        //}
        //else
        //{
        //    if(isAgro)
        //    {
        //        Invoke("StopChasingPlayer", 3);
        //    }

        //}
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if(isFacingleft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castpoint.position + Vector3.right * distance;

        RaycastHit2D hit = Physics2D.Linecast(castpoint.position, endPos , 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(castpoint.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(castpoint.position, endPos, Color.red);
        }
        return val;
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            isFacingleft = false;
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            isFacingleft = true;
        }
        else if (transform.position.y < player.position.y)
        {
            rb2d.velocity = new Vector2(0, moveSpeed);
            transform.localScale = new Vector2(1, 1);
            isFacingleft = false;
        }
        else if (transform.position.y > player.position.y)
        {
            rb2d.velocity = new Vector2(0, -moveSpeed);
            transform.localScale = new Vector2(1, 1);
            isFacingleft = true;
        }
        
    }
    void StopChasingPlayer()
    {
        isAgro = false;
        rb2d.velocity = new Vector2(0, 0);
    }
}
