using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public interface ICommand
    {
        void Execute();
    }

    public class OnCommand : ICommand
    {
        private Bulb _bulb;

        public OnCommand(Bulb bulb)
        {
            _bulb = bulb;
        }

        public void Execute()
        {
            _bulb.On();
        }
    }

    public class OffCommand : ICommand
    {
        private Bulb _bulb;

        public OffCommand(Bulb bulb)
        {
            _bulb = bulb;
        }
        public void Execute()
        {
            _bulb.Off();
        }
    }

    //public interface ISwitchable
    //{
    //    void On();
    //    void Off();
    //}

    /// <summary>
    /// Receiver
    /// </summary>
    public class Bulb
    {
        public void On()
        {
            Console.WriteLine("Bulb is On");
        }

        public void Off()
        {
            Console.WriteLine("Bulb is Off");
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class Switch
    {
        private ICommand _onCommand;
        private ICommand _offCommand;
        public Switch(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void On()
        {
            _onCommand.Execute();
        }

        public void Off()
        {
            _offCommand.Execute();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var bulb = new Bulb();
            var switch1 = new Switch(new OnCommand(bulb), new OffCommand(bulb));
            switch1.On();
            switch1.Off();
            Console.ReadKey();
        }
    }
}
