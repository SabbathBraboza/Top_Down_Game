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
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Fire( Vector2 Direction, float force)
    {
        rb.AddForce(Direction * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out IDamageable ID))
        {
            ID.OnDamage(4);
        }
        Destroy(gameObject);
    }

}
