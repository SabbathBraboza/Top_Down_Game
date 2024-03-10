using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, Useable
{
    [SerializeField] private Transform Inside, Outside;
    public UnityEvent<bool> Onuse;
    private bool Value;
    public void Use()
    {
      Onuse.Invoke(Value = !Value);   
    }

    public void  MovePlayer(Transform player)
    {
        player.position = Value ? Inside.position : Outside.position;
    }
}
