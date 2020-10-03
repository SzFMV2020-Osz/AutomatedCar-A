namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Powertrain 
    {
        private double speed;
        private double steering;
        private Motor motor;

        public Powertrain()
        {
            this.motor = new Motor();
        }

        public double Speed { get => this.speed; set => this.speed = this.motor.GasPedalToSpeed(); }

        private double Steering { get => this.steering; set => this.steering = this.SteeringWheel(); }

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
