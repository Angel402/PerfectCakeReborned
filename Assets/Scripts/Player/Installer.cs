using InteractableObjects.Objects;
using ServiceLocatorPath;
using UnityEngine;

namespace Player
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private DialogSystem dialogSystem;
        [SerializeField] private InventorySystem inventorySystem;
        private void Awake()
        {
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            ServiceLocator.Instance.RegisterService<IDialogSystem>(dialogSystem);
            ServiceLocator.Instance.RegisterService<IInventorySystem>(inventorySystem);
        }
    }
}