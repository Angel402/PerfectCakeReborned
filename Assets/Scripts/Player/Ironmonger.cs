using InteractableObjects;
using InteractableObjects.Items;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class Ironmonger : InteractableObject
    {
        [SerializeField] private Dialog mainDialog, missionAcceptedDialog, missionCompetedDialog, missionClosedDialog;
        private bool _missionAccepted, _missionCompleted, _missionClosed;
        [SerializeField] private Ingredient poison;
        public override void Interact()
        {
            if (!_missionAccepted)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(mainDialog);
                _missionAccepted = true;
                return;
            }
            if (!_missionCompleted)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(missionAcceptedDialog);
                return;
            }
            if (!_missionClosed)
            {
                ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(missionCompetedDialog);
                return;
            }
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(missionClosedDialog);
        }

        public void CompeteMission()
        {
            _missionCompleted = true;
        }

        public void CloseMission()
        {
            _missionClosed = true;
            poison.gameObject.SetActive(true);
        }
    }
}