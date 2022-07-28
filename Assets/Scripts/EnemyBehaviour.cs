using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] points;
    [SerializeField] private int curIndex = 0;
    [SerializeField] private float waitTime;
    [SerializeField] private Collider2D visible;
    [SerializeField] private Collider2D player;
    [SerializeField] private bool isChasing = false;
    [SerializeField] private NavMeshAgent navMesh;
    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
    }

    private void Update()
    {
        if(!isChasing) Patrolling();

        if(isChasing) Chasing();
    }

    private void UpdateDestination() => curIndex = (curIndex < points.Length - 1) ? ++curIndex : 0;

    private void Chasing() => navMesh.SetDestination(player.gameObject.transform.position);

    private void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[curIndex].position, speed * Time.deltaTime);

        if(transform.position != points[curIndex].position) return;

        Invoke(nameof(UpdateDestination), waitTime);

        isChasing = visible.IsTouching(player)? true : false;
    }
}
