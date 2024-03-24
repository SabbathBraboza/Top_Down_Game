using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class InsideCar : MonoBehaviour,Useable
{
    public UnityEvent OnEnter, OnExit; 
    public void Use()
    {
        OnEnter.Invoke();
    }  
}
