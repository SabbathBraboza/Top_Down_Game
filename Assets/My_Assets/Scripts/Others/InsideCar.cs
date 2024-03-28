using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class InsideCar : MonoBehaviour, Useable
{
    public UnityEvent OnEnter, OnExit;
    public Transform exitPoint; // A transform representing where the character should exit to.
    public float exitDistanceThreshold = 1f;


    public void Exit()
    {
    
    }

    public void Use()
    {
        OnEnter.Invoke();
    }  
}
