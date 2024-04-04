    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Score : MonoBehaviour
{
    [SerializeField] private int Killed;
     
    private ScoreController scoreController;

    private void Awake()
    {
      scoreController = GetComponent<ScoreController>();
    }

     public void AllocateScore()
    {
        scoreController.AddScore(Killed);       
    }
}
