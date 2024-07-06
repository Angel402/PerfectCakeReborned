using InteractableObjects.Items;

namespace Player
{
    public interface IInventorySystem
    {
        bool HasSpace();
        void PickItem(Item item);
        void ShowItems();
        void Configure(IPlayerMediator playerMediator);
    }
}