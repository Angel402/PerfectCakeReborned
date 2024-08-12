using System;
using Player;
using ServiceLocatorPath;
using UnityEngine;

namespace Utility
{
    public class GoWalkingToMall : MonoBehaviour
    {
        [SerializeField] private float minutesWalking;
        [SerializeField] private string sceneName;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            ServiceLocator.Instance.GetService<ITimeSystem>().SpendTime(minutesWalking);
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene(sceneName);
        }
    }
}