using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TDS.Player
{
    public class Composite : MonoBehaviour
    {
        [SerializeField] private Input_Manager keys;
        [SerializeField] private Character[] character;

        private int _id; public int ID
        {
            get => _id;
            set
            {
                character[_id].enabled = false;
                _id = Mathf.Clamp(value, min: 0, max: character.Length);
                character[_id].enabled = true;
            }
        }
        private void Start()
        {
            for (int i = 0; i < character.Length; i++)
            {
                character[i].enabled = _id == i;
            }
            ID = 0;   
        }

        private void Update()
        {
           if(Input.GetKey(keys.Switch))
            {
                ID = (int)Mathf.Repeat(ID + 1, character.Length);
            }
        }
    }
}

