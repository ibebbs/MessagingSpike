using Caliburn.Micro;
using System;
using System.Threading;
using System.Windows;

namespace MessagingSpike
{
    public interface ILocationService
    {
        void Initialize();
    }

    public class LocationService : ILocationService
    {
        private static readonly Random Random = new Random();

        private readonly IEventAggregator _eventAggregator;
        private Timer _timer;

        public LocationService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private void GetAndPublishPosition(object state)
        {
            // Call to GetPosition
            Point position = new Point(Random.NextDouble(), Random.NextDouble());

            _eventAggregator.PublishOnBackgroundThread(new LocationChanged(position));
        }

        public void Initialize()
        {
            _timer = new Timer(GetAndPublishPosition, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }
    }
}
