using UnityEngine;
using UnityEngine.Events;

public class OnDestroyEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDestroy;

    private void OnDestroy() => _onDestroy.Invoke();
}