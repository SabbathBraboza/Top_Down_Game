using System.Collections;
using System.Collections.Generic;
using TDS_Player;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public UnityEvent<bool> InControl;
   
    public void OnEnable()
    {
        InControl.Invoke(true);
    }

    private void OnDisable()
    {
        InControl.Invoke(false);   
    }
}
