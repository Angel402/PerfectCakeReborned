using System;
using InteractableObjects;
using UnityEngine;

namespace Player
{
public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float interactDistance;
        private InteractableObject _currentInteractableObject;

        private void Update()
        {
            if (Physics.Raycast(cameraTransform.position,
                cameraTransform.TransformDirection(Vector3.forward), out var hit, interactDistance, layerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(
                    out InteractableObject interactableObject))
                {
                    if (interactableObject != _currentInteractableObject)
                    {
                        interactableObject.EnableShader(true);
                        if (_currentInteractableObject != null)
                        {
                            _currentInteractableObject.EnableShader(false);
                        }
                        _currentInteractableObject = interactableObject;
                    }
                }
            }
            else
            {
                if (_currentInteractableObject != null)
                {
                    _currentInteractableObject.EnableShader(false);
                    _currentInteractableObject = null;
                }
            }
        }

        public void Interact()
        {
            if (Physics.Raycast(cameraTransform.position,
                cameraTransform.TransformDirection(Vector3.forward), out var hit, interactDistance, layerMask))
            {
                if (hit.collider.TryGetComponent(out InteractableObject interactableObject))
                {
                    interactableObject.Interact();
                }
            }
        }
    }
}