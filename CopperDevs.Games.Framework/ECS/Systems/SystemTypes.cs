using System.Diagnostics.CodeAnalysis;

namespace CopperDevs.Games.Framework.ECS.Systems;

public record SystemType;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class SystemTypes
{
    public sealed record FrameUpdate : SystemType;
}