using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

namespace TDS.UI
{
    public class Content : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;

        public void Start()
        {
            label.text = name;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Content))]
    internal class ContentEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(10f);
            if (GUILayout.Button("Validate", GUILayout.Height(30f)))
            {
                var target = base.target as Content;

                target.Start();
            }
        }
    }
#endif
}
