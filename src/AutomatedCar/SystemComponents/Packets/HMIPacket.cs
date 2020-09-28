namespace AutomatedCar.SystemComponents.Packets
{
    using ReactiveUI;

    class HMIPacket : ReactiveObject, IReadOnlyHMIPacket
    {
        private double gaspedal;
        private double breakpedal;
        private double steering;
        private Gears gear;
        private double aCC_Distance;
        private int aCC_Speed;
        private bool laneKeeping;
        private bool parkingPilot;
        private bool turnSignalRight;
        private bool turnSignalLeft;
        private string sign;

        public double Gaspedal
        {
            get => this.gaspedal;
            set => this.RaiseAndSetIfChanged(ref this.gaspedal, value);
        }

        public double Breakpedal
        {
            get => this.breakpedal;
            set => this.RaiseAndSetIfChanged(ref this.breakpedal, value);
        }

        public double Steering
        {
            get => this.steering;
            set => this.RaiseAndSetIfChanged(ref this.steering, value);
        }

        public Gears Gear
        {
            get => this.gear;
            set => this.RaiseAndSetIfChanged(ref this.gear, value);
        }

        public double ACC_Distance
        {
            get => this.aCC_Distance;
            set => this.RaiseAndSetIfChanged(ref this.aCC_Distance, value);
        }

        public int ACC_Speed
        {
            get => this.aCC_Speed;
            set => this.RaiseAndSetIfChanged(ref this.aCC_Speed, value);
        }

        public bool LaneKeeping
        {
            get => this.laneKeeping;
            set => this.RaiseAndSetIfChanged(ref this.laneKeeping, value);
        }

        public bool ParkingPilot
        {
            get => this.parkingPilot;
            set => this.RaiseAndSetIfChanged(ref this.parkingPilot, value);
        }

        public bool TurnSignalRight
        {
            get => this.turnSignalRight;
            set => this.RaiseAndSetIfChanged(ref this.turnSignalRight, value);
        }

        public bool TurnSignalLeft
        {
            get => this.turnSignalLeft;
            set => this.RaiseAndSetIfChanged(ref this.turnSignalLeft, value);
        }

        public string Sign
        {
            get => this.sign;
            set => this.RaiseAndSetIfChanged(ref this.sign, value);
        }
    }
}
