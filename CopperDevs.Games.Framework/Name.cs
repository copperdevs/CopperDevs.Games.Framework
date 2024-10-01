namespace CopperDevs.Games.Framework;

public readonly struct Name(string value)
{
    public static implicit operator Name(string value) => new(value);
    public override string ToString() => value;
}