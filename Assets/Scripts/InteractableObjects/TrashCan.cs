using System.Collections.Generic;
using InteractableObjects.Items;
using InteractableObjects.Objects;
using Player;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableObjects
{
    public class TrashCan : InteractableObject
    {
        [SerializeField] private Dialog noItemsDialog, dialogIfItems, dialogForDiscard, noDiscardDialog;
        public override void Interact()
        {
            if (ServiceLocator.Instance.GetService<IInventorySystem>().HasItems(out var items))
            {
                var optionDialogs = new List<Dialog>();
                foreach (var item in items)
                {
                    var eventWhenSelected = new UnityEvent();
                    eventWhenSelected.AddListener(() =>
                        ServiceLocator.Instance.GetService<IInventorySystem>().DiscardItem(item));
                    optionDialogs.Add(new Dialog()
                    {
                        text = dialogForDiscard.text + item.ItemName,
                        lineToSelectDialog = dialogForDiscard.lineToSelectDialog + item.ItemName,
                        eventsWhenOpen = eventWhenSelected,
                        isLastDialog = true
                    });
                }
                optionDialogs.Add(noDiscardDialog);
                dialogIfItems.options = optionDialogs;
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogIfItems);
            }
            else
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(noItemsDialog);
            }
        }
    }
}