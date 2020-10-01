using AutomatedCar.SystemComponents.Packets;
using Xunit;

namespace Tests.SystemComponents.Packets
{
    public class DebugPacketTests : DebugPacketTestBase
    {

        [Fact]
        public void UltrasoundSensorExsits()
        {
            
            Assert.IsType<bool>(debugPacket.UtrasoundSensor);
        }

        [Fact]
        public void BoardCameraExsits()
        {
            Assert.IsType<bool>(debugPacket.BoardCamera);
        }

        [Fact]
        public void RadarSensorExsits()
        {
            Assert.IsType<bool>(debugPacket.RadarSensor);
        }
    }
}
