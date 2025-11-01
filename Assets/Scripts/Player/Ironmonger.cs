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
        [SerializeField] private Transform poisonPosition;

        public override void Interact()
        {
            if (!_missionAccepted)
            {
                mainDialog.Open();
                return;
            }
            if (!_missionCompleted)
            {
                mainDialog.Open();
                return;
            }
            if (!_missionClosed)
            {
                missionCompetedDialog.Open();
                return;
            }
            missionClosedDialog.Open();
        }

        public void CompeteMission()
        {
            _missionCompleted = true;
        }

        public void CloseMission()
        {
            _missionClosed = true;
            poison.transform.position = poisonPosition.position;
            poison.gameObject.SetActive(true);
        }

        public void AcceptMission()
        {
            _missionAccepted = true;
        }
    }
}