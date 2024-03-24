using System;
using UnityEngine;
using UnityEngine.UI;
public class Zombie_Killed_Text : MonoBehaviour
{
    private int Zombai = 0;

    [SerializeField] private Text ZombiesText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Bullet bullet = gameObject.GetComponent<Bullet>();
            if (bullet != null)
            { 
                Zombai++;
                ZombiesText.text = "Zombies Killed: " + Zombai.ToString();
            }
        }
    }
}
