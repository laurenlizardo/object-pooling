using UnityEngine;

public class InputManager : MonoBehaviour
{
#region MonoBehaviour Methods
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      BulletPool.Instance.NextPoolObject().gameObject.SetActive(true);
    }
  }
#endregion
}