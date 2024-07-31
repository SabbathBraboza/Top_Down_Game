using TDS.Object;
using UnityEngine;
using UnityEngine.Events;

namespace TDS_UI
{
    public class Main : MonoBehaviour
    {
        public Settings setting;

        public UnityEvent OnInitiailze;

        private void Start()
        {
            OnInitiailze.Invoke();
        }
    }
}
