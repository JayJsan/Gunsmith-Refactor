using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public enum Type {
        DAMAGE,
        ATTACK_SPEED,
        RANGE,
        RELOAD_TIME,
        SPEED,
        SPREAD_ANGLE,
        MAX_AMMO,
        NUMBER_OF_BULLETS,
        PIERCING,
        FLAT_SIZE
    }
    public event EventHandler OnFinalStatsChanged;

    #region Gun Stat Variables

    private Dictionary<Type, float> stats = new Dictionary<Type, float>();

    [Header("Gun Stats")]
    public float baseDamage = 0f;
    private float totalDamagePercetange;
    private float finalDamage;

    // fire rate is attacks per second e.g. 1f = 1 attack per second 
    // 2f = 2 attacks per second 
    // 0.5 = 1 attack every 2 seconds
    public float baseAttackSpeed = 0f;
    private float totalAttackSpeedPercentage;
    private float finalAttackSpeed;

    // bullet speed
    public float baseBulletForce = 0f;
    private float totalBulletForcePercentage;
    private float finalBulletForce;
    #endregion

    /// <summary>
    /// Changes the value of a stat by a given amount. Specifically used for the core components of the gun that FLATLY changes the stat.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="type"></param>

    public void Start()
    {
        CalculateFinalStats();
    }

    #region long ass stats functions
    public void ModifyBaseDamageStat(float flatAmount, Type type) {
        switch (type) {
            case Type.DAMAGE:
                baseDamage += flatAmount;
                break;
            case Type.ATTACK_SPEED:
                baseAttackSpeed += flatAmount;
                break;
            case Type.SPEED:
                baseBulletForce += flatAmount;
                break;
            case Type.RANGE:
                break;
            case Type.RELOAD_TIME:
                break;
            case Type.SPREAD_ANGLE:
                break;
            case Type.MAX_AMMO:
                break;
            case Type.NUMBER_OF_BULLETS:
                break;
            case Type.PIERCING:
                break;
            case Type.FLAT_SIZE:
                break;
            default:
                break;
        }
        CalculateFinalStats();
    }

    public void ModifyEffectiveStat(float percentage, Type type) {
        switch (type) {
            case Type.DAMAGE:
                totalDamagePercetange += percentage;
                break;
            case Type.ATTACK_SPEED:
                totalAttackSpeedPercentage += percentage;
                break;
            case Type.SPEED:
                totalBulletForcePercentage += percentage;
                break;
            case Type.RANGE:
                break;
            case Type.RELOAD_TIME:
                break;
            case Type.SPREAD_ANGLE:
                break;
            case Type.MAX_AMMO:
                break;
            case Type.NUMBER_OF_BULLETS:
                break;
            case Type.PIERCING:
                break;
            case Type.FLAT_SIZE:
                break;
            default:
                break;
        }
        CalculateFinalStats();
    }

    public float GetBaseStat(Type type) {
        switch (type) {
            case Type.DAMAGE:
                CDL.Log<Stats>("Base Damage: " + baseDamage);
                return baseDamage;
            case Type.ATTACK_SPEED:
                CDL.Log<Stats>("Base Attack Speed: " + baseAttackSpeed);
                return baseAttackSpeed;
            case Type.SPEED:
                CDL.Log<Stats>("Base Bullet Force: " + baseBulletForce);
                return baseBulletForce;
            // case Type.RANGE:
            //     break;
            // case Type.RELOAD_TIME:
            //     break;
            // case Type.SPREAD_ANGLE:
            //     break;
            // case Type.MAX_AMMO:
            //     break;
            // case Type.NUMBER_OF_BULLETS:
            //     break;
            // case Type.PIERCING:
            //     break;
            // case Type.FLAT_SIZE:
            //     break;
            default:
                return -1;
        }
    }

    public float GetPercentageStat(Type type)
    {
        switch (type)
        {
            case Type.DAMAGE:
                CDL.Log<Stats>("Percentage Damage: " + totalDamagePercetange);
                return totalDamagePercetange;
            case Type.ATTACK_SPEED:
                CDL.Log<Stats>("Percentage Attack Speed: " + totalAttackSpeedPercentage);
                return totalAttackSpeedPercentage;
            case Type.SPEED:
                CDL.Log<Stats>("Percentage Bullet Force: " + totalBulletForcePercentage);
                return totalBulletForcePercentage;
            // case Type.RANGE:
            //     break;
            // case Type.RELOAD_TIME:
            //     break;
            // case Type.SPREAD_ANGLE:
            //     break;
            // case Type.MAX_AMMO:
            //     break;
            // case Type.NUMBER_OF_BULLETS:
            //     break;
            // case Type.PIERCING:
            //     break;
            // case Type.FLAT_SIZE:
            //     break;
            default:
                return -1;
        }
    }

    #endregion

    public float GetFinalStat(Type type, bool log = false) 
    {
        if (log)
            CDL.Log<Stats>("Final " + type.ToString() + ": " + stats[type]);
        return stats[type];
    }


    private void CalculateFinalStats() {

        finalDamage = baseDamage * (1 + totalDamagePercetange);
        finalAttackSpeed = baseAttackSpeed * (1 + totalAttackSpeedPercentage);
        finalBulletForce = baseBulletForce * (1 + totalBulletForcePercentage);

        AddFinalStatsToDictionary();
    }

    private void AddFinalStatsToDictionary() {
        // clear dictionary
        stats.Clear();

        stats.Add(Type.DAMAGE, finalDamage);
        stats.Add(Type.ATTACK_SPEED, finalAttackSpeed);
        stats.Add(Type.SPEED, finalBulletForce);

        // After adding stats to dictionary, send event to any subscribed listeners to update their stats
        CDL.Log<Stats>("Sending event to update stats.");
        OnFinalStatsChanged?.Invoke(this, EventArgs.Empty);
    }
}
