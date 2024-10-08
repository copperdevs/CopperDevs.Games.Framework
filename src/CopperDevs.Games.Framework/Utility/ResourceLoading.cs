﻿using System.Reflection;
using Raylib_CSharp.Images;
using Raylib_CSharp.Textures;

namespace CopperDevs.Games.Framework.Utility;

public static class ResourceLoading
{
    public static byte[] LoadAsset(Assembly targetAssembly, string fullPath)
    {
        var stream = targetAssembly.GetManifestResourceStream(fullPath);

        using var ms = new MemoryStream();

        stream?.CopyTo(ms);

        return ms.ToArray();
    }

    public static Image LoadImage(Assembly targetAssembly, string fullPath)
    {
        return Image.LoadFromMemory(Path.GetExtension(fullPath), LoadAsset(targetAssembly, fullPath));
    }

    public static Texture2D LoadTexture(Assembly targetAssembly, string fullPath)
    {
        var loadedImage = LoadImage(targetAssembly, fullPath);

        var loadedTexture = Texture2D.LoadFromImage(loadedImage);

        loadedImage.Unload();

        return loadedTexture;
    }
}

public static class ResourceLoadingExtensions
{
    public static byte[] LoadAsset(this Assembly assembly, string fullPath) => ResourceLoading.LoadAsset(assembly, fullPath);

    public static Image LoadImage(this Assembly assembly, string fullPath) => ResourceLoading.LoadImage(assembly, fullPath);

    public static Texture2D LoadTexture(this Assembly assembly, string fullPath) => ResourceLoading.LoadTexture(assembly, fullPath);
}