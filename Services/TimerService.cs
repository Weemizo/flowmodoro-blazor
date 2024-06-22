namespace FlowmodoroTimer.Services
{
    public class TimerService
    {
        private Timer? _timer;
        private int _remainingSeconds;
    private Action<int>? _onTick; // definiowanie delegata do przechowywania callbaczka co tick [https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Delegaty]
        public bool IsRunning { get; private set; }

        // Sposob na odpalanianie timera i przekazywanie callbacka wywoływanego co tick
        public void Start(Action<int> onTick)
        {
            _remainingSeconds = 0;
            IsRunning = true;
            _onTick = onTick; // przypisanie callbacka 
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
            _onTick?.Invoke(_remainingSeconds); // wywolanie callbacka przy resetowaniu
        }

        private void Tick(object? state)
        {
            _remainingSeconds++;
            _onTick?.Invoke(_remainingSeconds); // wywolanie callbacka przy kazdym ticku
        }
    }
}
