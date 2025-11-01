using DG.Tweening;
using Player;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace InteractableObjects
{
    public class EmergencyLadder : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, usedDialog;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform playerTransformTarget;
        [SerializeField] private GameObject emergencyLadderLocker;
        [SerializeField] private float tweenDuration = 0.6f;
        private bool _ladderWasUsed;
        private Transform _originalPlayerParent;

        public override void Interact()
        {
            if (_ladderWasUsed)
                usedDialog.Open();
            else
                mainDialog.Open();
        }

        public void UseLadder()
        {
            _ladderWasUsed = true;
            var playerTransform = ServiceLocator.Instance.GetService<IReferencesService>().GetPlayerTransform();
            var player = ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer();
            _originalPlayerParent = playerTransform.parent;
            player.ToggleCanMoveCamera(false);
            player.ToggleCanMove(false);
            player.UseGravity(false);
            playerTransform.SetParent(playerTransformTarget);
            emergencyLadderLocker.SetActive(false);
            var sequence = DOTween.Sequence();
            sequence.Insert(0, playerTransform.DOMove(playerTransformTarget.position, tweenDuration));
            sequence.Insert(0, playerTransform.DORotate(playerTransformTarget.eulerAngles, tweenDuration));
            sequence.onComplete += () =>
            {
                animator.SetTrigger("UseLadder");
            };
        }

        public void FinishLadderAnimation()
        {
            Debug.Log("acabo la animacion");
            var player = ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer();
            player.ToggleCanMoveCamera(true);
            player.ToggleCanMove(true);
            player.UseGravity(true);
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayerTransform()
                .SetParent(_originalPlayerParent);
        }
    }
}