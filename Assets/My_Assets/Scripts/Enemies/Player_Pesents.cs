using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Persents : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; } 
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float PlayerAwarenessDistance;
    private Transform Player;


    void Start()
    {
        Player = FindAnyObjectByType<Character>().transform;
    }

    void Update()
    {
        Vector2 EnemyToPlayerVector = Player.position - transform.position;
        DirectionToPlayer = EnemyToPlayerVector.normalized;

        if (EnemyToPlayerVector.magnitude <= PlayerAwarenessDistance) AwareOfPlayer = true;
        else AwareOfPlayer = false;
          
    }
}
