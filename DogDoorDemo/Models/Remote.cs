using System.Timers;

namespace DogDoorDemo.Models
{
    internal class Remote
    {
        private DogDoor door;

        public Remote(DogDoor door)
        {
            this.door = door;
        }

        public void pressButton()
        {
            Console.WriteLine("Pressing the remote control button...");
            if (door.isOpen())
                door.Close();
            else
            {
                door.Open();
                System.Timers.Timer timer = new System.Timers.Timer(5000);
                timer.Elapsed += (source, e) => OnTimedEvent(source, e, timer);
                timer.AutoReset = false;
                timer.Enabled = true;

            }


        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e, System.Timers.Timer timer)
        {
            door.Close();
            timer.Stop();
            timer.Dispose();
        }
    }
}
