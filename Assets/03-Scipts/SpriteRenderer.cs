using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SpriteRenderer : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Villager Villager;   
    private void LateUpdate()
    {
        Vector3 cameraPosition = Camera.transform.position;
        //transform.LookAt(cameraPosition);
        Quaternion rotation = Quaternion.LookRotation(new Vector3(0f, Villager.FoodPlanet.transform.position.y, Villager.FoodPlanet.transform.position.z));
        //transform.Rotate(0f, Villager.FoodPlanet.transform.position.y, Villager.FoodPlanet.transform.position.z);
    }
}
