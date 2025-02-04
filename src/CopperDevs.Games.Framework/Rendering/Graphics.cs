
namespace CopperDevs.Games.Framework.Rendering;

public static class Graphics
{
    /// <inheritdoc cref="Raylib.ClearBackground" />
    public static void ClearBackground(Color color)
    {
        Raylib.ClearBackground(color);
    }

    /// <inheritdoc cref="Raylib.BeginDrawing" />
    public static void BeginDrawing()
    {
        Raylib.BeginDrawing();
    }

    /// <inheritdoc cref="Raylib.EndDrawing" />
    public static void EndDrawing()
    {
        Raylib.EndDrawing();
    }

    /// <inheritdoc cref="Raylib.BeginMode2D" />
    public static void BeginMode2D(rlCamera2D camera)
    {
        Raylib.BeginMode2D(camera);
    }

    /// <inheritdoc cref="Raylib.EndMode2D" />
    public static void EndMode2D()
    {
        Raylib.EndMode2D();
    }

    /// <inheritdoc cref="Raylib.BeginMode3D" />
    public static void BeginMode3D(Camera3D camera)
    {
        Raylib.BeginMode3D(camera);
    }

    /// <inheritdoc cref="Raylib.EndMode3D" />
    public static void EndMode3D()
    {
        Raylib.EndMode3D();
    }

    /// <inheritdoc cref="Raylib.BeginTextureMode" />
    public static void BeginTextureMode(rlRenderTexture target)
    {
        Raylib.BeginTextureMode(target);
    }

    /// <inheritdoc cref="Raylib.EndTextureMode" />
    public static void EndTextureMode()
    {
        Raylib.EndTextureMode();
    }

    /// <inheritdoc cref="Raylib.BeginShaderMode" />
    public static void BeginShaderMode(rlShader shader)
    {
        Raylib.BeginShaderMode(shader);
    }

    /// <inheritdoc cref="Raylib.EndShaderMode" />
    public static void EndShaderMode()
    {
        Raylib.EndShaderMode();
    }

    /// <inheritdoc cref="Raylib.BeginBlendMode" />
    public static void BeginBlendMode(BlendMode mode)
    {
        Raylib.BeginBlendMode(mode);
    }

    /// <inheritdoc cref="Raylib.EndBlendMode" />
    public static void EndBlendMode()
    {
        Raylib.EndBlendMode();
    }

    /// <inheritdoc cref="Raylib.BeginScissorMode" />
    public static void BeginScissorMode(int x, int y, int width, int height)
    {
        Raylib.BeginScissorMode(x, y, width, height);
    }

    /// <inheritdoc cref="Raylib.EndScissorMode" />
    public static void EndScissorMode()
    {
        Raylib.EndScissorMode();
    }

    /// <inheritdoc cref="Raylib.BeginVrStereoMode" />
    public static void BeginVrStereoMode(VrStereoConfig config)
    {
        Raylib.BeginVrStereoMode(config);
    }

    /// <inheritdoc cref="Raylib.EndVrStereoMode" />
    public static void EndVrStereoMode()
    {
        Raylib.EndVrStereoMode();
    }

    /// <inheritdoc cref="Raylib.SwapScreenBuffer" />
    public static void SwapScreenBuffer()
    {
        Raylib.SwapScreenBuffer();
    }

    /// <inheritdoc cref="Raylib.DrawFPS" />
    public static void DrawFPS(int posX, int posY)
    {
        Raylib.DrawFPS(posX, posY);
    }

