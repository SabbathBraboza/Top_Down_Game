using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
      [SerializeField] private TrailRenderer trail;
      [SerializeField] private Rigidbody2D body;
       private Zombie_Killed_Text Text;
      private void Reset()
      {
            trail = GetComponent<TrailRenderer>();
            body = GetComponent<Rigidbody2D>();
      }
      private void Start()
      {
            SetActive(false);
      }
      public void Fire(Vector2 Direction, float force)
      {
            SetActive(true);
            body.AddForce(Direction * force, ForceMode2D.Impulse);
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.transform.TryGetComponent(out IDamageable ID))
          {
               ID.OnDamage(100);
         
          }
        SetActive(false);
      }
      private void OnBecameInvisible()
      {
            SetActive(false);
      }

      private void SetActive(bool value)
      {
            trail.Clear();
            gameObject.SetActive(value);
      }
}
