using AutomatedCar;
using AutomatedCar.SystemComponents;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.SystemComponents
{
    public class InputHandlerTests : IDisposable
    {
        HumanMachineInterface hmi;

        public InputHandlerTests()
        {
            hmi = new HumanMachineInterface(new VirtualFunctionBus());
        }

        public void KeyboardFill()
        {
            for (int i = 0; i < 173; i++)
            {
                Keyboard.Keys.Add((Key)i);
            }
            for (int i = 10001; i < 10005; i++)
            {
                Keyboard.Keys.Add((Key)i);
            }
        }

        [Fact]
        public void WhitoutKeyPressedAllVarialbeRemainsFalse()
        {           
            hmi.InputHandler();
            Assert.False(hmi.ACC);
            Assert.False(hmi.ACCDistance);
            Assert.False(hmi.ACCSpeedMinus);
            Assert.False(hmi.ACCSpeedPlus);
            Assert.False(hmi.BreakpedalDown);
            Assert.False(hmi.CameraDebug);
            Assert.False(hmi.GaspedalDown);
            Assert.False(hmi.GeerDown);
            Assert.False(hmi.GeerUp);
            Assert.False(hmi.LaneKeeping);
            Assert.False(hmi.ParkingPilot);
            Assert.False(hmi.RadarDebug);
            Assert.False(hmi.SteeringLeft);
            Assert.False(hmi.SteeringRight);
            Assert.False(hmi.TurnSignalLeft);
            Assert.False(hmi.TurnSignalRight);
            Assert.False(hmi.UtrasoundDebug);
        }

        [Fact]
        public void WhitBadInpustGaspedalStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Up);
            hmi.GaspedalKey();

            Assert.False(hmi.GaspedalDown);
        }

        [Fact]
        public void WhitBadInpustBreakpedalStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Down);
            hmi.BreakpedalKey();

            Assert.False(hmi.BreakpedalDown);
        }

        [Fact]
        public void tWhitBadInpustSteerRightStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Right);
            hmi.SteerRightKey();

            Assert.False(hmi.SteeringRight);
        }

        [Fact]
        public void tWhitBadInpustSteerLefttStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Left);
            hmi.SteerLeftKey();

            Assert.False(hmi.SteeringLeft);
        }

        [Fact]
        public void tWhitBadInpustACCSpeedPlusStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.OemPlus);
            hmi.AccSpeedPlusKey();

            Assert.False(hmi.ACCSpeedPlus);
        }

        [Fact]
        public void tWhitBadInpustACCSpeedMinusStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.OemMinus);
            hmi.AccSpeedMinusKey();

            Assert.False(hmi.ACCSpeedMinus);
        }

        [Fact]
        public void tWhitBadInpustACCDistanceStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.T);
            hmi.AccDistanceKey();

            Assert.False(hmi.ACCDistance);
        }

        [Fact]
        public void tWhitBadInpustTurnSignalRightStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.E);
            hmi.TurnSignalRightKey();

            Assert.False(hmi.TurnSignalRight);
        }

        [Fact]
        public void tWhitBadInpustTurnSignalLeftStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Q);
            hmi.TurnSignalLeftKey();

            Assert.False(hmi.TurnSignalLeft);
        }

        [Fact]
        public void tWhitBadInpustGeerUpStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.W);
            hmi.GeerUpKey();

            Assert.False(hmi.GeerUp);
        }

        [Fact]
        public void tWhitBadInpustGeerDownStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.S);
            hmi.GeerDownKey();

            Assert.False(hmi.GeerDown);
        }

        [Fact]
        public void tWhitBadInpustACCStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.A);
            hmi.AccKey();

            Assert.False(hmi.ACC);
        }

        [Fact]
        public void WhitBadInpustLaneKeepingStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.D);
            hmi.LaneKeepingKey();

            Assert.False(hmi.LaneKeeping);
        }

        [Fact]
        public void WhitBadInpustParkingPilotStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.R);
            hmi.ParkingPilotKey();

            Assert.False(hmi.ParkingPilot);
        }

        [Fact]
        public void WhitBadInpustUtrasoundDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.U);
            hmi.UltrasoundDebugKey();

            Assert.False(hmi.UtrasoundDebug);
        }

        [Fact]
        public void WhitBadInpustCameraDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Z);
            hmi.BoardCameraDebugKey();

            Assert.False(hmi.CameraDebug);
        }

        [Fact]
        public void WhitBadInpustRadarDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.I);
            hmi.RadarDebugKey();

            Assert.False(hmi.RadarDebug);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueGaspedal()
        {
            Keyboard.Keys.Add(Key.Up);
            hmi.GaspedalKey();

            Assert.True(hmi.GaspedalDown);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueBreakpedal()
        {
            Keyboard.Keys.Add(Key.Down);
            hmi.BreakpedalKey();

            Assert.True(hmi.BreakpedalDown);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueSteeringRight()
        {
            Keyboard.Keys.Add(Key.Right);
            hmi.SteerRightKey();

            Assert.True(hmi.SteeringRight);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueSteeringLeft()
        {
            Keyboard.Keys.Add(Key.Left);
            hmi.SteerLeftKey();

            Assert.True(hmi.SteeringLeft);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueACC()
        {
            Keyboard.Keys.Add(Key.A);
            hmi.AccKey();

            Assert.True(hmi.ACC);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueACCDistance()
        {
            Keyboard.Keys.Add(Key.T);
            hmi.AccDistanceKey();

            Assert.True(hmi.ACCDistance);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueACCSpeedPlus()
        {
            Keyboard.Keys.Add(Key.OemPlus);
            hmi.AccSpeedPlusKey();

            Assert.True(hmi.ACCSpeedPlus);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueACCSpeedMinus()
        {
            Keyboard.Keys.Add(Key.OemMinus);
            hmi.AccSpeedMinusKey();

            Assert.True(hmi.ACCSpeedMinus);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueTurnSignalRight()
        {
            Keyboard.Keys.Add(Key.E);
            hmi.TurnSignalRightKey();

            Assert.True(hmi.TurnSignalRight);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueTurnSignalLeft()
        {
            Keyboard.Keys.Add(Key.Q);
            hmi.TurnSignalLeftKey();

            Assert.True(hmi.TurnSignalLeft);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueGeerUp()
        {
            Keyboard.Keys.Add(Key.W);
            hmi.GeerUpKey();

            Assert.True(hmi.GeerUp);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueGeerDown()
        {
            Keyboard.Keys.Add(Key.S);
            hmi.GeerDownKey();

            Assert.True(hmi.GeerDown);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueLaneKeeping()
        {
            Keyboard.Keys.Add(Key.D);
            hmi.LaneKeepingKey();

            Assert.True(hmi.LaneKeeping);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueParkingPilot()
        {
            Keyboard.Keys.Add(Key.R);
            hmi.ParkingPilotKey();

            Assert.True(hmi.ParkingPilot);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueUtrasoundDebug()
        {
            Keyboard.Keys.Add(Key.U);
            hmi.UltrasoundDebugKey();

            Assert.True(hmi.UtrasoundDebug);
        }

        [Fact]

        public void WhitTheRightKeyPressedTrueRadarDebug()
        {
            Keyboard.Keys.Add(Key.I);
            hmi.RadarDebugKey();

            Assert.True(hmi.RadarDebug);
        }

        [Fact]
        public void WhitTheRightKeyPressedTrueCameraDebug()
        {
            Keyboard.Keys.Add(Key.Z);
            hmi.BoardCameraDebugKey();

            Assert.True(hmi.CameraDebug);
        }

        public void Dispose()
        {
            Keyboard.Keys.Clear();
        }
    }
}
