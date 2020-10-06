using AutomatedCar.SystemComponents.Packets;
using Xunit;

namespace Tests.SystemComponents.Packets
{
    public abstract class HMIPacketTestBase
    {
        public HMIPacket hmiPacket;
        protected HMIPacketTestBase()
        {
            hmiPacket = new HMIPacket();
            hmiPacket.Sign = "";
        }
    }
}