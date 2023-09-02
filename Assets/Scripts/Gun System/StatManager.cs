using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }
    private Stats stats;
    private void Awake() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void AddStats(PartItemData itemData) {
        stats.ChangeDamage(itemData.damage);
        stats.ChangeFireRate(itemData.fireRateMultiplier);
        stats.ChangeRange(itemData.range);
        stats.ChangeReloadTime(itemData.reloadTime);
        stats.ChangeSpeed(itemData.bulletForce);
        stats.ChangeSpreadAngle(itemData.accuracyMultiplier);
        stats.ChangeMaxAmmo(itemData.maxAmmo);
        stats.ChangeNumberOfBullets(itemData.numberOfBullets);
        stats.ChangePiercing(itemData.piercingAmount);
        stats.ChangeFlatSize(itemData.sizeMultiplier);
    }

    public void RemoveStats(PartItemData itemData) {
        stats.ChangeDamage(-itemData.damage);
        stats.ChangeFireRate(-itemData.fireRateMultiplier);
        stats.ChangeRange(-itemData.range);
        stats.ChangeReloadTime(-itemData.reloadTime);
        stats.ChangeSpeed(-itemData.bulletForce);
        stats.ChangeSpreadAngle(-itemData.accuracyMultiplier);
        stats.ChangeMaxAmmo(-itemData.maxAmmo);
        stats.ChangeNumberOfBullets(-itemData.numberOfBullets);
        stats.ChangePiercing(-itemData.piercingAmount);
        stats.ChangeFlatSize(-itemData.sizeMultiplier);
    }
}
