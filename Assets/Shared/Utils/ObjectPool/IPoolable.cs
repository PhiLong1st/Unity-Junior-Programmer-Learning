namespace Shared.Utils
{
  /// <summary>
  /// Defines the contract for an object that can be managed and reused by an object pool.
  /// </summary>
  public interface IPoolable
  {
    /// <summary>
    /// Deactivates the object, safely marking it as no longer in use.
    /// </summary>
    /// <returns>The deactivated instance of the object.</returns>
    void Release();

    /// <summary>
    /// Checks if the object is in use.
    /// </summary>
    /// <returns>True if the object is in use, false otherwise.</returns>
    bool IsInUse { get; }

    /// <summary>
    /// Resets the state of the object to its default values, making it ready for reuse.
    /// This method should be called before returning the object to the pool.
    /// </summary>
    void Reset();
  }
}