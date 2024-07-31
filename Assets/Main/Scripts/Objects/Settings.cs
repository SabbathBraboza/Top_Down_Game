using UnityEngine;

namespace TDS.Object
{
    [CreateAssetMenu]
    public class Settings : ScriptableObject
    {
        [Header("VIDEO")]
        public ushort TargetFPS;

        [Header("INPUT")]
        public Input_Manager key;
    }
}
