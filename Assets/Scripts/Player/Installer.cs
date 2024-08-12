using System.ComponentModel.Design;
using InteractableObjects.Objects;
using ServiceLocatorPath;
using UnityEngine;
using Utility;

namespace Player
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private DialogSystem dialogSystem;
        [SerializeField] private InventorySystem inventorySystem;
        [SerializeField] private MissionSystem missionSystem;
        [SerializeField] private TimeSystem timeSystem;
        [SerializeField] private ScenesSystem scenesSystem;
        [SerializeField] private ReferencesService referencesService;
        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            ServiceLocator.Instance.RegisterService<IDialogSystem>(dialogSystem);
            ServiceLocator.Instance.RegisterService<IInventorySystem>(inventorySystem);
            ServiceLocator.Instance.RegisterService<IMissionSystem>(missionSystem);
            ServiceLocator.Instance.RegisterService<ITimeSystem>(timeSystem);
            ServiceLocator.Instance.RegisterService<IScenesSystem>(scenesSystem);
            ServiceLocator.Instance.RegisterService<IReferencesService>(referencesService);
        }
    }
}