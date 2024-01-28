using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire( Vector2 Direction, float force)
    {
        rb.AddForce(Direction * force, ForceMode2D.Impulse);
    }

}
