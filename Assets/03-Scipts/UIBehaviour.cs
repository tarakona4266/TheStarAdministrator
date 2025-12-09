using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text FoodText;
    [SerializeField] TMP_Text WoodText;
    [SerializeField] TMP_Text StoneText;
    [SerializeField] TMP_Text VillagerText;
    [SerializeField] TMP_Text HouseText;

    [SerializeField] Stats Stats;

    [SerializeField] DayNightCycle DayNightCycle;

    [SerializeField] Slider HappinessSlider;

    [SerializeField] Slider DaySlider;
    [SerializeField] Image DaySliderJauge;
    [SerializeField] Image Icon;

    [SerializeField] Sprite Sun;
    [SerializeField] Sprite Moon;

    void Update()
    {
        FoodText.text = Stats.Food.ToString();
        WoodText.text = Stats.Wood.ToString();
        StoneText.text = Stats.Stone.ToString();
        VillagerText.text = Stats.Villagers.ToString();

        if (Stats.House < Stats.Villagers) { HouseText.text += ("<color=red>" + Stats.House + "</color>"); }
        else { HouseText.text = Stats.House.ToString(); }

        if (DayNightCycle.IsDayActive)
        {
            DaySliderJauge.color = Color.yellow;
            Icon.sprite = Sun;
        }
        else
        {
            DaySliderJauge.color = Color.blue;
            Icon.sprite = Moon;
        }
        DaySlider.value = 60 * DayNightCycle.TimeMinute + DayNightCycle.TimeSecond;
        HappinessSlider.value = Stats.Happiness;
    }
}
