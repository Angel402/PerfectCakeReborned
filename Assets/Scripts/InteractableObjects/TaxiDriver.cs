using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class TaxiDriver : InteractableObject
    {
        [SerializeField] private Dialog dialogWithoutBill, dialogWithBill;
        [SerializeField] private Item item;
        [SerializeField] private float minutesInTaxi;
        [SerializeField] private string sceneName;
        public override void Interact()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(item.ItemName))
            {
                dialogWithBill.Open();
            }
            dialogWithoutBill.Open();
        }

        public void UseTaxi()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(item.ItemName);
            ServiceLocator.Instance.GetService<ITimeSystem>().SpendTime(minutesInTaxi);
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene(sceneName);
        }
    }
}