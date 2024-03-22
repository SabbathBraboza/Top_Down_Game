using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TDS_Player
{ 
public class Animation : MonoBehaviour
{
    private Animator anime;
    public  Input_Manager keys;
    private Controller Control;


        private readonly int
            SwitchHash = Animator.StringToHash("Switch"),
            WeaponeIdHash = Animator.StringToHash("Weapon ID");
        private readonly int paceHash = Animator.StringToHash("Pace");

        public UnityAction<int> OnSwitch;

        [SerializeField] private int _weaponID;

        public int Weapon => _weaponID;    

        public int SetWeapon
        {   
            set
            {
                _weaponID = value;

                OnSwitch.Invoke(_weaponID);
                anime.SetInteger(WeaponeIdHash, _weaponID);
                anime.SetTrigger(SwitchHash);
            }
        }

     private void Awake()
    {
        Control = GetComponent<Controller>();
        anime = GetComponent<Animator>();
    }

     private void Update()
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) SetWeapon = 0;
                else if (Input.GetKeyDown(KeyCode.Alpha2)) SetWeapon = 1;
                else if (Input.GetKeyDown(KeyCode.Alpha3)) SetWeapon = 2;
                else if (Input.GetKeyDown(KeyCode.Alpha4)) SetWeapon = 3;
                else if (Input.GetKeyDown(KeyCode.Alpha5)) SetWeapon = 4;
                anime.SetTrigger(SwitchHash);
            }

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A)
                 || Input.GetKeyDown(KeyCode.D))
            {
                anime.SetFloat("Pace", 1f);
            }
            else if (!Control.IsMoving)
            {
                anime.SetFloat("Pace", 0f);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anime.SetTrigger("Attack");
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                anime.ResetTrigger("Attack");
            }

        }

    }
}
