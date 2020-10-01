namespace AutomatedCar.SystemComponents.Packets
{
    class DebugPacket : IReadOnlyDebugPacket
    {
        private bool utrasoundSensor;
        private bool radarSensor;
        private bool boardCamera;

        public bool UtrasoundSensor { get => utrasoundSensor; set => utrasoundSensor = value; }

        public bool RadarSensor { get => radarSensor; set => radarSensor = value; }

        public bool BoardCamera { get => boardCamera; set => boardCamera = value; }
    }
}
