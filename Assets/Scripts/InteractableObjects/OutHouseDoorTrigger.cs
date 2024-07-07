using System;
using UnityEngine;

namespace InteractableObjects
{
    public class OutHouseDoorTrigger : MonoBehaviour
    {
        private Action _onPlayerOut;
        public void Configure(Action onPlayerOut)
        {
            _onPlayerOut += onPlayerOut;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _onPlayerOut?.Invoke();
            }
        }
    }
}