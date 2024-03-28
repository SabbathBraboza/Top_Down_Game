using System;
using UnityEngine;

namespace TDS_UI.Menu
{
    public class Option_Selectables : MonoBehaviour
    {
        public enum Category
        {
            Video = 0, Audio = 1, Controls = 2
        }

        [Serializable]
        private struct Categories
        {
            public GameObject[] video, audio, controls;
            public GameObject[] this[Category category] => category switch {  Category.Video => video , Category.Audio => audio, Category.Controls => controls, _ => null};
        }

        [SerializeField] private Categories categories;

        public void SetCategoryActive(int id)
        {
            foreach(Category category in Enum.GetValues(typeof(Category)))
            {
                foreach(var obj in categories[category])
                {
                    obj.SetActive((int)category == id);
                }
            }
        }

        public void SetCategoryActive(Category category) => SetCategoryActive((int)category);

        public void applicationQuit()
        {
            Application.Quit();
            Debug.Log("Quitting the game");
        }
    }
}