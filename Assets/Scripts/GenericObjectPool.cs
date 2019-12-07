using UnityEngine;
using System.Collections.Generic;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
  [SerializeField] private protected T _prefab;
  [SerializeField] private protected int _poolCount;
  private Queue<T> _objectPool = new Queue<T>();
  public Transform Spawnpoint;

#region Singleton Implementation
  private static GenericObjectPool<T> _instance;
  public static GenericObjectPool<T> Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

#region Object Pooling Methods
  protected void FillPool(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var obj = Instantiate(_prefab);
      obj.gameObject.SetActive(false);
      ReturnToPool(obj);
    }
  }

  protected T NextPoolObject()
  {
    return _objectPool.Dequeue();
  }

  protected void ReturnToPool(T obj)
  {
    _objectPool.Enqueue(obj);
  }
#endregion
}