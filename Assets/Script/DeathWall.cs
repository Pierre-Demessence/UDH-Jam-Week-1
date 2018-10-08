using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}