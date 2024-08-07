using System;
using UnityEngine;

namespace Utility
{
    public class PassThroughChecker : MonoBehaviour
    {
        [SerializeField] private IsPlayerInChecker backTrigger, forwardTrigger;
        [SerializeField] private Collider ownTrigger;
        [SerializeField] private Animator animator;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (backTrigger.IsPlayerIn)
                    return;
                if (forwardTrigger.IsPlayerIn)
                {
                    animator.SetTrigger("caer");
                    ownTrigger.isTrigger = false;
                    this.enabled = false;
                }
            }
        }
    }
}