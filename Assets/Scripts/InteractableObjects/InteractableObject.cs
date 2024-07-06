using System;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] private Renderer objectRenderer;
        public void EnableShader(bool enable)
        {
            if (enable)
            {
                try
                {
                    objectRenderer?.material.SetFloat("_Fresnel", 1);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                }
            }
            else
            {
                try
                {
                    objectRenderer?.material.SetFloat("_Fresnel", 0);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                }
            }
        }

        public abstract void Interact();
    }
}