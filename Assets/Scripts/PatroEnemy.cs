using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroEnemy : MonoBehaviour
{

    public float speed;
    public Transform[] patroPoints;
    public float waitTime;
    int currentPointIndex;

    bool once;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != patroPoints[currentPointIndex].position)
        {
           transform.position = Vector2.MoveTowards(transform.position, patroPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            //if(once == false)
            //{
            //    once = true;
            //    StartCoroutine(Wait());
            //}
            Invoke("Wait2", waitTime);        
            
        }
    }

    private void Wait2()
    {
        if (currentPointIndex < patroPoints.Length - 1)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
    }

    IEnumerator Wait()
    {
        if(currentPointIndex < patroPoints.Length - 1)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        yield return new WaitForSeconds(waitTime);
        
    }
}
