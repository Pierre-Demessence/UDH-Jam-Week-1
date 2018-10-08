using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScoller : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.size += new Vector2(_speed, 0);
    }
}