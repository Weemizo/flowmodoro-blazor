namespace FlowmodoroTimer.Services
{
    public class TimerService
    {
        private Timer? _timer;
        private int _remainingSeconds;
        private Action<int>? _onTick; // Define a delegate to hold the callback function

        public bool IsRunning { get; private set; }

        // Method to start the timer and accept a callback function to be called on each tick
        public void Start(Action<int> onTick)
        {
            _remainingSeconds = 0;
            IsRunning = true;
            _onTick = onTick; // Assign the callback function
            _timer = new Timer(Tick, null, 0, 1000);
        }

        public void Stop()
        {
            _timer?.Dispose();
            IsRunning = false;
        }

        public void Reset()
        {
            _timer?.Dispose();
            _remainingSeconds = 0;
            IsRunning = false;
            _onTick?.Invoke(_remainingSeconds); // Notify callback with reset time
        }

        private void Tick(object? state)
        {
            _remainingSeconds++;
            _onTick?.Invoke(_remainingSeconds); // Call the callback function on each tick
        }
    }
}
