public enum Gears {P, R, N, D}

public interface IReadOnlyHMIPacket
{
    double Gaspedal { get; }

    double Breakpedal { get; }

    double Steering { get; }

    Gears Gear { get; }

    double ACC_Distance { get; }

    int ACC_Speed { get; }

    bool LaneKeeping { get; }

    bool ParkingPilot { get; }

    bool TurnSignalRight { get; }

    bool TurnSignalLeft { get; }

    string Sign { get; }
}