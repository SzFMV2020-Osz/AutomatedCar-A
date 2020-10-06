using AutomatedCar.SystemComponents;
using AutomatedCar.SystemComponents.Packets;
using Xunit;

namespace Tests.SystemComponents.Packets
{
    public class HMIPacketTests
    {
        HMIPacket hmiPacket;
        HumanMachineInterface hmi;

        public  HMIPacketTests()
        {
            hmiPacket = new HMIPacket();
            hmiPacket.Sign = "";
            hmi = new HumanMachineInterface(new VirtualFunctionBus());
        }

        #region Existence tests
        [Fact]
        public void GaspedalExsits()
        {
            Assert.IsType<double>(hmiPacket.Gaspedal);
        }

        [Fact]
        public void BreakpedalExsits()
        {
            Assert.IsType<double>(hmiPacket.Breakpedal);
        }

        [Fact]
        public void SteeringExsits()
        {
            Assert.IsType<double>(hmiPacket.Steering);
        }
        [Fact]
        public void GearExsits()
        {
            Assert.IsType<Gears>(hmiPacket.Gear);
        }

        [Fact]
        public void ACCExsist()
        {
            Assert.IsType<bool>(hmiPacket.ACC);
        }

        [Fact]
        public void ACCDistanceExsits()
        {
            Assert.IsType<double>(hmiPacket.ACCDistance);
        }

        [Fact]
        public void ACCSpeedExsits()
        {
            Assert.IsType<int>(hmiPacket.ACCSpeed);
        }
        [Fact]
        public void LaneKeepingExsits()
        {
            Assert.IsType<bool>(hmiPacket.LaneKeeping);
        }

        [Fact]
        public void ParkingPilotExsits()
        {
            Assert.IsType<bool>(hmiPacket.ParkingPilot);
        }

        [Fact]
        public void TurnSignalRightExsits()
        {
            Assert.IsType<bool>(hmiPacket.TurnSignalRight);
        }

        [Fact]
        public void TurnSignalLeftExsits()
        {
            Assert.IsType<bool>(hmiPacket.TurnSignalLeft);
        }

        [Fact]
        public void SignExsits()
        {
            Assert.Equal(string.Empty, hmiPacket.Sign);
        }
        #endregion

        #region VariableChangeTests
        [Theory]
        [InlineData(0, Gears.P)]
        [InlineData(1, Gears.R)]
        [InlineData(2, Gears.N)]
        [InlineData(3, Gears.D)]
        [InlineData(4, Gears.D)]
        public void WithNumerousGearshiftsUpwardGearIncreasesTillDrivemode(int gearshiftsUp, Gears gear)
        {
            hmi.GeerUp = true;
            hmi.GeerDown = false;
            for (int i = 0; i < gearshiftsUp; i++)
            {
                hmiPacket.GearCalculate(); 
            }
            Assert.Equal(gear, hmiPacket.Gear);
        }

        [Theory]
        [InlineData(3, Gears.P)]
        [InlineData(2, Gears.R)]
        [InlineData(1, Gears.N)]
        [InlineData(0, Gears.D)]
        [InlineData(4, Gears.P)]
        public void WithNumerousGearshiftsDownwardGearDecreasesTillParkingmode(int gearshiftsDown, Gears gear)
        {
            hmi.GeerDown = true;
            hmi.GeerUp = false;
            hmiPacket.Gear = Gears.D;
            for (int i = 0; i < gearshiftsDown; i++)
            {
                hmiPacket.GearCalculate();
            }
            Assert.Equal(gear, hmiPacket.Gear);
        }



        #endregion
    }
}
