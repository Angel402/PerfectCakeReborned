using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Chain : InteractableObject
    {
        [SerializeField] private MainCCDoor mainCcDoor;
        [SerializeField] private Dialog mainDialog;
        public override void Interact()
        {
            mainDialog.Open();
        }

        public void OpenChain()
        {
            mainCcDoor.CanOpen = true;
            gameObject.SetActive(false);
        } 
    }
}