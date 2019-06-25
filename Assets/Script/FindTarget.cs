using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class FindTarget : MonoBehaviour
{
    [SerializeField] private bool _keepLookingForTargets = true;
    [SerializeField] private NewTargetAcquired _onNewTargetAcquired;
    private GameObject _target;
    [SerializeField, InlineEditor] private FindTargets _findTargets;
    [SerializeField, InlineEditor]  private TargetComparator _targetComparator;

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

    private void Update()
    {
        Target = _targetComparator.Find(_findTargets.Find());
    }
}

[Serializable]
internal class NewTargetAcquired : UnityEvent<GameObject>
{
}