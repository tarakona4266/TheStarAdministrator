using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SpriteRenderer : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Villager Villager;   
    private void Update()
    {
        //Vector3 cameraPosition = Camera.transform.position;
        //transform.LookAt(cameraPosition);
        //transform.rotation = Quaternion.Euler(90f, (Villager.FoodPlanet.transform.position.x + Villager.FoodPlanet.transform.position.z) - (Villager.transform.position.x + Villager.transform.position.z), 0f);
        transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(Villager.FoodPlanet.transform.position.x - Villager.transform.position.x, Villager.FoodPlanet.transform.position.z - Villager.transform.position.z) * Mathf.Rad2Deg, 0f);
    }
}
