namespace AutomatedCar.SystemComponents.Packets
{
    public class PowertrainPacket : IReadOnlyPowertrainPacket
    {
        private int _x ;

        private int _y;
    
        private double speed;
        
        private int rpm;

        public int _X {get; set;}

        public int _Y {get; set;}

        public double Speed {get; set;}

        public int RPM {get; set;}

    }
}