using System;
using System.Collections.Generic;
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
                hasItem = true;
            }

            public void DiscardItem()
            {
                item.gameObject.SetActive(false);
                item = null;
                hasItem = false;
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
                return;
            }
            
            if (!spaceForItem2.hasItem)
            {
                spaceForItem2.SaveItem(item);
                return;
            }
            
            if (!spaceForItem3.hasItem)
            {
                spaceForItem3.SaveItem(item);
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

        public bool HasItems(out List<Item> item)
        {
            var itemsReturned = new List<Item>();
            if (spaceForItem1.hasItem)
            {
                itemsReturned.Add(spaceForItem1.item);
            }
            
            if (spaceForItem2.hasItem)
            {
                itemsReturned.Add(spaceForItem2.item);
            }
            
            if (spaceForItem3.hasItem)
            {
                itemsReturned.Add(spaceForItem3.item);
            }

            item = itemsReturned;
            return item.Count > 0;
        }

        public void DiscardItem(Item item)
        {
            if (item == spaceForItem1.item)
            {
                spaceForItem1.DiscardItem();
            }
            if (item == spaceForItem2.item)
            {
                spaceForItem2.DiscardItem();
            }
            if (item == spaceForItem3.item)
            {
                spaceForItem3.DiscardItem();
            }
        }
    }
}