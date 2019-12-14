using UnityEngine;

/// <summary>
/// Set up a GameObject prefab that contains a Rigidbody component before attaching this component.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class TestBullet : MonoBehaviour
{
  private Rigidbody _rigidbody => GetComponent<Rigidbody>();
  [SerializeField] private float _speed = 50;
  [SerializeField] private float _lifetime = 3;
  private float _refreshTime;
  public bool HasExpired => Time.time >= _refreshTime;

#region MonoBehaviour Methods
  private void OnEnable()
  {
    // Set the prefab's transform to be that of the spawnpoint's transform
    // Track refreshtime
    SetTransform(TestBulletPool.Instance.Spawnpoint);
    _refreshTime = Time.time + _lifetime;
  }

  private void Update()
  {
    // Travel in the forward position of the spawnpoint
    // Hide gameObject when refreshtime has been reached
    _rigidbody.velocity = transform.forward * _speed;

    if (HasExpired) gameObject.SetActive(false);
  }

  private void OnDisable()
  {
    // Return to the object pool
    TestBulletPool.Instance.ReturnObjectToPool(this);
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