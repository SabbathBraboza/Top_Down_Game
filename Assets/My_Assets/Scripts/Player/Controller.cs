using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using static Unity.Collections.NativeText;


namespace TDS_Player
{
    public class Controller : MonoBehaviour
    {
        private Character _character;
        private Animator anime;
         public float Move;
        private Vector3 mousePos;

        [SerializeField] private Input_Manager keys;

        [SerializeField] public Vector2 direction;
        public bool IsMoving => direction != Vector2.zero;

        //private Vector2 Direction
        //{
        //    get => direction;
        //    set
        //    {
        //        direction = value;
        //        anime.SetFloat("Pace", direction != Vector2.zero ? 1f : 0f);
        //    }
        //}


        private void Update()
        {
            #region INPUTs
            if (Input.GetKeyDown(keys.Forword)) direction.y += 1F;
            if (Input.GetKeyDown(keys.Backward)) direction.y -= 1F;
            if (Input.GetKeyDown(keys.left)) direction.x -= 1F;
            if (Input.GetKeyDown(keys.Right)) direction.x += 1F;

            if (Input.GetKeyUp(keys.Forword)) direction.y -= 1F;
            if (Input.GetKeyUp(keys.Backward)) direction.y += 1F;
            if (Input.GetKeyUp(keys.left)) direction.x += 1F;
            if (Input.GetKeyUp(keys.Right)) direction.x -= 1F;
            #endregion
            MouseL();
        }

        private void FixedUpdate()
        {
            if (IsMoving)
            { 
                transform.Translate(Move * Time.deltaTime * direction, Space.World);
            }
        }

        private void MouseL()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 90f));
            float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.AngleAxis(angle + 90f, Vector3.forward), Time.deltaTime * 5f);
        }
    }
}
