using Player;
using ServiceLocatorPath;

namespace Utility
{
    public class Time
    {
        private readonly int _horaAnochecer;
        private readonly int _minutoAnochecer;
        private float _seconds;
        private int _minutes, _horas;
        private bool _isNight;

        public bool IsNight => _isNight;

        public Time(int horaAnochecer, int minutoAnochecer, int hora, int minuto)
        {
            _horaAnochecer = horaAnochecer;
            _minutoAnochecer = minutoAnochecer;
            _horas = hora;
            _minutes = minuto;
        }
        
        public void AddTime(float time)
        {
            _seconds += time;
            while (_seconds>=60)
            {
                _minutes++;
                _seconds -= 60;
            }

            while (_minutes>=60)
            {
                _horas++;
                _minutes -= 60;
            }

            while (_horas >= 24)
            {
                _horas -= 24;
            }

            if (!_isNight && _horas >= _horaAnochecer && _minutes >= _minutoAnochecer)
            {
                /*ServiceLocator.Instance.GetService<ITimeSystem>().Anochecio();*/
                _isNight = true;
            }
        }

        public string GetTime()
        {
            if (_minutes<10)
            {
                return $"{_horas}:0{_minutes}";
            }
            return $"{_horas}:{_minutes}";
        }

        public void GoNight()
        {
            if (_isNight) return;
            _horas = _horaAnochecer;
            _minutes = _minutoAnochecer;
            _isNight = true;
        }
    }
}