using Player;

namespace InteractableObjects.Objects
{
    public interface IDialogSystem
    {
        void OpenDialog(Dialog dialog, bool wasDialogOpen = false);
        void Interacted();
        void ActionKey(int key);
        void Configure(IPlayerMediator playerMediator);
    }
}