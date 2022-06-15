using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;

    void Start()
    {
        
    }

    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}


