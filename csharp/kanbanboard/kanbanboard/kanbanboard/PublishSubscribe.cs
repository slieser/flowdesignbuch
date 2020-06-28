using System;

namespace kanbanboard
{
    public class PublishSubscribe
    {
        private Action _onPublish;

        public void Subscribe(Action onPublish) {
            _onPublish = onPublish;
            _onPublish();
        }

        public void Publish() {
            _onPublish();
        }
    }
}