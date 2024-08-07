using UnityEngine;
using Time = Utility.Time;

namespace Player
{
    public class TimeSystem : MonoBehaviour, ITimeSystem
    {
        private Time _currentTime;
        [SerializeField] private int hourToBecomeNight, minuteToBecomeNight, beginningHour, beginningMinute;

        private void Awake()
        {
            _currentTime = new Time(hourToBecomeNight, minuteToBecomeNight, beginningHour, beginningMinute);
        }
        
        public string GetTime()
        {
            return _currentTime.GetTime();
        }
    }
}