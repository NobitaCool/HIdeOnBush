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
        #endregion

        #region destination
            [SerializeField] private Transform[] points;
            [SerializeField] private int curIndex = 0;
    #endregion
    #endregion
    private void OnValidate() => navMesh = GetComponent<NavMeshAgent>();

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

        // di chuyển AI
        // navMesh.SetDestination(points[curIndex].position);

        if (transform.position != points[curIndex].position) return;

        Invoke(nameof(UpdateDestination), waitTime);

        isChasing = visible.IsTouching(player) ? true : false;
    }
}
