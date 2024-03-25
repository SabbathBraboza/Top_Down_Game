using System;
using UnityEngine;
using UnityEngine.UI;
public class Zombie_Killed_Text : MonoBehaviour
{
    [SerializeField]public int ZombieKilled = 0;
    [SerializeField] private Text ZombieKilledText;

    private void Update()
    {
        ZombieKilledText.text = "Zombies Killed :" + ZombieKilled;
    }
}
