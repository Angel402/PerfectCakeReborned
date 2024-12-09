using Player;
using UnityEngine;

namespace Utility
{
    public class ReferencesService : MonoBehaviour, IReferencesService
    {
        [SerializeField] private PlayerMediator player;

        public Transform GetPlayerTransform()
        {
            return player.transform;
        }

        public PlayerMediator GetPlayer()
        {
            return player;
        }
    }
}