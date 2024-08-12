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
        private void Awake()
        {
            ServiceLocator.Instance.GetService<ITimeSystem>().StartRunningTime();
            ServiceLocator.Instance.GetService<IReferencesService>().GetPlayer()
                .RePositionByTransform(playerStartingPosition);
        }
    }
}