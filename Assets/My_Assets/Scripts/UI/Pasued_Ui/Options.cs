using UnityEngine;
using UnityEngine.Events;
using TDS.Object;

namespace TDS.UI.Menu
{
    public class Options : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Settings setting;

        public UnityEvent<bool> OnStateChange;

        private void Reset()
        {
            canvas = GetComponent<Canvas>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) OnStateChange.Invoke(canvas.enabled = !canvas.enabled);
            
        }


    }
}
