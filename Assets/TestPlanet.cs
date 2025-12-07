using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlanet : MonoBehaviour
{
    [SerializeField] int Workers = 0;
    void OnTriggerEnter (Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.tag == "food") 
        { 
            other.gameObject.SetActive(false); 
            Workers++;
        }
       
    }
}
