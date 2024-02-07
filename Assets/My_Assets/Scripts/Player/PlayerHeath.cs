using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{

    public int health;
    public int maxhealth = 50;

    private Animator anime;

    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    private void Start()
    {
        health = maxhealth;
    }

    public void TakeDamge(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            StartCoroutine(death());
        }
    }

   private IEnumerator death()
    {
        yield return new WaitForSeconds(1f);
        anime.Play("Death");
    }
}

