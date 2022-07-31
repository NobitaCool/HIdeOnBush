using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variable
        #region movement
            [SerializeField] private float speed;            
            [SerializeField] private float waitTime;
            [SerializeField] private Collider2D visible;
            [SerializeField] private Collider2D player;
            [SerializeField] private bool isChasing = false;
            [SerializeField] private NavMeshAgent navMesh;

            private float lastTime;
            private bool isMovingRight;
            private bool isMovingUP;
            private bool isHorizontal;
        #endregion

        #region destination
            [SerializeField] private Transform[] points;
            [SerializeField] private int curIndex = 0;
        #endregion

        #region animation
            private Animator enemyAnim;
        #endregion
    #endregion
    private void OnValidate() 
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        enemyAnim = GetComponentInChildren<Animator>();
    }         

    private void Update()
    {
        if (!isChasing) Patrolling();     

        if (isChasing) Chasing();
    }

    private void UpdateDestination() => curIndex = (curIndex < points.Length - 1) ? ++curIndex : 0;

    private void Chasing() => navMesh.SetDestination(player.gameObject.transform.position);

    private void Patrolling()
    {
        // di chuyển thông thường
        transform.position = Vector2.MoveTowards(transform.position, points[curIndex].position, speed * Time.deltaTime);  

        // PlayAnimation();
        PlayAnimation();

        if (transform.position != points[curIndex].position) return;

        if(Time.time - lastTime < waitTime) return; 
        
        UpdateDestination();
        lastTime = Time.time;

        // phát hiện player
        isChasing = visible.IsTouching(player) ? true : false;

        if(isChasing) visible.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.6f);
    }

    private void PlayAnimation()
    {
        // Tìm hướng
        Vector3 direction = points[curIndex].position - transform.position;

        isHorizontal = (Vector3.Angle(direction, Vector3.right) % 180 == 0)? true : false;

        isMovingRight = (Vector3.Angle(direction, Vector3.right) == 0)? true : false;

        isMovingUP = (Vector3.Angle(direction, Vector3.up) == 0)? true : false;

        enemyAnim.SetBool("isHorizontal", isHorizontal);

        enemyAnim.SetBool("isMovingRight", isMovingRight);
           
        enemyAnim.SetBool("isMovingUp", isMovingUP);    

        var angle = Vector3.Angle(direction, Vector3.up); 

        if(isMovingRight) angle *= -1;

        visible.gameObject.transform.eulerAngles = Vector3.forward * angle;   
    }
}
