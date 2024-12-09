using System;
using UnityEngine;

namespace InteractableObjects
{
    public class OutHouseDoorTrigger : MonoBehaviour
    {
        private Action _onPlayerOut, _onPlayerIn;
        [HideInInspector] public bool isPlayerIn;
        public void Configure(Action onPlayerOut)
        {
            _onPlayerOut += onPlayerOut;
        }
        
        public void Configure(Action onPlayerOut, Action onPlayerIn)
        {
            _onPlayerOut += onPlayerOut;
            _onPlayerIn += onPlayerIn;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerIn = true;
                _onPlayerIn?.Invoke();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerIn = false;
                _onPlayerOut?.Invoke();
            }
        }
    }
}