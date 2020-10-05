namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutomatedCar.SystemComponents.Packets;

    public class Powertrain : SystemComponent
    {
        private const double maximumSteeringAngle =  0.3 * Math.PI; //54°
        private const double carWheelbase = 130;

        private IReadOnlyHMIPacket hmiPacket;
        private PowertrainPacket powertrainPacket;
        private Motor motor;

        private double steeringRotation;
        private int x;
        private int y;

        public Powertrain(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.motor = new Motor();
            this.virtualFunctionBus = virtualFunctionBus;
            this.virtualFunctionBus.RegisterComponent(this);

            this.hmiPacket = this.virtualFunctionBus.HMIPacket;
            this.powertrainPacket = new PowertrainPacket();
            virtualFunctionBus.PowertrainPacket = this.powertrainPacket;
        }

        public double SteeringRotation { get => this.steeringRotation; set => this.steeringRotation = value; }

        public double Speed { get => this.motor.PedalsToSpeed(); }

        private double Steering { get => this.SteeringWheel();  }

        public override void Process()
        {
            this.motor.GasPedal = this.hmiPacket.Gaspedal;
            this.motor.BreakPedal = this.hmiPacket.Breakpedal;
            this.motor.GearPosition = this.hmiPacket.Gear;

            this.SteeringRotation = this.hmiPacket.Steering;

            this.powertrainPacket._X = this.x;
            this.powertrainPacket._Y = this.y;
            this.powertrainPacket.Speed = this.Speed;
            this.powertrainPacket.RPM = this.motor.Rpm;
        }

        public void VectorCalculator()
        {
            // use: this.motor.GearPosition, this.Speed, this.Steering
        }

        private void EvaluateInput()
        {
        }

        private double SteeringWheel()
        {
            // use: this.SteeringRotation
            double steeringAngle = maximumSteeringAngle * Math.Abs(virtualFunctionBus.HMIPacket.Steering);
            double tuningCenterDistance = Math.Tan(steeringAngle) * carWheelbase;
            return tuningCenterDistance;
        }
    }
}
