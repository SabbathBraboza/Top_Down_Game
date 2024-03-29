using UnityEngine;
using UnityEngine.UI;


namespace TDS_UI.Menu
{
    public class Main_FPS : Option<float>
    {
        [SerializeField] private Slider slider;

        protected override void Reset()
        {
            base.Reset();
            slider = GetComponentInChildren<Slider>();
        }
        protected override void Awake()
        {
            base.Awake();
            slider.onValueChanged.AddListener(OnExecute);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            slider.onValueChanged.RemoveListener(OnExecute);
        }
        protected override void Initiaizle()=> slider.value= Settings.TargetFPS;
        protected override void OnExecute(float value)=> Application.targetFrameRate = Settings.TargetFPS =(ushort)(int)value;
    }
}
