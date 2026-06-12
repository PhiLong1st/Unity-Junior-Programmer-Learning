using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.DesignPattern
{
  public abstract class Singleton<T> : MonoBehaviour where T : Component
  {
    static T _instance;

    public static T Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = FindFirstObjectByType<T>();
          if (_instance == null)
          {
            var obj = new GameObject(typeof(T).Name);
            _instance = obj.AddComponent<T>();
          }
        }

        return _instance;
      }
    }

    protected virtual void Awake()
    {
      if (_instance == null)
      {
        _instance = this as T;
      }
      else
      {
        Destroy(gameObject);
      }
    }
  }
}