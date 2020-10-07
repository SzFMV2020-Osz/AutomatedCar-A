﻿using AutomatedCar;
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
            Assert.False(hmi.Acc);
            Assert.False(hmi.AccDistance);
            Assert.False(hmi.AccSpeedMinus);
            Assert.False(hmi.AccSpeedPlus);
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
        public void WithBadInputsGaspedalStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Up);
            hmi.GaspedalKey();

            Assert.False(hmi.GaspedalDown);
        }

        [Fact]
        public void WithBadInputsBreakpedalStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Down);
            hmi.BreakpedalKey();

            Assert.False(hmi.BreakpedalDown);
        }

        [Fact]
        public void tWithBadInputsSteerRightStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Right);
            hmi.SteerRightKey();

            Assert.False(hmi.SteeringRight);
        }

        [Fact]
        public void tWithBadInputsSteerLefttStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Left);
            hmi.SteerLeftKey();

            Assert.False(hmi.SteeringLeft);
        }

        [Fact]
        public void tWithBadInputsAccSpeedPlusStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.OemPlus);
            hmi.AccSpeedPlusKey();

            Assert.False(hmi.AccSpeedPlus);
        }

        [Fact]
        public void tWithBadInputsAccSpeedMinusStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.OemMinus);
            hmi.AccSpeedMinusKey();

            Assert.False(hmi.AccSpeedMinus);
        }

        [Fact]
        public void tWithBadInputsAccDistanceStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.T);
            hmi.AccDistanceKey();

            Assert.False(hmi.AccDistance);
        }

        [Fact]
        public void tWithBadInputsTurnSignalRightStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.E);
            hmi.TurnSignalRightKey();

            Assert.False(hmi.TurnSignalRight);
        }

        [Fact]
        public void tWithBadInputsTurnSignalLeftStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Q);
            hmi.TurnSignalLeftKey();

            Assert.False(hmi.TurnSignalLeft);
        }

        [Fact]
        public void tWithBadInputsGeerUpStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.W);
            hmi.GeerUpKey();

            Assert.False(hmi.GeerUp);
        }

        [Fact]
        public void tWithBadInputsGeerDownStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.S);
            hmi.GeerDownKey();

            Assert.False(hmi.GeerDown);
        }

        [Fact]
        public void tWithBadInputsAccStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.A);
            hmi.AccKey();

            Assert.False(hmi.Acc);
        }

        [Fact]
        public void WithBadInputsLaneKeepingStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.D);
            hmi.LaneKeepingKey();

            Assert.False(hmi.LaneKeeping);
        }

        [Fact]
        public void WithBadInputsParkingPilotStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.R);
            hmi.ParkingPilotKey();

            Assert.False(hmi.ParkingPilot);
        }

        [Fact]
        public void WithBadInputsUtrasoundDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.U);
            hmi.UltrasoundDebugKey();

            Assert.False(hmi.UtrasoundDebug);
        }

        [Fact]
        public void WithBadInputsCameraDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.Z);
            hmi.BoardCameraDebugKey();

            Assert.False(hmi.CameraDebug);
        }

        [Fact]
        public void WithBadInputsRadarDebugStaysFalse()
        {
            KeyboardFill();
            Keyboard.Keys.Remove(Key.I);
            hmi.RadarDebugKey();

            Assert.False(hmi.RadarDebug);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueGaspedal()
        {
            Keyboard.Keys.Add(Key.Up);
            hmi.GaspedalKey();

            Assert.True(hmi.GaspedalDown);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueBreakpedal()
        {
            Keyboard.Keys.Add(Key.Down);
            hmi.BreakpedalKey();

            Assert.True(hmi.BreakpedalDown);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueSteeringRight()
        {
            Keyboard.Keys.Add(Key.Right);
            hmi.SteerRightKey();

            Assert.True(hmi.SteeringRight);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueSteeringLeft()
        {
            Keyboard.Keys.Add(Key.Left);
            hmi.SteerLeftKey();

            Assert.True(hmi.SteeringLeft);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueAcc()
        {
            Keyboard.Keys.Add(Key.A);
            hmi.AccKey();

            Assert.True(hmi.Acc);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueAccDistance()
        {
            Keyboard.Keys.Add(Key.T);
            hmi.AccDistanceKey();

            Assert.True(hmi.AccDistance);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueAccSpeedPlus()
        {
            Keyboard.Keys.Add(Key.OemPlus);
            hmi.AccSpeedPlusKey();

            Assert.True(hmi.AccSpeedPlus);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueAccSpeedMinus()
        {
            Keyboard.Keys.Add(Key.OemMinus);
            hmi.AccSpeedMinusKey();

            Assert.True(hmi.AccSpeedMinus);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueTurnSignalRight()
        {
            Keyboard.Keys.Add(Key.E);
            hmi.TurnSignalRightKey();

            Assert.True(hmi.TurnSignalRight);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueTurnSignalLeft()
        {
            Keyboard.Keys.Add(Key.Q);
            hmi.TurnSignalLeftKey();

            Assert.True(hmi.TurnSignalLeft);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueGeerUp()
        {
            Keyboard.Keys.Add(Key.W);
            hmi.GeerUpKey();

            Assert.True(hmi.GeerUp);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueGeerDown()
        {
            Keyboard.Keys.Add(Key.S);
            hmi.GeerDownKey();

            Assert.True(hmi.GeerDown);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueLaneKeeping()
        {
            Keyboard.Keys.Add(Key.D);
            hmi.LaneKeepingKey();

            Assert.True(hmi.LaneKeeping);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueParkingPilot()
        {
            Keyboard.Keys.Add(Key.R);
            hmi.ParkingPilotKey();

            Assert.True(hmi.ParkingPilot);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueUtrasoundDebug()
        {
            Keyboard.Keys.Add(Key.U);
            hmi.UltrasoundDebugKey();

            Assert.True(hmi.UtrasoundDebug);
        }

        [Fact]

        public void WithTheRightKeyPressedTrueRadarDebug()
        {
            Keyboard.Keys.Add(Key.I);
            hmi.RadarDebugKey();

            Assert.True(hmi.RadarDebug);
        }

        [Fact]
        public void WithTheRightKeyPressedTrueCameraDebug()
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