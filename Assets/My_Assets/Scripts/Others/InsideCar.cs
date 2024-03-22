using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class InsideCar : MonoBehaviour
{

    public UnityEvent OnEnter;
  
    public void Use()
    {
        OnEnter.Invoke();
    }

}
