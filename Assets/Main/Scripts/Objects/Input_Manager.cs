using UnityEngine;

using static UnityEngine.KeyCode;

[CreateAssetMenu]
public class Input_Manager : ScriptableObject
{
 
    [Header("M O V E M E N T")]
    public KeyCode
        Forward = W,    // Moves  Up
        Backward=S,     // Moves Down
        left=A,         // Moves Left
        Right = D;      // Moves Right

    [Header("A C T I O N S")]
    public KeyCode Switch = C;  
    public KeyCode Fire= Mouse0;
    public KeyCode FlashLigth = F;
    public KeyCode ToInteract = Q;

    [Header("W E A P O N S")]
    public KeyCode Bat = Alpha1;               
    public KeyCode Knife = Alpha2;       
    public KeyCode Pistol = Alpha3;
    public KeyCode Rifle = Alpha4;
    public KeyCode FlameThrower = Alpha5;

    [Header("U I")]
    public KeyCode Pause = Escape;


    public bool IsAnyAxisKeyPressedOrReleased => Input.GetKeyDown(Forward) || Input.GetKeyDown(Backward) ||
        Input.GetKeyDown(left) || Input.GetKeyDown(Right) || Input.GetKeyUp(Forward) || Input.GetKeyUp(Backward) || Input.GetKeyUp(left) || Input.GetKeyUp(Right);

   

    public KeyCode this[string keyname]
    {
        get => keyname switch
        {
            nameof(Forward) => Forward,
            nameof(Backward) => Backward,
            nameof(left) => left,
            nameof(Right) => Right,
            nameof(Switch) => Switch,
            nameof(Fire) => Fire,
            nameof(Bat) => Bat,
            nameof(Knife) => Knife,
            nameof(Pistol) => Pistol,
            nameof(Rifle) => Rifle,
            nameof(FlameThrower) => FlameThrower,
            nameof(FlashLigth) => FlashLigth,
            nameof(ToInteract) => ToInteract,
            _ => None
        };
        set
        {
            switch (keyname)
                {
                case nameof(Forward): Forward = value; break;
                case nameof(Backward): Backward = value; break;
                case nameof(left): left = value; break;
                case nameof(Right): Right = value; break;
                case nameof(Switch): Switch = value; break;
                case nameof(Fire): Fire = value; break;
                case nameof(Bat): Bat = value; break;
                case nameof(Knife): Knife = value; break;
                case nameof(Pistol): Pistol = value; break;
                case nameof(Rifle): Rifle = value; break;
                case nameof(FlameThrower): FlameThrower = value; break;
                case nameof(FlashLigth): FlashLigth = value; break;
                case nameof(ToInteract):ToInteract = value; break;

            }
        }
    }

}
