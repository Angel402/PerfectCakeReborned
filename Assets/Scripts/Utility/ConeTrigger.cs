using System;
using UnityEngine;

namespace Utility
{
    public class ConeTrigger : MonoBehaviour
    {
        private Action _onPlayerEntered;
        public void Configure(Action action)
        {
            _onPlayerEntered = action;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _onPlayerEntered?.Invoke();
        }
    }
}