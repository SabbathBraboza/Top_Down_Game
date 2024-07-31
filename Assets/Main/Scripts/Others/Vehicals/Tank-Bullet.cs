using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private GameObject Blood;

    private void Reset()
    {
        trail = GetComponent<TrailRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out IDamageable Id))
        {
            Instantiate(Blood, transform.position, transform.rotation);
            Id.OnDamage(100);
        }
        SetActive(false);
    }

    private void SetActive(bool value)
    {
        trail.Clear();
        gameObject.SetActive(value);
    }
}
