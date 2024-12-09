using System;
using Player;
using ServiceLocatorPath;
using UnityEditor.Build;
using UnityEngine;

namespace Utility
{
    public class Map2Configurator : MonoBehaviour
    {
        [SerializeField] private Transform playerStartingPosition;
        private void Start()
        {
            ServiceLocator.Instance.GetService<ITimeSystem>().StartRunningTime();
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer()
                .RePositionByTransform(playerStartingPosition);
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer().FreezeMovement(true);
        }
    }
}