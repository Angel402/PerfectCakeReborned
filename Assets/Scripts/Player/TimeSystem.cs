using System;
using ServiceLocatorPath;
using UnityEngine;
using Time = Utility.Time;

namespace Player
{
    public class TimeSystem : MonoBehaviour, ITimeSystem
    {
        private Time _currentTime;
        [SerializeField] private int hourToBecomeNight, minuteToBecomeNight, beginningHour, beginningMinute, timeVelocity;
        private bool _contarElTiempo;
        [SerializeField] private Dialog anochecioDialog;
        [SerializeField] private string scene3Name;

        private void Awake()
        {
            _currentTime = new Time(hourToBecomeNight, minuteToBecomeNight, beginningHour, beginningMinute);
        }

        private void Update()
        {
            
            if (!_contarElTiempo) return;
            _currentTime.AddTime(UnityEngine.Time.deltaTime * timeVelocity);
        }

        public string GetTime()
        {
            return _currentTime.GetTime();
        }

        public void SpendTime(float minutesInBike)
        {
            _currentTime.AddTime(minutesInBike * 60);
        }

        public void StartRunningTime()
        {
            if (_currentTime.IsNight) return;
            _contarElTiempo = true;
        }

        public void SitUntilNight()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(anochecioDialog, true);
            _currentTime.GoNight();
            _contarElTiempo = false;
        }

        public bool IsNight()
        {
            return _currentTime.IsNight;
        }

        public void Anochecio()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(anochecioDialog, true);
            _contarElTiempo = false;
        }

        public void GoToNight()
        {
            ServiceLocator.Instance.GetService<IScenesSystem>().TransitionToScene(scene3Name);
        }
    }
}