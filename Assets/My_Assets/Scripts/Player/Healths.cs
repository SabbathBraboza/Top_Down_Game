using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Healths : MonoBehaviour, IDamageable
{
    private Animator anime;
    [field: SerializeField, Min(0)] public int max { set; private get; } = 100;
    [SerializeField, ReadOnly] private int value;
    [SerializeField, Range(0f, 5f)] private int damageMultipler = 1;
    [SerializeField] private Slider HealthBar;
   
    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    public int Value() => value;
    private void Start()
    {
        HealthBar.value = max;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            HealthBar.value -= 25;
          if(value < 0 )
            {
               Destroy(gameObject);
                
            }
        }
    }
    void IDamageable.OnDamage(int amount)
    {
        value = Mathf.Clamp(value - amount * damageMultipler, 0, max);
        if (value <= 0)
        {

        }
    }
}

    

