using System;
using UnityEngine;

namespace Utility
{
    public class GetInTheMallTrigger : MonoBehaviour
    {
        public Action GetInTheMall;

        public void Configure(Action action)
        {
            GetInTheMall = action;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag($"Player"))
                GetInTheMall?.Invoke();
        }
    }
}