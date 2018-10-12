using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 10;
    [SerializeField] private float _invulnerabilityTime;
    private float _lastDamageTime;
    [SerializeField] private TakeDamageEvent _onTakeDamage;

    public float Value => _health;

    public void TakeDamage(float amount)
    {
        if (Time.time - _lastDamageTime <= _invulnerabilityTime) return;

        _health -= amount;
        if (_health <= 0) Destroy(gameObject);
        _onTakeDamage.Invoke(_health);
        _lastDamageTime = Time.time;
    }

    public void Heal(float amount)
    {
        _health += amount;
    }
}

[Serializable]
internal class TakeDamageEvent : UnityEvent<float>
{
}