namespace CopperDevs.Games.Framework.ECS;

public record SystemType;

public record StreamType;

public record FilterType;

public sealed class SystemTypes
{
    public sealed record FrameUpdate : SystemType;
}

public sealed class StreamTypes
{
    public sealed record For : StreamType;

    public sealed record Job : StreamType;
}

public sealed class FilterTypes
{
    public sealed record Has : FilterType;

    public sealed record Not : FilterType;

    public sealed record Any : FilterType;
}