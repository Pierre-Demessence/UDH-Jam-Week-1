using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    private float _lastHitTime;
    [SerializeField] private UnityEvent _onFire;
    [SerializeField] private float _rateOfFire = 1;
    [SerializeField] private bool _setAngle = true;

    protected abstract GameObject CurrentBullet { get; }

    public void Fire()
    {
        if (Time.time - _lastHitTime <= _rateOfFire) return;

        var bullet = Instantiate(CurrentBullet);
        _onFire.Invoke();
        bullet.transform.position = transform.position;
        bullet.layer = gameObject.layer;
        if (_setAngle) bullet.transform.rotation = transform.rotation;
        _lastHitTime = Time.time;
    }
}