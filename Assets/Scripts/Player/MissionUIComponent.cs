using TMPro;
using UnityEngine;

namespace Player
{
    public class MissionUI : MonoBehaviour
    {
        [SerializeField] private string missionName;
        [SerializeField] private TMP_Text missionNamText;
        [SerializeField] private RectTransform mark, markMask;
    }
}