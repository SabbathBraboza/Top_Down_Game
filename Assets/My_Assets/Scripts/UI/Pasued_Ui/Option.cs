using System.Collections;
using System.Collections.Generic;
using TDS_UI;
using UnityEngine;


public abstract class Option<T>: MonoBehaviour
{
    [SerializeField] private Main main;
   
   
    protected virtual void Reset()
    {
        main = GetComponentInParent<Main>();
    }

    protected virtual void Awake()
    {
        main.OnInitiailze.AddListener(Initiaizle);
    }

    protected virtual void OnDestroy()
    {
        main.OnInitiailze.RemoveListener(Initiaizle);
    }

    protected abstract void Initiaizle();

    protected abstract void OnExecute(T value);
}
