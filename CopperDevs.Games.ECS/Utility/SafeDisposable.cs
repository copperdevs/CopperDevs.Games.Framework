namespace CopperDevs.Games.ECS.Utility;

public abstract class SafeDisposable : IDisposable
{
    private bool hasDisposed = false;

    ~SafeDisposable()
    {
        Dispose(false);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool manual)
    {
        if(hasDisposed)
            return;
        
        hasDisposed = true;
        DisposeResources();
    }

    public abstract void DisposeResources();
}