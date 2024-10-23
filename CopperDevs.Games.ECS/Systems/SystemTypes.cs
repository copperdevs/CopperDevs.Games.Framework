// ReSharper disable ClassNeverInstantiated.Global
namespace CopperDevs.Games.ECS.Systems;

public record SystemType;

public record StreamType;

public sealed class SystemTypes
{
    public sealed record FrameUpdate : SystemType;

    public sealed record FixedUpdate : SystemType;
}

public sealed class StreamTypes
{
    public sealed record For : StreamType;

    public sealed record Job : StreamType;
}