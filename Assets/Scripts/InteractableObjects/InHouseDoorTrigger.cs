using UnityEngine;

namespace InteractableObjects
{
    public class InHouseDoorTrigger : MonoBehaviour
    {
        [HideInInspector] public bool isPlayerIn;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) isPlayerIn = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) isPlayerIn = false;
        }
    }
}