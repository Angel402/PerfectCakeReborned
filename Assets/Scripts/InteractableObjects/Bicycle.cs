using System.Collections.Generic;
using InteractableObjects.Items;
using Player;
using ServiceLocatorPath;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;

namespace InteractableObjects
{
    public class Bicycle : InteractableObject
    {
        [SerializeField] private Dialog dialogWithoutKeys, dialogWithKeys;
        [SerializeField] private Item item;
        [SerializeField] private float minutesInBike;
        [SerializeField] private string sceneName;
        public override void Interact()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().OwnsItem(item.ItemName))
            {
                dialogWithKeys.Open();
            }
            dialogWithoutKeys.Open();
        }

        public void UseBike()
        {
            ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(item.ItemName);
            ServiceLocator.Instance.GetService<ITimeSystem>().SpendTime(minutesInBike);
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene(sceneName);
        }
    }
}