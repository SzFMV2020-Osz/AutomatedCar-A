namespace AutomatedCar.SystemComponents
{
    using System.Net.Http.Headers;
    using AutomatedCar.SystemComponents.Packets;
    using Avalonia.Input;

    public class HumanMachineInterface : SystemComponent, IHumanMachineInterface
    {
        private HMIPacket hmiPacket;
        private DebugPacket debugPacket;

        #region Variables
        private bool gaspedalDown;
        private bool breakpedalDown;
        private bool steeringRight;
        private bool steeringLeft;
        private bool geerUp;
        private bool geerDown;
        private bool acc;
        private bool accDistance;
        private bool accSpeedPlus;
        private bool accSpeedMinus;
        private bool laneKeeping;
        private bool parkingPilot;
        private bool turnSignalRight;
        private bool turnSignalLeft;
        private bool ultrasoundDebug;
        private bool radarDebug;
        private bool cameraDebug;
        #endregion

        public HumanMachineInterface(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.virtualFunctionBus = virtualFunctionBus;
            virtualFunctionBus.RegisterComponent(this);

            this.hmiPacket = new HMIPacket();
            this.debugPacket = new DebugPacket();
            virtualFunctionBus.HMIPacket = this.hmiPacket;
            virtualFunctionBus.DebugPacket = this.debugPacket;
        }

        #region Properties
        public bool GaspedalDown { get => this.gaspedalDown; set => this.gaspedalDown = value; }

        public bool BreakpedalDown { get => this.breakpedalDown; set => this.breakpedalDown = value; }

        public bool SteeringRight { get => this.steeringRight; set => this.steeringRight = value; }

        public bool SteeringLeft { get => this.steeringLeft; set => this.steeringLeft = value; }

        public bool GeerUp { get => this.geerUp; set => this.geerUp = value; }

        public bool GeerDown { get => this.geerDown; set => this.geerDown = value; }

        public bool ACC { get => this.acc; set => this.acc = value; }

        public bool ACCDistance { get => this.accDistance; set => this.accDistance = value; }

        public bool ACCSpeedPlus { get => this.accSpeedPlus; set => this.accSpeedPlus = value; }

        public bool ACCSpeedMinus { get => this.accSpeedMinus; set => this.accSpeedMinus = value; }

        public bool LaneKeeping { get => this.laneKeeping; set => this.laneKeeping = value; }

        public bool ParkingPilot { get => this.parkingPilot; set => this.parkingPilot = value; }

        public bool TurnSignalRight { get => this.turnSignalRight; set => this.turnSignalRight = value; }

        public bool TurnSignalLeft { get => this.turnSignalLeft; set => this.turnSignalLeft = value; }

        public bool UtrasoundDebug { get => this.ultrasoundDebug; set => this.ultrasoundDebug = value; }

        public bool RadarDebug { get => this.radarDebug; set => this.radarDebug = value; }

        public bool CameraDebug { get => this.cameraDebug; set => this.cameraDebug = value; }

        HMIPacket IHumanMachineInterface.hmiPacket { get => this.hmiPacket; }

        DebugPacket IHumanMachineInterface.debugPacket { get => this.debugPacket; }
        #endregion

        public override void Process()
        {
        }

        #region InputHandler
        public void InputHandler()
        {
            this.GaspedalKey();
            this.BreakpedalKey();
            this.SteerRightKey();
            this.SteerLeftKey();
            this.AccSpeedPlusKey();
            this.AccSpeedMinusKey();
            this.AccDistanceKey();
            this.TurnSignalRightKey();
            this.TurnSignalLeftKey();
            this.GeerUpKey();
            this.GeerDownKey();
            this.AccKey();
            this.LaneKeepingKey();
            this.ParkingPilotKey();
            this.UltrasoundDebugKey();
            this.BoardCameraDebugKey();
            this.RadarDebugKey();
        }

        public void GaspedalKey()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                this.gaspedalDown = true;
            }
            else
            {
                this.gaspedalDown = false;
            }
        }

        public void BreakpedalKey()
        {
            if (Keyboard.IsKeyDown(Key.Down))
            {
                this.breakpedalDown = true;
            }
            else
            {
                this.breakpedalDown = false;
            }
        }

        public void SteerRightKey()
        {
            if (Keyboard.IsKeyDown(Key.Right))
            {
                this.steeringRight = true;
            }
            else
            {
                this.steeringRight = false;
            }
        }

        public void SteerLeftKey()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                this.steeringLeft = true;
            }
            else
            {
                this.steeringLeft = false;
            }
        }

        public void AccSpeedPlusKey()
        {
            if (Keyboard.IsKeyDown(Key.OemPlus))
            {
                this.accSpeedPlus = true;
            }
            else
            {
                this.accSpeedPlus = false;
            }
        }

        public void AccSpeedMinusKey()
        {
            if (Keyboard.IsKeyDown(Key.OemMinus))
            {
                this.accSpeedMinus = true;
            }
            else
            {
                this.accSpeedMinus = false;
            }
        }

        public void AccDistanceKey()
        {
            if (Keyboard.IsKeyDown(Key.T))
            {
                this.accDistance = true;
            }
            else
            {
                this.accDistance = false;
            }
        }

        public void TurnSignalRightKey()
        {
            if (Keyboard.IsKeyDown(Key.E))
            {
                this.turnSignalRight = true;
            }
            else
            {
                this.turnSignalRight = false;
            }
        }

        public void TurnSignalLeftKey()
        {
            if (Keyboard.IsKeyDown(Key.Q))
            {
                this.turnSignalLeft = true;
            }
            else
            {
                this.turnSignalLeft = false;
            }
        }

        public void GeerUpKey()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                this.geerUp = true;
            }
            else
            {
                this.geerUp = false;
            }
        }

        public void GeerDownKey()
        {
            if (Keyboard.IsKeyDown(Key.S))
            {
                this.geerDown = true;
            }
            else
            {
                this.geerUp = false;
            }
        }

        public void AccKey()
        {
            if (Keyboard.IsKeyDown(Key.A))
            {
                this.acc = true;
            }
            else
            {
                this.acc = false;
            }
        }

        public void LaneKeepingKey()
        {
            if (Keyboard.IsKeyDown(Key.D))
            {
                this.laneKeeping = true;
            }
            else
            {
                this.laneKeeping = false;
            }
        }

        public void ParkingPilotKey()
        {
            if (Keyboard.IsKeyDown(Key.R))
            {
                this.parkingPilot = true;
            }
            else
            {
                this.parkingPilot = false;
            }
        }

        public void UltrasoundDebugKey()
        {
            if (Keyboard.IsKeyDown(Key.U))
            {
                this.ultrasoundDebug = true;
            }
            else
            {
                this.ultrasoundDebug = false;
            }
        }

        public void BoardCameraDebugKey()
        {
            if (Keyboard.IsKeyDown(Key.Z))
            {
                this.cameraDebug = true;
            }
            else
            {
                this.cameraDebug = false;
            }
        }

        public void RadarDebugKey()
        {
            if (Keyboard.IsKeyDown(Key.I))
            {
                this.radarDebug = true;
            }
            else
            {
                this.radarDebug = false;
            }
        }
        #endregion
    }
}
