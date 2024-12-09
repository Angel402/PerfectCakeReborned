using System.Collections.Generic;
using InteractableObjects.Items;

namespace Player
{
    public interface IInventorySystem
    {
        bool HasSpace();
        void PickItem(Item item);
        void ShowItems();
        void Configure(IPlayerMediator playerMediator);
        bool HasItems(out List<Item> item);
        void DiscardItem(Item item);
        void DiscardItem(string itemName);
        bool OwnsItem(string itemName);
    }
}