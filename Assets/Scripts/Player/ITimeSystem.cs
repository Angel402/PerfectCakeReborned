namespace Player
{
    public interface ITimeSystem
    {
        string GetTime();
        void SpendTime(float minutesInBike);
        void StartRunningTime();
        void SitUntilNight();
        bool IsNight();
    }
}