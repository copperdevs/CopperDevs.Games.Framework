namespace CopperDevs.Games.Framework;

public readonly struct EntityID(int value)
{
    public static implicit operator EntityID(int value) => new(value);
    public override string ToString() => value.ToString();
}