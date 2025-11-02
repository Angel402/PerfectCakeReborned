using DG.Tweening;
using InteractableObjects.Objects;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace InteractableObjects
{
    public class Rug : InteractableObject
    {
        [SerializeField] private Dialog firstDialog;
        [SerializeField] private float delta, time;

        public override void Interact()
        {
            firstDialog.Open();
        }

        public void MoveRug()
        {
            gameObject.layer = 0;
            transform.DOMoveX(transform.position.x - delta, time);
        }
    }
}