using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindTargetsCircle : FindTargets
{
    [SerializeField] private float _homingRadius = 3;
    [SerializeField] private LayerMask _targetLayer;
    private readonly Collider2D[] _availableTargets = new Collider2D[10];
    public override List<GameObject> Find()
    {
        Array.Clear(_availableTargets, 0, 10);
        Physics2D.OverlapCircleNonAlloc(transform.position, _homingRadius, _availableTargets, _targetLayer);
        return _availableTargets.ToList().FindAll(c => c).ConvertAll(input => input.gameObject);
    }
}