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

        public int GasPedalToSpeed()
        {
            return 0;
        }

        private int CheckRpm()
        {
            return 0;
        }

        private void BreakPedalAction()
        {
        }
    }
}
