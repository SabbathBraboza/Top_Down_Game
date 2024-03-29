using System;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [Header("HIT POINTS")]
    [SerializeField] private Transform meleeHitTransform;

    [SerializeField] private LayerMask DamageableLayer;

    [SerializeField] private RaycastHit2D[] results = new RaycastHit2D[3];

    [Obsolete]
    private void Attack(float radius)
    {
        var ememies = Physics2D.CircleCastNonAlloc(meleeHitTransform.position, radius, Vector2.down, results, 0F, DamageableLayer);
      if(ememies > 0)
        {
            for ( int i=0; i < ememies; i++ ) {
                if (results[i].collider.TryGetComponent(out IDamageable ID))
                {
                    ID.OnDamage(100);
                }
                else
                {
                    Debug.Log(results[i].collider.name);
                }
               }
        }
    }
}
