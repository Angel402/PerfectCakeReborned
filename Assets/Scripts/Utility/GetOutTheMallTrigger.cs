using System;
using UnityEngine;

namespace Utility
{
    public class GetOutTheMallTrigger : MonoBehaviour
    {
        public Action GetOutTheMall;

        public void Configure(Action action)
        {
            GetOutTheMall = action;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                GetOutTheMall?.Invoke();
        }
    }
}