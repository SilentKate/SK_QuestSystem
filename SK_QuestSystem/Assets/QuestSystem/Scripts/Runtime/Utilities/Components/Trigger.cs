using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace QuestSystem.Scripts.Runtime.Utilities.Components
{
    [RequireComponent(typeof(Collider))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onTriggerEnterEvent;
        [SerializeField] private UnityEvent _onTriggerExitEvent;
        [SerializeField] private LayerMask _layerMask;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        [UsedImplicitly]
        private void OnTriggerEnter(Collider other)
        {
            var isLayerOk = _layerMask == (_layerMask | (1 << other.gameObject.layer));
            if (isLayerOk)
            {
                _onTriggerEnterEvent?.Invoke();
            }
        }

        [UsedImplicitly]
        private void OnTriggerExit(Collider other)
        {
            var isLayerOk = _layerMask == (_layerMask | (1 << other.gameObject.layer));
            if (isLayerOk)
            {
                _onTriggerExitEvent?.Invoke();
            }
        }
    }
}