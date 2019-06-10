using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class FindTarget : MonoBehaviour
{
    [SerializeField] private bool _canFindBetterTarget = true;
    [SerializeField] private float _homingRadius = 3;
    [SerializeField] private NewTargetAcquired _onNewTargetAcquired;
    private GameObject _target;
    [SerializeField] private LayerMask _targetLayer;

    private GameObject Target
    {
        get => _target;
        set
        {
            if (_target == value)
                _onNewTargetAcquired.Invoke(value);
            _target = value;
        }
    }

    private void Update()
    {
        if (!_canFindBetterTarget && _target) return;

        var availableTargets = new Collider2D[10];
        var colliders = Physics2D.OverlapCircleNonAlloc(transform.position, _homingRadius, availableTargets, _targetLayer);
        if (colliders <= 0)
        {
            Target = null;
            return;
        }

        var nonNullAvailableTargets = availableTargets.ToList().FindAll(c => c);
        Target = nonNullAvailableTargets.First().gameObject;

        foreach (var availableTarget in nonNullAvailableTargets)
            if (Vector2.Distance(transform.position, availableTarget.transform.position) < Vector2.Distance(transform.position, Target.transform.position))
                Target = availableTarget.gameObject;
    }
}

[Serializable]
internal class NewTargetAcquired : UnityEvent<GameObject>
{
}