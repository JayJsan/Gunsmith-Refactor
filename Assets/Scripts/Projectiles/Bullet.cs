using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuration")]
    public float speed = 10f;
    public float damage = 10f;
    public float lifeTime = 5f;

    [Header("References")]
    public Rigidbody2D rb;
    public Collider2D col;
    public Transform bullet;
    public Stats stats;

    public void ActivateBullet(Transform position, Stats stats)
    {
        this.stats = stats;
        SetBulletStats();

        // reset velocity
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // set bullet position to firepoint position
        bullet.position = position.position;
        bullet.rotation = position.rotation;

        gameObject.SetActive(true);

        // apply force in direction of mouse
        rb.AddForce(position.right * speed, ForceMode2D.Impulse);


        // destroy bullet after lifetime
        StartCoroutine(DestroyBullet());
    }

    private void SetBulletStats()
    {
        damage = stats.stats[Stats.Type.DAMAGE];
        speed = stats.stats[Stats.Type.SPEED];
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
