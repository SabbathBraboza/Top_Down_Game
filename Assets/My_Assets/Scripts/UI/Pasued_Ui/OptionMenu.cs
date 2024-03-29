using UnityEngine;
using UnityEngine.Events;
using TDS.Object;

namespace TDS.UI.Menu
{
    public class OptionMenu: MonoBehaviour
    {
        public GameObject Paused;
        private Settings setting;
        private bool IsPaused;

        private void Start()
        {
            Paused.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PausedGame();
                }
            }
        }
        public void PausedGame()
        {
            Paused.SetActive(true);
            Time.timeScale = 1f;
            IsPaused = true;
        }
        public void ResumeGame()
        {
            Paused.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }


    }
}
