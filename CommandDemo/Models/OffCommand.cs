namespace CommandDemo.Models
{
    internal class OffCommand : ICommand
    {
        private Television Tv { get; set; }

        public OffCommand(Television tv)
        {
            Tv = tv;

        }
        public void Execute()
        {
            Tv.off();
        }
    }
}
