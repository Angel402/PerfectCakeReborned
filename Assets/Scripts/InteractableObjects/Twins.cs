using System;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Twins : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, postTalkDialog;
        [SerializeField] private Animator animator;


        public void MoveTwins()
        {
            animator.SetTrigger("Move");
            mainDialog = postTalkDialog;
        }

        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(mainDialog);
        }
    }
}