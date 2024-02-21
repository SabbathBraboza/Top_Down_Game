using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.PackageManager.UI;
using UnityEngine;


[CreateAssetMenu]
public class Input_Manager : ScriptableObject
{
     public KeyCode
        Forward = KeyCode.W,    // Moves  Up
        Backward=KeyCode.S,     // Moves Down
        left=KeyCode.A,         // Moves Left
        Right = KeyCode.D;      // Moves Right

    public KeyCode Switch = KeyCode.C;  // Used to Switch between Character

    public KeyCode Fire= KeyCode.Mouse0;

    public KeyCode Bat = KeyCode.Alpha1;               
    public KeyCode Knife = KeyCode.Alpha2;       
    public KeyCode Pistol = KeyCode.Alpha3;
    public KeyCode Rifle = KeyCode.Alpha4;
    public KeyCode FlameThrower = KeyCode.Alpha5;

    public KeyCode this[string keyname]
    {
        get => keyname switch
        {
            nameof(Forward) => Forward,
            "Back" => Backward,
            "Left" => left,
            "Right" => Right
        };
        set
        {
            switch (keyname)
                {
                case "Forward": Forward = value; break;
                case "Backward": Backward = value;break;
                case "Left": left = value; break;
                case "Right": Right = value; break;
            }
        }
    }

}
