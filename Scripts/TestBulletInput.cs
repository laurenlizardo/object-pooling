using UnityEngine;

public class TestBulletInput : MonoBehaviour
{
#region MonoBehaviour Methods
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      TestBulletPool.Instance.NextPoolObject().gameObject.SetActive(true);
    }
  }
#endregion
}