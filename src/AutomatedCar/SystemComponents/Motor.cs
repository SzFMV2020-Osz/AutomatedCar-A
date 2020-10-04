namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Motor
    {
        private int rpm;
        private double gasPedal;
        private double breakPedal;
        private Gears gearPosition;
        private int automaticShiftGear;

        public int Rpm { get => this.rpm; set => this.rpm = this.CheckRpm(); }

        public Gears GearPosition { get => this.gearPosition; set => this.gearPosition = value; }

        public int AutomaticShiftGear { get => this.automaticShiftGear; set => this.automaticShiftGear = value; }

        /// <summary>
        /// Converts the pedalpositions to speed. Max speed = 200.
        /// </summary>
        /// <param name="gasP"> Gaspedal position. </param>
        /// <param name="breakP"> Breakpedal position. </param>
        /// <returns> Returns speed. </returns>
        public int GasPedalToSpeed(double gasP, double breakP) // better name would be: "PedalsToSpeed"
        {
            if (gasP - breakP < 0)
            {
                double s = (gasP - breakP) * -1;
                return (int)this.NthRoot(s, 1.7) * -200;
            }
            else
            {
                return (int)this.NthRoot(gasP - breakP, 1.7) * 200;
            }
        }

        /// <summary>
        /// Calculates Nth Root of double value.
        /// </summary>
        /// <param name="a"> The value.</param>
        /// <param name="n"> Nth root.</param>
        /// <returns>Teturn the nth root.</returns>
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
