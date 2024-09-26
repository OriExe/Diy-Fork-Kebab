using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private Transform foodObject;
    private void OnMouseDown()
    {
        Instantiate(foodObject);
    }
}
