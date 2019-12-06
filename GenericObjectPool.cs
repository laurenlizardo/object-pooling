using UnityEngine;
using System.Collections;

public abstract class GenericObjectPool<T> : Monobehaviour where T : Component
{
  [SerializeField] private protected T _prefab;
  [SerializeField] private protected int _poolCount;
  private Queue<T> _objectPool = new Queue<T>();

#region Object Pooling Methods
  protected void FillPool(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var obj = Instantiate(_prefab);
      HideObject(obj);
      _objectPool.Enqueue(obj);
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

  private void HideObject(T obj)
  {
    obj.SetActive(false);
  }

  private void ShowObject(T obj)
  {
    obj.SetActive(true);
  }
#endregion
}