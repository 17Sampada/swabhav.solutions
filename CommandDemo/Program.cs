using CommandDemo.Models;

namespace CommandDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Television tv = new Television();

            ICommand onCommand = new OnCommand(tv);
            RemoteController remote = new RemoteController();
            remote.SetCommand(onCommand);
            remote.pressButton();

            ICommand offCommand = new OffCommand(tv);
            remote.SetCommand(offCommand);
            remote.pressButton();

        }
    }
}
