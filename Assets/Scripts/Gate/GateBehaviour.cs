using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float minRangeX;
    [SerializeField] private float maxRangeX;
    [SerializeField] private float minRangeY;
    [SerializeField] private float maxRangeY;


    public int Health
    {
        get 
        {
            return health;
        }
        set
        {
            health = value;
            if(Health == 0)
            {
                GetComponent<CircleCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            Debug.Log(health);
        }
    }
    [SerializeField] private GameObject[] trees;

    private void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");

        var posX = Random.Range(minRangeX, maxRangeX);
        var posY = Random.Range(minRangeY, maxRangeY);
        transform.position = new Vector3(posX, posY, 0);

        Health = trees.Length;
    }

    public void HealthChange()
    {
        Health--;
    }
}
