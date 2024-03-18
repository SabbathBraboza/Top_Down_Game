using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Zombai_Healths : MonoBehaviour, IDamageable
{
    private Animator anime;
    public UnityEvent OnDeath, OnDamage;
    [field: SerializeField, Min(0)] public int max { set; private get; } = 100;
    [SerializeField, ReadOnly] private int value;
    [SerializeField, Range(0f, 5f)] private int damageMultipler = 1;
   //

    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    public int Value() => value;
    private void Start()
    {
        
        value = max;
    }

    void IDamageable.OnDamage(int amount)
    {
        value = Mathf.Clamp(value - amount * damageMultipler, 0, max);
        if (value <= 0)
        {
            anime.SetBool("Dead", true);
            Destroy(gameObject);
        }
        else
        {
            OnDamage.Invoke();
        }
    }
}



