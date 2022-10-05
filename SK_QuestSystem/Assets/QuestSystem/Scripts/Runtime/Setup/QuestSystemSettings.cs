using UnityEditor;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime.Setup
{
    public class QuestSystemSettings : ScriptableObject
    {
        [SerializeField] private LayerMask _playerLayerMask;

        public LayerMask PlayerLayerMask => _playerLayerMask;

        [MenuItem("Tools/QuestSystem/Settings")]
        public static void Create()
        {
            var asset = CreateInstance<QuestSystemSettings>();
            AssetDatabase.CreateAsset(asset, "Assets/QuestSystemSettings.asset");
            EditorGUIUtility.PingObject(asset);
        }
    }
}