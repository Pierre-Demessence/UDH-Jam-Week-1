using System;
using System.Linq;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private readonly Collider2D[] _availableTargets = new Collider2D[10];
    [SerializeField] private float _homingRadius = 3;
    [SerializeField] private float _rotationSpeed = 3;
    private GameObject _target;
    [SerializeField] private LayerMask _targetLayer;

    private void FindTarget()
    {
        _target = null;
        Array.Clear(_availableTargets, 0, 10);
        var colliders = Physics2D.OverlapCircleNonAlloc(transform.position, _homingRadius, _availableTargets, _targetLayer);
        if (colliders <= 0) return;

        var nonNullAvailableTargets = _availableTargets.ToList().FindAll(c => c);
        _target = nonNullAvailableTargets.First().gameObject;

        foreach (var availableTarget in nonNullAvailableTargets)
            if (Vector2.Distance(transform.position, availableTarget.transform.position) < Vector2.Distance(transform.position, _target.transform.position))
                _target = availableTarget.gameObject;
    }

    private void RotateTowardTarget()
    {
        if (_target == null) return;
        var vectorToTarget = _target.transform.position - transform.position;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
    }

    private void Update()
    {
        FindTarget();
        RotateTowardTarget();
    }
}