using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text UIText;
    [SerializeField] TMP_Text HappinessText;
    [SerializeField] Stats Stats;

    [SerializeField] DayNightCycle DayNightCycle;

    [SerializeField] Slider HappinessSlider;
    [SerializeField] Slider DaySlider;
    [SerializeField] Image DaySliderJauge;
    void Update()
    {
        UIText.text = ("Food : " + Stats.Food);
        UIText.text += ("\nWood : " + Stats.Wood);
        UIText.text += ("\nStone : " + Stats.Stone);

        if (Stats.House < Stats.Villagers) { UIText.text += ("\n\n" + "<color=red>" + "Houses : " + Stats.House + "</color>"); }
        else { UIText.text += ("\n\nHouses : " + Stats.House); }

        UIText.text += ("\nVillagers : " + Stats.Villagers);

        HappinessText.text = ("Happiness : " + Stats.Happiness);
        HappinessSlider.value = Stats.Happiness;

        if (DayNightCycle.IsDayActive)
        {
            DaySliderJauge.color = Color.yellow;
        }
        else
        {
            DaySliderJauge.color = Color.blue;
        }
        DaySlider.value = 60 * DayNightCycle.TimeMinute + DayNightCycle.TimeSecond;

    }
}
