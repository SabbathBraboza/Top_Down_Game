using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombai_Army : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Rigidbody2D rb;
    [SerializeField] private float Speed;
    private Vector2 Movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.y)  * Mathf.Rad2Deg;
        Movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(Movement);
    }

    private void MoveCharacter(Vector2 Moving) => rb.MovePosition((Vector2)transform.position + (Speed * Time.deltaTime * Moving));
}
