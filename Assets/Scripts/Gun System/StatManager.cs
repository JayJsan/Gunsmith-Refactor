using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }
    [SerializeField]
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
        if (stats == null)
        {
            CDL.LogError<StatManager>("Stats not found!");
        }
    }

    public void ModifyBaseDamageStat(float flatAmount, Stats.Type type) {
        stats.ModifyBaseDamageStat(flatAmount, type);
    }

    public void ModifyEffectiveStat(float flatAmount, Stats.Type type) {
        stats.ModifyEffectiveStat(flatAmount, type);
    }
}
