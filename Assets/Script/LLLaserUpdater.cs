using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LLLaserUpdater : MonoBehaviour
{
    public LineRenderer line;
    private Vector2 lineDefaultPoint;
    public Transform lineEndPoint;

    public ParticleSystem LLHitEffectLeft;
    public ParticleSystem LLHitEffectRight;

    public PlayerWeaponStats myStats = new PlayerWeaponStats();

    private void OnEnable()
    {
        line.enabled = true;

        //LLHitEffectLeft.Play();
        //LLHitEffectRight.Play();
        line.SetPosition(0, transform.position);

        var raycastHit = Physics2D.Raycast(transform.position, transform.right, myStats.weaponRange, 1 << 9);
        if (raycastHit)
            line.SetPosition(1, raycastHit.point);

        else
            line.SetPosition(1, lineEndPoint.position);
    }

    private void OnDisable()
    {
        line.enabled = false;
        //LLHitEffectLeft.Stop();
        //LLHitEffectRight.Stop();
    }

    private void Update()
    {
        line.SetPosition(0, transform.position);

        var raycastHit = Physics2D.Raycast(transform.position, transform.right, myStats.weaponRange, 1 << 9);
        if (raycastHit)
        {
            line.SetPosition(1, raycastHit.point);
            //LLHitEffectLeft.transform.position = raycastHit.point;
            //LLHitEffectRight.transform.position = raycastHit.point;
        }

        else
        {
            line.SetPosition(1, lineEndPoint.position);
            //LLHitEffectLeft.transform.position = lineEndPoint.position;
            //LLHitEffectRight.transform.position = lineEndPoint.position;
        }
    }

    [Serializable]
    public class PlayerWeaponStats
    {
        public float weaponRange = 10;
    }
}