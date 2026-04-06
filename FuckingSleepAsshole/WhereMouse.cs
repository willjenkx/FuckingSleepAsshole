using System.Runtime.InteropServices;

namespace FuckingSleepAsshole;

public static class WhereMouse
{ 
    [DllImport( "user32.dll", SetLastError = true)]
    private static extern bool GetCursorPos(out Point lpPoint);
    
    public static Point GetPosition()
    {
        GetCursorPos(out var lpPoint);
        return lpPoint;
    }
}

/// <summary>
/// I swear to god the autocomplete recommends so much shit for no good reason
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Point : IEquatable<Point>
{
    public int X;
    public int Y;
    
    public override bool Equals(object? obj) => obj is Point other && CompareTo(other);

    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    private bool CompareTo(Point other) => X == other.X && Y == other.Y;

    public static bool operator ==(Point left, Point right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Point left, Point right)
    {
        return !(left == right);
    }
}