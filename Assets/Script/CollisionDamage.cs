﻿using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health;
        if ((health = other.gameObject.GetComponent<Health>()) != null)
            health.TakeDamage(_damage);
    }
}