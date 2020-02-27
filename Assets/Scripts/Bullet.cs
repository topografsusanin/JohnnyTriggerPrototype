﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float startTime = 0f;
    private int damage;

    private void OnEnable()
    {
        startTime = Time.time + 2f;
    }

    private void OnDisable()
    {
        startTime = 0f;
    }

    private void Update()
    {
        if(Time.time > startTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.root.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.SetDamage(damage);
            var rigidbody = health.gameObject.GetComponent<Rigidbody>();
            rigidbody.freezeRotation = false;
            rigidbody.isKinematic = false;
            rigidbody.AddForce((transform.position - health.transform.position) * 5f, ForceMode.Impulse);
        }
    }
}