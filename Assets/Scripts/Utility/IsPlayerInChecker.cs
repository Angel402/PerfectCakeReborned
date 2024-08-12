using UnityEngine;

namespace Utility
{
    public class IsPlayerInChecker : MonoBehaviour
    {
        private bool _isPlayerIn;

        public bool IsPlayerIn => _isPlayerIn;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isPlayerIn = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isPlayerIn = false;
            }
        }
    }
}