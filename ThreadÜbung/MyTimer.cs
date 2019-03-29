using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ThreadÜbung
{
    public class MyTimer
    {
        public int Interval { get; private set; }
        private int _steps;
        public int Steps => _steps;
        public int? MaxSteps { get; private set; }
        private Action _action;
        private Action _finishCallback;
        CancellationTokenSource _cts;
        Thread _thread;
        public bool IsRunning { get; private set; }
        Dispatcher _dispatcher;

        //Weiter Features:
        //TODO: Maximale Anzahl von Wiederholungen festlegen
        //TODO: Callback nach Beendigung/Abbruch des Timers
        //TODO: Automatisches Invoke


        public MyTimer(int interval, Action action, int? maxSteps = null, Action finishCallback = null)
        {
            Interval = interval;
            MaxSteps = maxSteps;
            _action = action;
            _finishCallback = finishCallback;

            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void Start()
        {
            //Bonus: Verhindern, dass der Thread doppelt gestartet werden kann
            if (IsRunning)
                return;

            //Thread starten
            _cts = new CancellationTokenSource();
            _thread = new Thread(() =>
            {
                CancellationToken token = _cts.Token;
                while(!token.IsCancellationRequested && (MaxSteps == null || (MaxSteps != null && _steps < MaxSteps)))
                {
                    Thread.Sleep(Interval);

                    _dispatcher.Invoke(new Action(() =>
                    {
                        _action?.Invoke();
                    }));
                   
                    _steps++;
                }
                _finishCallback?.Invoke();
                IsRunning = false;
            });

            IsRunning = true;
            _thread.IsBackground = true;
            _steps = 0;
            _thread.Start();
        }

        public void Stop()
        {
            //Thread stoppen
            _cts.Cancel();
        }
    }
}
