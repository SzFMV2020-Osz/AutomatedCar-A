namespace AutomatedCar.SystemComponents
{
    using System.Net.Http.Headers;
    using AutomatedCar.SystemComponents.Packets;

    public class HumanMachineInterface : SystemComponent, IHumanMachineInterface
    {
        private HMIPacket hMIPacket;
        private DebugPacket debugPacket;

        #region Variables
        private bool gaspedalDown;
        private bool breakpedalDown;
        private bool steeringRight;
        private bool steeringLeft;
        private bool geerUp;
        private bool geerDown;
        private bool aCC;
        private bool aCC_Distance;
        private bool aCC_SpeedPus;
        private bool aCC_SpeedMinus;
        private bool laneKeeping;
        private bool parkingPilot;
        private bool turnSignalRight;
        private bool turnSignalLeft;
        private bool utrasoundDebug;
        private bool radarDebug;
        private bool cameraDebug; 
        #endregion

        public HumanMachineInterface(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.virtualFunctionBus = virtualFunctionBus;
            virtualFunctionBus.RegisterComponent(this);

            this.hMIPacket = new HMIPacket();
            this.debugPacket = new DebugPacket();
            virtualFunctionBus.HMIPacket = this.hMIPacket;
            virtualFunctionBus.DebugPacket = this.debugPacket;
        }

        #region Properties
        public bool GaspedalDown { get => this.gaspedalDown; set => this.gaspedalDown = value; }

        public bool BreakpedalDown { get => this.breakpedalDown; set => this.breakpedalDown = value; }

        public bool SteeringRight { get => this.steeringRight; set => this.steeringRight = value; }

        public bool SteeringLeft { get => this.steeringLeft; set => this.steeringLeft = value; }

        public bool GeerUp { get => this.geerUp; set => this.geerUp = value; }

        public bool GeerDown { get => this.geerDown; set => this.geerDown = value; }

        public bool ACC { get => this.aCC; set => this.aCC = value; }

        public bool ACC_Distance { get => this.aCC_Distance; set => this.aCC_Distance = value; }

        public bool ACC_SpeedPus { get => this.aCC_SpeedPus; set => this.aCC_SpeedPus = value; }

        public bool ACC_SpeedMinus { get => this.aCC_SpeedMinus; set => this.aCC_SpeedMinus = value; }

        public bool LaneKeeping { get => this.laneKeeping; set => this.laneKeeping = value; }

        public bool ParkingPilot { get => this.parkingPilot; set => this.parkingPilot = value; }

        public bool TurnSignalRight { get => this.turnSignalRight; set => this.turnSignalRight = value; }

        public bool TurnSignalLeft { get => this.turnSignalLeft; set => this.turnSignalLeft = value; }

        public bool UtrasoundDebug { get => this.utrasoundDebug; set => this.utrasoundDebug = value; }

        public bool RadarDebug { get => this.radarDebug; set => this.radarDebug = value; }

        public bool CameraDebug { get => this.cameraDebug; set => this.cameraDebug = value; }

        HMIPacket IHumanMachineInterface.hMIPacket { get => this.hMIPacket; }

        DebugPacket IHumanMachineInterface.debugPacket { get => this.debugPacket; }
        #endregion

        public override void Process()
        {
        }
    }
}
