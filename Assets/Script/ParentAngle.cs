using UnityEngine;

public class ParentAngle : MonoBehaviour
{
    private void Awake()
    {
        transform.rotation = transform.parent.rotation;
    }
}