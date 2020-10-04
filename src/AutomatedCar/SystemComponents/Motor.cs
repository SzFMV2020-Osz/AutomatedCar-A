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
            if (gearPosition == Gears.D)
            {
                if (PedalsToSpeed() == 0)
                {
                    return 1000;
                }
                else if (PedalsToSpeed() <= 10)
                {
                    return 1000 + PedalsToSpeed() * 85;
                }
                else if (PedalsToSpeed() == 11)
                {
                    return 1100;
                }
                else if (PedalsToSpeed() > 11 && PedalsToSpeed() <= 25)
                {
                    return 1100 + PedalsToSpeed() * 30;
                }
                else if (PedalsToSpeed() == 26)
                {
                    return 1200;
                }
                else if (PedalsToSpeed() > 26 && PedalsToSpeed() <= 40)
                {
                    return 1200 + PedalsToSpeed() * 15;
                }
                else if (PedalsToSpeed() == 41)
                {
                    return 1300;
                }
                else if (PedalsToSpeed() > 41 && PedalsToSpeed() <= 60)
                {
                    return 1300 + PedalsToSpeed() * 14;
                }
                else if (PedalsToSpeed() == 61)
                {
                    return 1350;
                }
                else
                {                  
                    return 1350 + PedalsToSpeed() * 23;
                }
            }
            else if (gearPosition == Gears.N)
            {
                return 1000 + (int)gasPedal * 50;
            }
            else if (gearPosition == Gears.R)
            {
                return 1000 + PedalsToSpeed() * 85;
            }
            else
            {
                return 1000;
            }
        }
    }
}
