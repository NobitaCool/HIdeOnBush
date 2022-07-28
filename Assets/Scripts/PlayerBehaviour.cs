using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    #region Variable
        #region private
            [SerializeField] private BoxCollider2D boxCollider2D;
            [SerializeField] private Vector3 moveDelta;
            [SerializeField] private RaycastHit2D hit;
            [SerializeField] private GameObject playerSprite;
            [SerializeField] private GameObject treeSprite;
            private bool isMoving;
            private float opacity;
        #endregion
        #region public
            public Joystick joystick;
        #endregion
    #endregion
    
    
    private void OnValidate()
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

        isMoving = (moveDelta == Vector3.zero)? false : true;

        // Biến thành cây
        // playerSprite.SetActive(isMoving);
        // treeSprite.SetActive(!isMoving);

        // Tàng hình
        opacity = isMoving? 1.0f : 0.4f;
        playerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opacity); 

        if(!isMoving) return;

        transform.localScale = (moveDelta.x > 0) ? Vector3.one : new Vector3(-1, 1, 1);

        //Draw racycast to check for collider
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
