using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Zombie_Killed_Text : MonoBehaviour
{
    [SerializeField]public int ZombieKilled;
    [SerializeField] private Text ZombieKilledText;

    public void UpdateScore(int pointsToAdd)
    {
        ZombieKilled += pointsToAdd;
        ZombieKilledText.text = "Zombie Killed: " + ZombieKilled.ToString();
    }

}
