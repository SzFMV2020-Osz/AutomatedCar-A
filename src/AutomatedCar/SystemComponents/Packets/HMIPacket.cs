using Avalonia.OpenGL;
using System;
using System.Threading;

namespace AutomatedCar.SystemComponents.Packets
{
    public class HMIPacket : IReadOnlyHMIPacket
    {
        private double gaspedal;
        private double breakpedal;
        private double steering;
        private Gears gear;
        private bool acc;
        private double accDistance = 0.8;
        private int accSpeed = 30;
        private bool laneKeeping;
        private bool parkingPilot;
        private bool turnSignalRight;
        private bool turnSignalLeft;
        private string sign = string.Empty;

        public double Gaspedal { get => this.gaspedal; set => this.gaspedal = value; }

        public double Breakpedal { get => this.breakpedal; set => this.breakpedal = value; }

        public double Steering { get => this.steering; set => this.steering = value; }

        public Gears Gear { get => this.gear; set => this.gear = value; }

        public bool Acc { get => this.acc; set => this.acc = value; }

        public double AccDistance { get => this.accDistance; set => this.accDistance = value; }

        public int AccSpeed { get => this.accSpeed; set => this.accSpeed = value; }

        public bool LaneKeeping { get => this.laneKeeping; set => this.laneKeeping = value; }

        public bool ParkingPilot { get => this.parkingPilot; set => this.parkingPilot = value; }

        public bool TurnSignalRight { get => this.turnSignalRight; set => this.turnSignalRight = value; }

        public bool TurnSignalLeft { get => this.turnSignalLeft; set => this.turnSignalLeft = value; }

        public string Sign { get => this.sign; set => this.sign = value; }

        public void GearCalculate(bool up, bool down)
        {
            if (!up & down)
            {
                this.DownShift();
            }
            else if (up & !down)
            {
                this.UpShift();
            }
        }

        void UpShift()
        {
            switch (this.gear)
            {
                case Gears.P:
                    this.gear = Gears.R;
                    break;
                case Gears.N:
                    this.gear = Gears.D;
                    break;
                case Gears.R:
                    this.gear = Gears.N;
                    break;
                default:
                    break;
            }
        }

        void DownShift()
        {
            switch (this.gear)
            {
                case Gears.D:
                    this.gear = Gears.N;
                    break;
                case Gears.N:
                    this.gear = Gears.R;
                    break;
                case Gears.R:
                    this.gear = Gears.P;
                    break;
                default:
                    break;
            }
        }

        public void AccSpeedSet(bool plus, bool minus)
        {
            if (plus & !minus)
            {
                this.AccSpeedIncrease();
            }
            else if (!plus & minus)
            {
                this.AccSpeedDecrease();
            }
        }

        void AccSpeedDecrease()
        {
            if (this.accSpeed != 30)
            {
                this.accSpeed -= 10;
            }
        }

        void AccSpeedIncrease()
        {
            if (this.accSpeed != 160)
            {
                this.accSpeed += 10;
            }
        }

        public void AccDistanceSet(bool change)
        {
            if (change)
            {
                if (this.accDistance == 1.4)
                {
                    this.AccDistanceReset();
                }
                else
                {
                    this.AccDistanceIncrease();
                }
            }
        }

        private void AccDistanceReset()
        {
            this.accDistance = 0.8;
        }

        private void AccDistanceIncrease()
        {
            this.accDistance += 0.2;
        }

        public void AccSet(bool on)
        {
            if (on)
            {
                this.acc = !this.acc;
            }
        }

        public void GasPedalIncrease(double tick, int limit = 100)
        {
            Increase(tick, ref this.gaspedal, limit);
        }

        public void GasPedalDecrease(double tick, int limit = 0)
        {
            Decrease(tick, ref this.gaspedal, limit);
        }

        public void BrakePedalIncrease(double tick, int limit = 100)
        {
            Increase(tick, ref this.breakpedal, limit);
        }

        public void BrakePedalDecrease(double tick, int limit = 0)
        {
            Decrease(tick, ref this.breakpedal, limit);
        }

        private void Increase(double tick, ref double pedal, int limit = 100)
        {
            do
            {
                Thread.Sleep(Convert.ToInt32(1000 / tick));
                pedal++;
            } while (pedal != limit);
        }

        private void Decrease(double tick, ref double pedal, int limit = 0)
        {
            do
            {
                Thread.Sleep(Convert.ToInt32(1000 / tick));
                pedal--;
            } while (pedal != limit);
        }
    }
}
