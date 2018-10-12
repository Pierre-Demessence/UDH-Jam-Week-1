using UnityEngine;

public class Scorable : MonoBehaviour
{
    [SerializeField] private int _points;

    private void OnDestroy()
    {
        FindObjectOfType<GameCtrl>()?.AddPoints(_points);
    }
}