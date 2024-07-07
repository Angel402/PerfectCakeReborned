using InteractableObjects.Objects;
using Player;
using ServiceLocatorPath;
using Unity.VisualScripting;
using UnityEngine;

namespace InteractableObjects.Items
{
    public class Item : InteractableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private Dialog dialogWithSpace, dialogWithNoSpace;
        [SerializeField] private GameObject freeObject, pickedObject;
        public string ItemName => itemName;

        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(
                ServiceLocator.Instance.GetService<IInventorySystem>().HasSpace()
                    ? dialogWithSpace
                    : dialogWithNoSpace);
        }

        public void PickItem()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().PickItem(this);
            freeObject.SetActive(false);
            pickedObject.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
    }
}