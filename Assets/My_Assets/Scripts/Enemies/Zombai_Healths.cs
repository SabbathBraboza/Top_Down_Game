using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Zombai_Healths : MonoBehaviour, IDamageable
{
    private Animator anime;
    private float delay = 0.4f;
    [field: SerializeField, Min(0)] public int max { set; private get; } = 100;
    [SerializeField, ReadOnly] private int value;
    [SerializeField, Range(0f, 5f)] private int damageMultipler = 1;
    public int Value() => value;

    private void Awake()=> anime = GetComponent<Animator>();
    private void Start()=> value = max;
    void IDamageable.OnDamage(int amount)
    {
        value = Mathf.Clamp(value - amount * damageMultipler, 0, max);
        if (value <= 0)
        {
            anime.SetBool("IsDead",true);
            StartCoroutine(IsDestroy());
        }
    }
    IEnumerator IsDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }    
}



