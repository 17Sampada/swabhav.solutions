namespace CommandDemo.Models
{
    internal class RemoteController
    {
        public ICommand Command { get; set; }

        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        public void pressButton()
        {
            Command.Execute();
        }


    }
}
