using UnityEngine;

namespace InteractableObjects.Objects
{
    public class SampleInteractiveObject : InteractableObject
    {
        public override void Interact()
        {
            Debug.Log("interact");
        }
    }
}