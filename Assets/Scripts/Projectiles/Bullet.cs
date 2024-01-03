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


    public void ActivateBullet(Transform position)
    {
        gameObject.SetActive(true);
        // reset velocity
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;



        // apply force in direction of mouse
        rb.AddForce(position.right * speed, ForceMode2D.Impulse);

        bullet.position = position.position;
        bullet.rotation = position.rotation;


        // destroy bullet after lifetime
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
