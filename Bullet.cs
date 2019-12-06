using UnityEngine;

/// <summary>
/// Set up a GameObject prefab that contains a Rigidbody component before attaching this component.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
  private Rigidbody _rigidbody => GetComponent<Rigidbody>();
  [SerializeField] private float _speed;
  [SerializeField] private float _lifetime;
  private float _refreshTime;
  public bool HasExpired => Time.time >= _refreshTime;

#region MonoBehaviour Methods
  private void OnEnable()
  {
    // Set the prefab's transform to be that of the spawnpoint's transform
    // Track lapsedtime
    SetTransform(BulletPool.Instance.Spawnpoint);
    _refreshTime = Time.time + _lifetime;
  }

  private void Update()
  {
    // Travel in the forward position of the spawnpoint
    _rigidbody.velocity = transform.forward * _speed;
  }

  private void OnDisable()
  {
    // Hide gameObject
    // Return to the object pool
    gameObject.SetActive(false);
    BulletPool.Instance.ReturnToPool(this);
  }
#endregion

#region Class Methods
  private void SetTransform(Transform spawnpoint)
  {
    transform.position = spawnpoint.position;
    transform.rotation = spawnpoint.rotation;
  }
#endregion
}