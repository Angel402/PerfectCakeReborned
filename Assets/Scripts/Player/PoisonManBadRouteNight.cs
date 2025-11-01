using InteractableObjects;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class PoisonManBadRouteNight : InteractableObject
    {
        [SerializeField] private Dialog mainDialog;
        public override void Interact()
        {
            mainDialog.Open();
        }
    }
}