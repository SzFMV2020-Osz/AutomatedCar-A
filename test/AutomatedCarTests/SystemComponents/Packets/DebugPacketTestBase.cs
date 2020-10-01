using AutomatedCar.SystemComponents.Packets;
using Xunit;

namespace Tests.SystemComponents.Packets
{
    public abstract class DebugPacketTestBase
    {
        public DebugPacket debugPacket;
        protected DebugPacketTestBase()
        {
            debugPacket = new DebugPacket();
        }

    }
}