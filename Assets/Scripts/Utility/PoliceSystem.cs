using System.Collections.Generic;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace Utility
{
    public class PoliceSystem : MonoBehaviour
    {
        [SerializeField] private List<PolicemanCollider> policemanColliders;
        [SerializeField] private Dialog moveAwayDialog, arrestDialog;
        [SerializeField] private GetInTheMallTrigger getInTheMallTrigger;
        [SerializeField] private GetOutTheMallTrigger getOutTheMallTrigger;
        [SerializeField] private Color badMoralColor = Color.red, normalColor;
        private bool _alarmSounded;
 
        private void Start()
        {
            foreach (var policemanCollider in policemanColliders)
            {
                policemanCollider.Configure(moveAwayDialog, normalColor);
            }
            
            getInTheMallTrigger.Configure(GetInTheMall);
            getOutTheMallTrigger.Configure(GetOutTheMall);
        }

        private void GetOutTheMall()
        {
            if (_alarmSounded) return;
            if (ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer().HasBadMoral)
            {
                _alarmSounded = true;
                foreach (var policemanCollider in policemanColliders)
                {
                    policemanCollider.Configure(arrestDialog, badMoralColor);
                }
            }
        }

        private void GetInTheMall()
        {
            getOutTheMallTrigger.gameObject.SetActive(true);
            getInTheMallTrigger.gameObject.SetActive(true);
        }

        public void MoveAwayPart1()
        {
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer().FreezeMovement(false);
        }
        
        public void MoveAwayPart2()
        {
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene("Map3Angel");
        }

        public void ArrestPart2()
        {
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene("Map1Angel");
        }
    }
}