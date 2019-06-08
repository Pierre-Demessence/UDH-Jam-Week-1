using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blink : MonoBehaviour
{
    [SerializeField] private float _animationDelay;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void ChangeAlpha(float alpha)
    {
        var c = _spriteRenderer.color;
        c.a = alpha;
        _spriteRenderer.color = c;
    }

    private IEnumerator BlinkCoroutine(float duration)
    {
        var endTime = Time.time + duration;

        do
        {
            ChangeAlpha(1 - Mathf.PingPong((endTime - Time.time) / _animationDelay, 1));
            yield return new WaitForEndOfFrame();
        } while (Time.time <= endTime);

        ChangeAlpha(1);
    }

    public void DoBlink(float duration)
    {
        StartCoroutine(BlinkCoroutine(duration));
    }
}