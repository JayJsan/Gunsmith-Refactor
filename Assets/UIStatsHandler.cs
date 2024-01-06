using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatsHandler : MonoBehaviour
{
    [Header("References")]
    public Stats stats;
    [Header("Base Text")]
    public TextMeshProUGUI baseDamageText;
    public TextMeshProUGUI baseSpeedText;
    public TextMeshProUGUI baseAttackSpeedText;
    [Header("Percentage Text")]
    public TextMeshProUGUI percentageDamageText;
    public TextMeshProUGUI percentageSpeedText;
    public TextMeshProUGUI percentageAttackSpeedText;
    [Header("Final Text")]
    public TextMeshProUGUI finalDamageText;
    public TextMeshProUGUI finalSpeedText;
    public TextMeshProUGUI finalAttackSpeedText;

    void Start()
    {
        if (stats == null)
        {
            CDL.LogError<UIStatsHandler>("Stats not found!");
        }
        stats.OnFinalStatsChanged += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(object sender, EventArgs e)
    {
        CDL.Log<UIStatsHandler>("Event Received! | Updating UI");
        UpdateBaseText();
        UpdatePercentageText();
        UpdateFinalText();
    }

    private void UpdateBaseText()
    {
        baseDamageText.text = "Base Damage: " + stats.GetBaseStat(Stats.Type.DAMAGE).ToString();
        baseSpeedText.text = "Base Speed: " + stats.GetBaseStat(Stats.Type.SPEED).ToString();
        baseAttackSpeedText.text = "Base Attack Speed: " + stats.GetBaseStat(Stats.Type.ATTACK_SPEED).ToString();
    }

    private void UpdatePercentageText()
    {
        percentageDamageText.text = "Damage Percentage: " + stats.GetPercentageStat(Stats.Type.DAMAGE).ToString();
        percentageSpeedText.text = "Speed Percentage: " + stats.GetPercentageStat(Stats.Type.SPEED).ToString();
        percentageAttackSpeedText.text = "Attack Speed Percentage: " + stats.GetPercentageStat(Stats.Type.ATTACK_SPEED).ToString();
    }

    private void UpdateFinalText()
    {
        finalDamageText.text = "Final Damage: " + stats.GetFinalStat(Stats.Type.DAMAGE, true);
        finalSpeedText.text = "Final Speed: " + stats.GetFinalStat(Stats.Type.SPEED, true);
        finalAttackSpeedText.text = "Final Attack Speed: " + stats.GetFinalStat(Stats.Type.ATTACK_SPEED, true);
    }
}
