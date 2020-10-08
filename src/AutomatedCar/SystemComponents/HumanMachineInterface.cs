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
        private bool gearUp;
        private bool gearDown;
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

        public bool GearUp { get => this.gearUp; set => this.gearUp = value; }

        public bool GearDown { get => this.gearDown; set => this.gearDown = value; }

        public bool Acc { get => this.acc; set => this.acc = value; }

        public bool AccDistance { get => this.accDistance; set => this.accDistance = value; }

        public bool AccSpeedPlus { get => this.accSpeedPlus; set => this.accSpeedPlus = value; }

        public bool AccSpeedMinus { get => this.accSpeedMinus; set => this.accSpeedMinus = value; }

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
            this.hmiPacket.GearCalculate(this.gearUp, this.gearDown);
            this.hmiPacket.AccSet(this.acc);
            this.hmiPacket.AccDistanceSet(this.accDistance);
            this.hmiPacket.AccSpeedSet(this.accSpeedPlus, this.accSpeedMinus);

            this.hmiPacket.HandleGasPedal(this.gaspedalDown);
            this.hmiPacket.HandleBrakePedal(this.breakpedalDown);
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
            this.GearUpKey();
            this.GearDownKey();
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
            if (Keyboard.IsToggleableKeyDown(Key.E))
            {
                this.turnSignalRight = !this.turnSignalRight;
                Keyboard.DeleteToggleableKey(Key.E);
            }
        }

        public void TurnSignalLeftKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.Q))
            {
                this.turnSignalLeft = !this.turnSignalLeft;
                Keyboard.DeleteToggleableKey(Key.Q);
            }
        }

        public void GearUpKey()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                this.gearUp = true;
            }
            else
            {
                this.gearUp = false;
            }
        }

        public void GearDownKey()
        {
            if (Keyboard.IsKeyDown(Key.S))
            {
                this.gearDown = true;
            }
            else
            {
                this.gearUp = false;
            }
        }

        public void AccKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.A))
            {
                this.acc = !this.acc;
                Keyboard.DeleteToggleableKey(Key.A);
            }
        }

        public void LaneKeepingKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.D))
            {
                this.laneKeeping = !this.laneKeeping;
                Keyboard.DeleteToggleableKey(Key.D);
            }
        }

        public void ParkingPilotKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.R))
            {
                this.parkingPilot = !this.parkingPilot;
                Keyboard.DeleteToggleableKey(Key.R);
            }
        }

        public void UltrasoundDebugKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.U))
            {
                this.ultrasoundDebug = !this.ultrasoundDebug;
                Keyboard.DeleteToggleableKey(Key.U);
            }
        }

        public void BoardCameraDebugKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.Z))
            {
                this.cameraDebug = !this.cameraDebug;
                Keyboard.DeleteToggleableKey(Key.Z);
            }
        }

        public void RadarDebugKey()
        {
            if (Keyboard.IsToggleableKeyDown(Key.I))
            {
                this.radarDebug = !this.radarDebug;
                Keyboard.DeleteToggleableKey(Key.I);
            }
        }
        #endregion
    }
}
