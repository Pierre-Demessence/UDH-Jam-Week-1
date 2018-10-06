using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _rateOfFire = 1;
    private float _lastHitTime;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && ((Time.time - _lastHitTime) > _rateOfFire))
        {
            Instantiate(_bullet, transform);
            _lastHitTime = Time.time;
        }
    }
}