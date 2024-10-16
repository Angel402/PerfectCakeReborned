﻿namespace Player
{
    public interface IDialogSystem
    {
        void OpenDialog(Dialog dialog, bool wasDialogOpen = false);
        void Interacted();
        void ActionKey(int key);
        void Configure(IPlayerMediator playerMediator);
        void CloseDialog();
    }
}