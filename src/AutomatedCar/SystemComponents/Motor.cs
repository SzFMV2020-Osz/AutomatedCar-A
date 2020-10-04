namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Motor
    {
        private double gasPedal;
        private double breakPedal;
        private Gears gearPosition;

        public int Rpm { get => this.CheckRpm(); }

        public double GasPedal { get => this.gasPedal; set => this.gasPedal = value; }

        public double BreakPedal { get => this.breakPedal; set => this.breakPedal = value; }

        public Gears GearPosition { get => this.gearPosition; set => this.gearPosition = value; }

        public int PedalsToSpeed()
        {
            if (this.gasPedal - this.breakPedal < 0)
            {
                double s = (this.gasPedal - this.breakPedal) * -1;
                return (int)this.NthRoot(s, 1.7) * -200;
            }
            else
            {
                return (int)this.NthRoot(this.gasPedal - this.breakPedal, 1.7) * 200;
            }
        }

        private double NthRoot(double a, double n)
        {
            return Math.Pow(a, 1.0 / n);
        }

        private int CheckRpm()
        {
            return 0;
        }
    }
}
