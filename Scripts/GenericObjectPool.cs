using UnityEngine;
using System.Collections.Generic;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
  [SerializeField] private protected T _prefab;
  [SerializeField] private protected int _poolCount;
  [SerializeField] private protected bool _isPoolParent;
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
  protected void AddObjectsToPool(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var obj = Instantiate(_prefab);
      obj.gameObject.SetActive(false);
      ReturnObjectToPool(obj);
    }
  }

  public T NextPoolObject()
  {
    return _objectPool.Dequeue();
  }

  public void ReturnObjectToPool(T obj)
  {
    _objectPool.Enqueue(obj);
  }
#endregion

  protected void SetPoolParent(GameObject parent)
  {
    foreach (T obj in _objectPool)
    {
      obj.transform.SetParent(parent.transform);
    }
  }

#region Other Methods
  public void SetSpawnTransform(T obj, Transform spawn)
  {
    obj.transform.position = spawn.position;
    obj.transform.rotation = spawn.rotation;
  }
#endregion
}