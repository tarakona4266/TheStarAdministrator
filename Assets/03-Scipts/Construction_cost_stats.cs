using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction_cost_stats : MonoBehaviour
{
    [Header("House cost")]
    public int Hwood = 0;
    public int Hcristal = 0;
    public int Hworker = 0;
    [Header("Farm cost")]
    public int Fwood = 0;
    public int Fcristal = 0;
    public int Fworker = 0;
    [Header("Museum cost")]
    public int Mwood = 0;
    public int Mcristal = 0;
    public int Mworker = 0;
    public int Mhappiness = 0;
    [Header("School cost")]
    public int Swood = 0;
    public int Scristal = 0;
    public int Sworker = 0;
    [Header("Library cost")]
    public int Lwood = 0;
    public int Lcristal = 0;
    public int Lworker = 0;
    public int Lhappiness = 0;

    public bool VerifyCost(int wood, int cristal, int worker, string building)
    {
        int requiredWood;
        int requiredCristal;
        int requiredWorker;

        switch (building)
        {
            case "house":
                requiredWood = Hwood;
                requiredCristal = Hcristal;
                requiredWorker = Hworker;
                break;
            case "farm":
                requiredWood = Fwood;
                requiredCristal = Fcristal;
                requiredWorker = Fworker;
                break;
            case "school":
                requiredWood = Swood;
                requiredCristal = Scristal;
                requiredWorker = Sworker;
                break;
            case "library":
                requiredWood = Lwood;
                requiredCristal = Lcristal;
                requiredWorker = Lworker;
                break;
            case "museum":
                requiredWood = Mwood;
                requiredCristal = Mcristal;
                requiredWorker = Mworker;
                break;
            default:
                print("no match found");
                return false;
        }

        if (requiredWood <= wood && requiredCristal <= cristal && requiredWorker <= worker)
        {
            return true;
        }
        else { return false; }
    }
}
