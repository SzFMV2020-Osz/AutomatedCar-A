namespace AutomatedCar.SystemComponents.Packets
{
    class HMIPacket : IReadOnlyHMIPacket
    {
        private double gaspedal;
        private double breakpedal;
        private double steering;
        private Gears gear;
        private double accDistance;
        private int accSpeed;
        private bool laneKeeping;
        private bool parkingPilot;
        private bool turnSignalRight;
        private bool turnSignalLeft;
        private string sign;

        public double Gaspedal { get => gaspedal; set => gaspedal = value; }

        public double Breakpedal { get => breakpedal; set => breakpedal = value; }

        public double Steering { get => steering; set => steering = value; }

        public Gears Gear { get => gear; set => gear = value; }

        public double ACCDistance { get => accDistance; set => accDistance = value; }

        public int ACCSpeed { get => accSpeed; set => accSpeed = value; }

        public bool LaneKeeping { get => laneKeeping; set => laneKeeping = value; }

        public bool ParkingPilot { get => parkingPilot; set => parkingPilot = value; }

        public bool TurnSignalRight { get => turnSignalRight; set => turnSignalRight = value; }

        public bool TurnSignalLeft { get => turnSignalLeft; set => turnSignalLeft = value; }

        public string Sign { get => sign; set => sign = value; }
    }
}
