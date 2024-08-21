using System;
using UnityEngine;
using Time = Utility.Time;

namespace Player
{
    public class TimeSystem : MonoBehaviour, ITimeSystem
    {
        private Time _currentTime;
        [SerializeField] private int hourToBecomeNight, minuteToBecomeNight, beginningHour, beginningMinute, timeVelocity;
        private bool _contarElTiempo;

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
            _contarElTiempo = true;
        }

        public void SitUntilNight()
        {
            _currentTime.GoNight();
        }

        public bool IsNight()
        {
            return _currentTime.IsNight;
        }
    }
}