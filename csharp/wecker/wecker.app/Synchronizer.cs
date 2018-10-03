using System;
using System.Windows.Threading;

namespace wecker.app
{
    public class Synchronizer
    {
        private readonly Dispatcher dispatcher;

        public Synchronizer() {
            dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void Process(Action action) {
            dispatcher.Invoke(action);
        }
    }
}