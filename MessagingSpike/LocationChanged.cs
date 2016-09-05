using System.Windows;

namespace MessagingSpike
{
    public class LocationChanged
    {
        public LocationChanged(Point position)
        {
            Position = position;
        }

        public Point Position { get; private set; }
    }
}
