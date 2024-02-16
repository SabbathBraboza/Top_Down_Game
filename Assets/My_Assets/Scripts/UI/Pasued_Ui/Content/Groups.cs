using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

namespace TDS.UI
{
    public class Groups : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private RectTransform rectTransform, contentTransform;

        public void Start()
        {
            label.text = name;
            AdjustSize(contentTransform);
            AdjustSize(rectTransform);
        }

        private void AdjustSize(RectTransform transform)
        {
            float heigth = 0f;

            if(transform.TryGetComponent(out VerticalLayoutGroup layout))
            {
                heigth += layout.padding.top + layout.spacing * transform.childCount;
            }
            for(int i=0; i< transform.childCount; i++)
            {
                heigth += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y;
            }
            transform.sizeDelta = new Vector2(x: transform.sizeDelta.x, y: heigth);
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(Groups))]
    internal class Group : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(10f);

            if(GUILayout.Button("Validate",GUILayout.Height(30f)))
            {
                var target = base.target as Groups;
                target.Start();
            }
        }
    }
#endif

}
