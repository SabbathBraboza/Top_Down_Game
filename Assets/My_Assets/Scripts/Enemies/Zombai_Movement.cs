using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombai_Movement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float RotationSpeed;

    private Rigidbody2D rb;

    private Player_Persents Player_PersentsController;

    private Vector2 TargetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player_PersentsController = GetComponent<Player_Persents>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotationTowardsTarget();
        SetVeclocity();
    }

    private void UpdateTargetDirection()
    {
        if (Player_PersentsController.AwareOfPlayer) TargetDirection = Player_PersentsController.DirectionToPlayer;
        else TargetDirection = Vector2.zero;
    }

   private void RotationTowardsTarget()
    {
        if (TargetDirection == Vector2.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(transform.up, TargetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVeclocity()
    {
        if (TargetDirection == Vector2.zero) rb.velocity = Vector2.zero;
        else rb.velocity = transform.up * Speed;
    }
}

