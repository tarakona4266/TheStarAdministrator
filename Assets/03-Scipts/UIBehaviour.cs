using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Stats Stats;
    void Update()
    {
        text.text = ("Food : " + Stats.Food);
        text.text += ("\nWood : " + Stats.Wood);
        text.text += ("\nStone : " + Stats.Stone);

        if (Stats.House < Stats.Villagers) { text.text += ("\n\n" + "<color=red>" + "Houses : " + Stats.House + "</color>"); }
        else { text.text += ("\n\nHouses : " + Stats.House); }

        text.text += ("\nVillagers : " + Stats.Villagers);
    }

    [SerializeField] Slider Slider;
    void Sliderbehaviour(int value)
    {
        value = Stats.Happiness;
    }
}
