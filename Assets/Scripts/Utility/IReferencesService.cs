using Player;
using UnityEngine;

namespace Utility
{
    public interface IReferencesService
    {
        Transform GetPlayerTransform();
        PlayerMediator GetPlayer();
    }
}