using System.Collections;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Healths : MonoBehaviour
{
    [SerializeField] private int max = 100, min = 0;
    [SerializeField] private int value;
    [SerializeField] private Slider healthBar;
    [SerializeField] private int TakeDamage;
      private Animator anime;
    [SerializeField] private GameObject GameOver;

    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    public int Value() => value;
    private void Start()
    {
        healthBar.value = max;
        value=max;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            value -= TakeDamage;
            value = Mathf.Clamp(value , min, max);
            healthBar.value = value;
            if (value > 0)
            {
                anime.SetTrigger("IsHurt");
            }
            else
            {
                anime.Play("Death");
                StartCoroutine(Wait(0.8f));
            }
        }
    }
    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameOver.SetActive(true);
        gameObject.SetActive(false);
    }
}

    

