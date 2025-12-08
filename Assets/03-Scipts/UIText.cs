using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Stats Stats;
    void Update()
    {
        text.text = ("Food : " + Stats.Food);
        text.text += ("\nWood : " + Stats.Wood);
        text.text += ("\nStone : " + Stats.Stone);
        text.text += ("\n\nHouses : " + Stats.House);
        text.text += ("\nVillagers : " + Stats.Villagers);
    }
}