    /// <inheritdoc cref="Raylib.DrawText" />
    public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        Raylib.DrawText(text, posX, posY, fontSize, color);
    }

    /// <inheritdoc cref="Raylib.DrawTextEx" />
    public static void DrawTextEx(rlFont font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextEx(font, text, position, fontSize, spacing, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextPro" />
    public static void DrawTextPro(rlFont font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextPro(font, text, position, origin, rotation, fontSize, spacing, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextCodepoint" />
    public static void DrawTextCodepoint(rlFont font, int codepoint, Vector2 position, float fontSize, Color tint)
    {
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextCodepoints" />
    public static unsafe void DrawTextCodepoints(rlFont font, ReadOnlySpan<int> codepoints, Vector2 position, float fontSize, float spacing, Color tint)
    {
        fixed (int* codepointsPtr = codepoints)
        {
            Raylib.DrawTextCodepoints(font, codepointsPtr, codepoints.Length, position, fontSize, spacing, tint);
        }
    }

    /// <inheritdoc cref="Raylib.DrawMesh" />
    public static void DrawMesh(Mesh mesh, Material material, Matrix4x4 transform)
    {
        Raylib.DrawMesh(mesh, material, transform);
    }

    /// <inheritdoc cref="Raylib.DrawMeshInstanced" />
    public static unsafe void DrawMeshInstanced(Mesh mesh, Material material, Span<Matrix4x4> transforms)
    {
        fixed (Matrix4x4* transformsPtr = transforms)
        {
            Raylib.DrawMeshInstanced(mesh, material, transformsPtr, transforms.Length);
        }
    }

    /// <inheritdoc cref="Raylib.DrawLine3D" />
    public static void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color)
    {
        Raylib.DrawLine3D(startPos, endPos, color);
    }

    /// <inheritdoc cref="Raylib.DrawPoint3D" />
    public static void DrawPoint3D(Vector3 position, Color color)
    {
        Raylib.DrawPoint3D(position, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircle3D" />
    public static void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color)
    {
        Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
    }

    /// <inheritdoc cref="Raylib.DrawTriangle3D" />
    public static void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color)
    {
        Raylib.DrawTriangle3D(v1, v2, v3, color);
    }

    /// <inheritdoc cref="Raylib.DrawTriangleStrip3D" />
    public static unsafe void DrawTriangleStrip3D(Span<Vector3> points, Color color)
    {
        fixed (Vector3* pointsPtr = points)
        {
            Raylib.DrawTriangleStrip3D(pointsPtr, points.Length, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawCube" />
    public static void DrawCube(Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCube(position, width, height, length, color);
    }

    /// <inheritdoc cref="Raylib.DrawCubeV" />
    public static void DrawCubeV(Vector3 position, Vector3 size, Color color)
    {
        Raylib.DrawCubeV(position, size, color);
    }

    /// <inheritdoc cref="Raylib.DrawCubeWires" />
    public static void DrawCubeWires(Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCubeWires(position, width, height, length, color);
    }

    /// <inheritdoc cref="Raylib.DrawCubeWiresV" />
    public static void DrawCubeWiresV(Vector3 position, Vector3 size, Color color)
    {
        Raylib.DrawCubeWiresV(position, size, color);
    }

    /// <inheritdoc cref="Raylib.DrawSphere" />
    public static void DrawSphere(Vector3 centerPos, float radius, Color color)
    {
        Raylib.DrawSphere(centerPos, radius, color);
    }

    /// <inheritdoc cref="Raylib.DrawSphereEx" />
    public static void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        Raylib.DrawSphereEx(centerPos, radius, rings, slices, color);
    }

    /// <inheritdoc cref="Raylib.DrawCylinder" />
    public static void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <inheritdoc cref="Raylib.DrawCylinderEx" />
    public static void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        Raylib.DrawCylinderEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <inheritdoc cref="Raylib.DrawCylinderWires" />
    public static void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <inheritdoc cref="Raylib.DrawCylinderWiresEx" />
    public static void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        Raylib.DrawCylinderWiresEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <inheritdoc cref="Raylib.DrawCapsule" />
    public static void DrawCapsule(Vector3 startPos, Vector3 endPos, float radius, int slices, int rings, Color color)
    {
        Raylib.DrawCapsule(startPos, endPos, radius, slices, rings, color);
    }

    /// <inheritdoc cref="Raylib.DrawCapsuleWires" />
    public static void DrawCapsuleWires(Vector3 startPos, Vector3 endPos, float radius, int slices, int rings, Color color)
    {
        Raylib.DrawCapsuleWires(startPos, endPos, radius, slices, rings, color);
    }

    /// <inheritdoc cref="Raylib.DrawPlane" />
    public static void DrawPlane(Vector3 centerPos, Vector2 size, Color color)
    {
        Raylib.DrawPlane(centerPos, size, color);
    }

    /// <inheritdoc cref="Raylib.DrawRay" />
    public static void DrawRay(Ray ray, Color color)
    {
        Raylib.DrawRay(ray, color);
    }

    /// <inheritdoc cref="Raylib.DrawGrid" />
    public static void DrawGrid(int slices, float spacing)
    {
        Raylib.DrawGrid(slices, spacing);
    }

    /// <inheritdoc cref="Raylib.DrawModel" />
    public static void DrawModel(Model model, Vector3 position, float scale, Color tint)
    {
        Raylib.DrawModel(model, position, scale, tint);
    }

    /// <inheritdoc cref="Raylib.DrawModelEx" />
    public static void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <inheritdoc cref="Raylib.DrawModelWires" />
    public static void DrawModelWires(Model model, Vector3 position, float scale, Color tint)
    {
        Raylib.DrawModelWires(model, position, scale, tint);
    }

    /// <inheritdoc cref="Raylib.DrawModelWiresEx" />
    public static void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <inheritdoc cref="Raylib.DrawBoundingBox" />
    public static void DrawBoundingBox(BoundingBox box, Color color)
    {
        Raylib.DrawBoundingBox(box, color);
    }

    /// <inheritdoc cref="Raylib.DrawBillboard" />
    public static void DrawBillboard(Camera3D camera, rlTexture texture, Vector3 position, float size, Color tint)
    {
        Raylib.DrawBillboard(camera, texture, position, size, tint);
    }

    /// <inheritdoc cref="Raylib.DrawBillboardRec" />
    public static void DrawBillboardRec(Camera3D camera, rlTexture texture, Rectangle source, Vector3 position, Vector2 size, Color tint)
    {
        Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
    }

    /// <inheritdoc cref="Raylib.DrawBillboardPro" />
    public static void DrawBillboardPro(Camera3D camera, rlTexture texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
    }

    /// <inheritdoc cref="Raylib.DrawPixel" />
    public static void DrawPixel(int posX, int posY, Color color)
    {
        Raylib.DrawPixel(posX, posY, color);
    }

    /// <inheritdoc cref="Raylib.DrawPixelV" />
    public static void DrawPixelV(Vector2 position, Color color)
    {
        Raylib.DrawPixelV(position, color);
    }

    /// <inheritdoc cref="Raylib.DrawLine" />
    public static void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        Raylib.DrawLine(startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <inheritdoc cref="Raylib.DrawLineV" />
    public static void DrawLineV(Vector2 startPos, Vector2 endPos, Color color)
    {
        Raylib.DrawLineV(startPos, endPos, color);
    }

    /// <inheritdoc cref="Raylib.DrawLineEx" />
    public static void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineEx(startPos, endPos, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawLineStrip" />
    public static unsafe void DrawLineStrip(Span<Vector2> points, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawLineStrip(pointsPtr, points.Length, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawLineBezier" />
    public static void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineBezier(startPos, endPos, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircle" />
    public static void DrawCircle(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircle(centerX, centerY, radius, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircleSector" />
    public static void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircleSectorLines" />
    public static void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircleGradient" />
    public static void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2)
    {
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
    }

    /// <inheritdoc cref="Raylib.DrawCircleV" />
    public static void DrawCircleV(Vector2 center, float radius, Color color)
    {
        Raylib.DrawCircleV(center, radius, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircleLines" />
    public static void DrawCircleLines(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircleLines(centerX, centerY, radius, color);
    }

    /// <inheritdoc cref="Raylib.DrawCircleLinesV" />
    public static void DrawCircleLinesV(Vector2 center, float radius, Color color)
    {
        Raylib.DrawCircleLinesV(center, radius, color);
    }

    /// <inheritdoc cref="Raylib.DrawEllipse" />
    public static void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, color);
    }

    /// <inheritdoc cref="Raylib.DrawEllipseLines" />
    public static void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, color);
    }

    /// <inheritdoc cref="Raylib.DrawRing" />
    public static void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawRingLines" />
    public static void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangle" />
    public static void DrawRectangle(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangle(posX, posY, width, height, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleV" />
    public static void DrawRectangleV(Vector2 position, Vector2 size, Color color)
    {
        Raylib.DrawRectangleV(position, size, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleRec" />
    public static void DrawRectangleRec(Rectangle rec, Color color)
    {
        Raylib.DrawRectangleRec(rec, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectanglePro" />
    public static void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color)
    {
        Raylib.DrawRectanglePro(rec, origin, rotation, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleGradientV" />
    public static void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientV(posX, posY, width, height, color1, color2);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleGradientH" />
    public static void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientH(posX, posY, width, height, color1, color2);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleGradientEx" />
    public static void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4)
    {
        Raylib.DrawRectangleGradientEx(rec, col1, col2, col3, col4);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleLines" />
    public static void DrawRectangleLines(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangleLines(posX, posY, width, height, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleLinesEx" />
    public static void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color)
    {
        Raylib.DrawRectangleLinesEx(rec, lineThick, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleRounded" />
    public static void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color)
    {
        Raylib.DrawRectangleRounded(rec, roundness, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleRoundedLines" />
    public static void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, Color color)
    {
        Raylib.DrawRectangleRoundedLines(rec, roundness, segments, color);
    }

    /// <inheritdoc cref="Raylib.DrawRectangleRoundedLinesEx" />
    public static void DrawRectangleRoundedLinesEx(Rectangle rec, float roundness, int segments, float lineThick, Color color)
    {
        Raylib.DrawRectangleRoundedLinesEx(rec, roundness, segments, lineThick, color);
    }

    /// <inheritdoc cref="Raylib.DrawTriangle" />
    public static void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangle(v1, v2, v3, color);
    }

    /// <inheritdoc cref="Raylib.DrawTriangleLines" />
    public static void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    }

    /// <inheritdoc cref="Raylib.DrawTriangleFan" />
    public static unsafe void DrawTriangleFan(Span<Vector2> points, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawTriangleFan(pointsPtr, points.Length, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawTriangleStrip" />
    public static unsafe void DrawTriangleStrip(Span<Vector2> points, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawTriangleStrip(pointsPtr, points.Length, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawPoly" />
    public static void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    }

    /// <inheritdoc cref="Raylib.DrawPolyLines" />
    public static void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    }

    /// <inheritdoc cref="Raylib.DrawPolyLinesEx" />
    public static void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color)
    {
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, lineThick, color);
    }

    /// <inheritdoc cref="Raylib.DrawSplineLinear" />
    public static unsafe void DrawSplineLinear(Span<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawSplineLinear(pointsPtr, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawSplineBasis" />
    public static unsafe void DrawSplineBasis(Span<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawSplineBasis(pointsPtr, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawSplineCatmullRom" />
    public static unsafe void DrawSplineCatmullRom(Span<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawSplineCatmullRom(pointsPtr, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawSplineBezierQuadratic" />
    public static unsafe void DrawSplineBezierQuadratic(Span<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawSplineBezierQuadratic(pointsPtr, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawSplineBezierCubic" />
    public static unsafe void DrawSplineBezierCubic(Span<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pointsPtr = points)
        {
            Raylib.DrawSplineBezierCubic(pointsPtr, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="Raylib.DrawSplineSegmentLinear" />
    public static void DrawSplineSegmentLinear(Vector2 p1, Vector2 p2, float thick, Color color)
    {
        Raylib.DrawSplineSegmentLinear(p1, p2, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawSplineSegmentBasis" />
    public static void DrawSplineSegmentBasis(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float thick, Color color)
    {
        Raylib.DrawSplineSegmentBasis(p1, p2, p3, p4, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawSplineSegmentCatmullRom" />
    public static void DrawSplineSegmentCatmullRom(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float thick, Color color)
    {
        Raylib.DrawSplineSegmentCatmullRom(p1, p2, p3, p4, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawSplineSegmentBezierQuadratic" />
    public static void DrawSplineSegmentBezierQuadratic(Vector2 p1, Vector2 c2, Vector2 p3, float thick, Color color)
    {
        Raylib.DrawSplineSegmentBezierQuadratic(p1, c2, p3, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawSplineSegmentBezierCubic" />
    public static void DrawSplineSegmentBezierCubic(Vector2 p1, Vector2 c2, Vector2 c3, Vector2 p4, float thick, Color color)
    {
        Raylib.DrawSplineSegmentBezierCubic(p1, c2, c3, p4, thick, color);
    }

    /// <inheritdoc cref="Raylib.DrawTexture" />
    public static void DrawTexture(rlTexture texture, int posX, int posY, Color tint)
    {
        Raylib.DrawTexture(texture, posX, posY, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextureV" />
    public static void DrawTextureV(rlTexture texture, Vector2 position, Color tint)
    {
        Raylib.DrawTextureV(texture, position, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextureEx" />
    public static void DrawTextureEx(rlTexture texture, Vector2 position, float rotation, float scale, Color tint)
    {
        Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextureRec" />
    public static void DrawTextureRec(rlTexture texture, Rectangle source, Vector2 position, Color tint)
    {
        Raylib.DrawTextureRec(texture, source, position, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTexturePro" />
    public static void DrawTexturePro(rlTexture texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
    }

    /// <inheritdoc cref="Raylib.DrawTextureNPatch" />
    public static void DrawTextureNPatch(rlTexture texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
    }
}
