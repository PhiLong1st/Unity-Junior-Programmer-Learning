using System;
using System.Collections.Generic;

namespace Shared.Utils
{
  /// <summary>
  /// A generic object pool to manage and reuse objects, minimizing memory allocations and garbage collection.
  /// </summary>
  /// <typeparam name="T">The type of object to pool.</typeparam>
  public class ObjectPooling<T> where T : IPoolable
  {
    private Func<T> _factoryFunc;
    private List<T> pool;

    /// <summary>
    /// Initializes a new instance of the ObjectPooling class and pre-warms it with an initial set of objects.
    /// </summary>
    /// <param name="initialSize">The number of objects to instantiate immediately upon creation. Defaults to 10.</param>
    public ObjectPooling(Func<T> factoryFunc, int initialSize = 10)
    {
      pool = new(initialSize);
      _factoryFunc = factoryFunc;

      for (int i = 0; i < initialSize; i++)
      {
        T newObj = _factoryFunc();
        newObj.Release();
        pool.Add(newObj);
      }
    }

    /// <summary>
    /// Retrieves an unused object from the pool.
    /// If no active objects are found, a new one is created.
    /// </summary>
    /// <returns>An instance of type T ready for use.</returns>
    public T GetFromPool()
    {
      foreach (var obj in pool)
      {
        if (obj.IsInUse)
        {
          continue;
        }

        obj.Reset();
        return obj;
      }

      T newObj = _factoryFunc();
      pool.Add(newObj);

      return newObj;
    }

    /// <summary>
    /// Returns an object to the pool so it can be reused later.
    /// If the object is still active, it will be deactivated before being added back to the pool.
    /// </summary>
    /// <param name="obj">The object to return to the pool.</param>
    public void ReturnToPool(T obj)
    {
      if (obj.IsInUse) obj.Release();
      pool.Add(obj);
    }
  }
}