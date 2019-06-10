using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class FindTarget : MonoBehaviour
{
    private readonly Collider2D[] _availableTargets = new Collider2D[10];
    [SerializeField] private float _homingRadius = 3;
    [SerializeField] private bool _keepLookingForTargets = true;
    [SerializeField] private NewTargetAcquired _onNewTargetAcquired;
    private GameObject _target;
    [SerializeField] private LayerMask _targetLayer;

    private GameObject Target
    {
        set
        {
            if (_target == value) return;
            _target = value;
            _onNewTargetAcquired.Invoke(value);
            if (!_keepLookingForTargets) enabled = false;
        }
    }

    private List<GameObject> FindTargets()
    {
        Array.Clear(_availableTargets, 0, 10);
        Physics2D.OverlapCircleNonAlloc(transform.position, _homingRadius, _availableTargets, _targetLayer);
        return _availableTargets.ToList().FindAll(c => c).ConvertAll(input => input.gameObject);
    }

    private GameObject FindBestTarget(IReadOnlyCollection<GameObject> targets)
    {
        if (targets.Count == 0) return null;
        
        var target = targets.First();
        foreach (var availableTarget in targets.Skip(1))
            if (Vector2.Distance(transform.position, availableTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                target = availableTarget;

        return target;
    }

    private void Update()
    {
        Target = FindBestTarget(FindTargets());
    }
}

[Serializable]
internal class NewTargetAcquired : UnityEvent<GameObject>
{
}