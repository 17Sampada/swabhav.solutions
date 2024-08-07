namespace CommandDemo.Models
{
    internal class OnCommand : ICommand
    {
        private Television Tv { get; set; }

        public OnCommand(Television tv)
        {
            Tv = tv;

        }
        public void Execute()
        {
            Tv.on();
        }
    }
}
