using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // 2/09/23 -- this is old code from years ago
    #region Gun Stat Variables
    // The reason there are three types of stats (default, current, and no prefix) is due to the way I change the stats in the inventory manager.
    // If I use only one variable to keep track of the stats, I cannot reset it properly?? god i need to do this way better
    //  -- I will refactor this one day but for now it works for now --
    //

    [Header("Gun Stats")]
    // Speed
    protected float defaultBulletForce = 0f;
    public float bulletForce = 0f;

    // Accuracy
    // Default is 0.5f:
    // 1f - 100% accurate
    // 0f - Bullet spread spans across a fixed angle.
    protected float defaultSpreadAngle = 0.5f;
    [Range(0f, 1f)]
    public float spreadAngle = 0.5f;
    protected float defaultAccuracyMultiplier = 0f; // (defaultMultiplier + 1) * spread angle = no change
    public float currentAccuracyMultiplier = 0f;
    // Damage
    // Self-explanatory
    protected int defaultDamage = 0;
    protected int currentDamage = 0;
    public int damage = 0;

    // Range
    // Bullet "range" but mechanicall is the bullet lifetime. Will probably change later on.
    protected float defaultRange = 1f;
    protected float currentRange = 0f;
    public float range = 0f;

    // Fire Rate
    // Default is 1: Being 1 bullet per second. fireRate is measured in time between seconds
    // Bullets per second is well bullets per second.
    protected float defaultFireRate = 1f;
    protected float defaultBulletsPerSecond = 1f;
    [Range(0f, 2f)]
    public float fireRate = 1f;
    public float currentBulletsPerSecond = 1f;

    // Ammo
    protected int defaultMaxAmmo = 0;
    public int maxAmmo = 0;
    public int currentAmmo = 0;

    // Reload Time
    // Default = 1f - Reloads in one second.
    protected float defaultReloadTime = 1f;
    public float reloadTime = 1f;

    // # of bullets shot per fire.
    protected int defaultNumberOfBullets = 1;
    public int numberOfBullets = 0;

    // Piercing - Allows the bullet to damage through an enemy and disappears after x amount of enemy collisions.
    public int piercingAmount = 0;
    protected int defaultPiercingAmount = 0;
    protected int currentPiercingAmount = 0;

    // Size - Changes the size of the bullet 
    public float size = 1f;
    protected float defaultSize = 1f;
    protected float currentSize = 1f;

    // Determines if weapon is semi-auto or automatic
    public bool isAuto = false;
    #endregion

    #region Stat Change Methods

    public void ResetStats()
    {
        this.bulletForce = defaultBulletForce;
        this.spreadAngle = defaultSpreadAngle;
        this.currentAccuracyMultiplier = defaultAccuracyMultiplier;
        this.damage = defaultDamage;
        this.currentDamage = defaultDamage;
        this.range = defaultRange;
        this.currentRange = defaultRange;
        this.fireRate = defaultFireRate;
        this.currentBulletsPerSecond = defaultBulletsPerSecond;
        this.maxAmmo = defaultMaxAmmo;
        this.reloadTime = defaultReloadTime;
        this.numberOfBullets = defaultNumberOfBullets;
        this.piercingAmount = defaultPiercingAmount;
        this.size = defaultSize;
        this.isAuto = false;
    }


    #endregion
}
