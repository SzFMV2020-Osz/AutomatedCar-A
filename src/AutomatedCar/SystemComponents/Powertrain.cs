namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Powertrain : SystemComponent
    {
        private double speed;
        private double steering;
        private Motor motor;

        public Powertrain(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.motor = new Motor();
            virtualFunctionBus.RegisterComponent(this); 
        }

        public double Speed { get => this.speed; set => this.speed = this.motor.GasPedalToSpeed(); }

        private double Steering { get => this.steering; set => this.steering = this.SteeringWheel(); }

        public override void Process()
        {
            throw new NotImplementedException();            
        }

        public void VectorCalculator()
        {
            // use: motor.GearPosition, this.Speed, this.Steering
        }

        private void EvaluateInput()
        {
        }

        private double SteeringWheel()
        {
            return 0;
        }
    }
}
