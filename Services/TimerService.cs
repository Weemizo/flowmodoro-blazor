namespace PomodoroTimer.Services
{
    public class TimerService
    {
        public event Action<int>? OnTick;
        public event Action? OnTimerComplete;

        private int duration;
        private bool isRunning;
        private TimeSpan remainingTime;
        private Task? timerTask;

        public bool IsRunning => isRunning;

        public void Start(int durationInMinutes)
        {
            if (isRunning)
                return;

            duration = durationInMinutes;
            remainingTime = TimeSpan.FromMinutes(duration);
            isRunning = true;

            timerTask = Task.Run(async () =>
            {
                while (remainingTime.TotalSeconds > 0)
                {
                    await Task.Delay(1000);
                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                    OnTick?.Invoke((int)remainingTime.TotalSeconds);
                }
                isRunning = false;
                OnTimerComplete?.Invoke();
            });
        }

        public void Stop()
        {
            if (!isRunning)
                return;

            timerTask?.Wait();
            isRunning = false;
        }
    }
}
