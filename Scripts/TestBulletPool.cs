using UnityEngine;

/// <summary>
/// In the Inspector, create an empty GameObject with this component attached to it.
/// Fill the necessary fields for the following variables: _prefab, _poolCount, Spawnpoint.
/// </summary>
public class TestBulletPool : GenericObjectPool<TestBullet>
{
#region MonoBehaviour Methods
  private void Start()
  {
    AddObjectsToPool(_poolCount);
    if (_isPoolParent) SetPoolParent(this.gameObject);
  }
#endregion
}