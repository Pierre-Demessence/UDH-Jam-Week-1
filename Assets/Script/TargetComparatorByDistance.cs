using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TargetComparatorByDistance : TargetComparator
{
    [SerializeField] private bool _reverse;
    public override GameObject Find(IReadOnlyCollection<GameObject> targets)
    {
        if (targets.Count == 0) return null;
        
        var target = targets.First();
        foreach (var availableTarget in targets.Skip(1))
            if (!_reverse && Vector2.Distance(transform.position, availableTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                target = availableTarget;
            else if (_reverse && Vector2.Distance(transform.position, availableTarget.transform.position) > Vector2.Distance(transform.position, target.transform.position))
                target = availableTarget;

        return target;
    }
}