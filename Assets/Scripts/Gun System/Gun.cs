using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public enum State  
    {
        IDLE,
        FIRING,
        RELOADING
    }
    [Header("Configuration")]


    [Header("References")]
    public Transform firePoint;
    public Stats gunStats;
    public Transform hand;
    public GameObject owner;
    public ObjectPooler playerBulletPooler;

    // #### VARIABLES ####
    private Vector3 target;
    protected bool isExecuting = false;
    private bool isOnCooldown = false;

    void Start()
    {
        if (playerBulletPooler == null)
            CDL.LogError<Gun>("Object Pooler not found!");
    }

    void Update()
    {
        target = MouseChecker.instance.GetMousePosition();

        AimTowardsTarget();
        

        if (isExecuting)
        {
            Shoot();
        }

        FlipGun();
    }

    #region WEAPON MOVEMENT
    public void SetHand(Transform hand)
    {
        this.hand = hand;
    }
    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }
    private void AimTowardsTarget()
    {
        // rotate gun z axis until firepoint is looking at target
        Vector3 direction = target - firePoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void FlipGun()
    {
        // if target is to the left of the player
        if (target.x < owner.transform.position.x)
        {
            // keep original local scale but flip x
            // if its already negative it will flip it back to positive so we need to check
            if (transform.localScale.y > 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
        }
        else
        {
            // if its already positive it will flip it back to negative so we need to check
            if (transform.localScale.y < 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
        }
    }


    #endregion

    #region WEAPON EXECUTION

    public void Execute() 
    {
        isExecuting = true;
    }
    public void Stop()
    {
        isExecuting = false;
    }

    private void Shoot()
    {
        if (isOnCooldown)
            return;
        
        // shoot
        CDL.Log<Gun>("Shooting");
        
        GameObject bullet = playerBulletPooler.GetPooledObject();

        //bullet.transform.position = firePoint.position;

        //bullet.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);

        bullet.GetComponent<Bullet>().ActivateBullet(firePoint);

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(0.1f);
        isOnCooldown = false;
        //yield return new WaitForSeconds(gunStats.fireRate);
    }



    #endregion


}
