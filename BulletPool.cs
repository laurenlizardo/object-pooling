using UnityEngine;

/// <summary>
/// In the inspector, create an empty GameObject with this component attached to it.
/// Fill the necesarry fields for the prefab, pool count, and spawnpoint.
/// </summary>
public class BulletPool : GenericObjectPool<Bullet>
{
#region MonoBehaviour Methods
  private void Start()
  {
    FillPool(_poolCount);
  }
#endregion
}