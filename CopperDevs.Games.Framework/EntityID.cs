namespace CopperDevs.Games.Framework;

public readonly struct EntityID(int value)
{
    public readonly int value = value;

    public static implicit operator EntityID(int value) => new(value);
    public static implicit operator int(EntityID id) => id.value;
    public override string ToString() => value.ToString();
}