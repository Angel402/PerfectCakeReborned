using System;
using InteractableObjects.Items;
using UnityEngine;

namespace Player
{
    public class InventorySystem : MonoBehaviour, IInventorySystem
    {
        [Serializable]
        private class SpaceForItem
        {
            public bool hasItem;
            public Item item;
            public Transform itemTransform;

            public void SaveItem(Item itemToSet)
            {
                item = itemToSet;
                item.transform.SetPositionAndRotation(itemTransform.position, itemTransform.rotation);
                item.transform.SetParent(itemTransform);
            }
        }
        
        [SerializeField] private SpaceForItem spaceForItem1, spaceForItem2, spaceForItem3;
        private IPlayerMediator _playerMediator;
        private bool _itemsShown;

        public bool HasSpace()
        {
            return !spaceForItem1.hasItem || !spaceForItem2.hasItem || !spaceForItem3.hasItem;
        }

        public void PickItem(Item item)
        {
            if (!spaceForItem1.hasItem)
            {
                spaceForItem1.SaveItem(item);
            }
        }

        public void ShowItems()
        {
            if (_itemsShown)
            {
                _playerMediator.ResetTrigger("ShowItems");
                _playerMediator.SetTrigger("HideItems");
            }
            else
            {
                _playerMediator.ResetTrigger("HideItems");
                _playerMediator.SetTrigger("ShowItems");
            }
            _itemsShown = !_itemsShown;
        }

        public void Configure(IPlayerMediator playerMediator)
        {
            _playerMediator = playerMediator;
        }
    }
}