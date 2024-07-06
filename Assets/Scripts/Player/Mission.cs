using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Mission : MonoBehaviour
    {
        [SerializeField] private string missionName;
        [SerializeField] private TMP_Text missionNamText;
        [SerializeField] private RectTransform mark, markMask;
        [SerializeField] private UnityEvent onMissionCompleted;
        private float _markingTime;
        private bool _completed;
        public string Name => missionName;

        public void ObjectiveCompeted()
        {
            if (_completed) return;
            onMissionCompleted?.Invoke();
            markMask.DOSizeDelta(mark.sizeDelta, _markingTime);
            _completed = true;
        }

        public void Configure(float markingTime)
        {
            _markingTime = markingTime;
        }
    }
}