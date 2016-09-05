using Caliburn.Micro;
using System.Windows;

namespace MessagingSpike
{
    public class ShellViewModel : Screen, IShell, IHandle<LocationChanged>
    {
        private readonly IEventAggregator _eventAggregator;
        private Point _location;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            _eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                _eventAggregator.Unsubscribe(this);
            }

            base.OnDeactivate(close);
        }

        public void Handle(LocationChanged message)
        {
            Application.Current.Dispatcher.Invoke(
                () => Location = message.Position
            );
        }

        public Point Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    _location = value;

                    NotifyOfPropertyChange(() => Location);
                }
            }
        }
    }
}