using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public static Transform[,] spawnLocations;

    /// <summary>
    /// Spawn locations arrays for each side of the fork that'll be set up in unity
    /// </summary>
    [SerializeField] private Transform LeftForkLocationsParent;
    [SerializeField] private Transform MiddleForkLocationsParent;
    [SerializeField] private Transform RightForkLocationsParent;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new Transform[3,RightForkLocationsParent.childCount];
        addArray(LeftForkLocationsParent.GetComponentsInChildren<Transform>(), 0);
        addArray(MiddleForkLocationsParent.GetComponentsInChildren<Transform>(), 1);
        addArray(RightForkLocationsParent.GetComponentsInChildren<Transform>(), 2);

        print("Hi");
    }

    void addArray(Transform[] array,int dimension)
    {
        for (int i = 1; i < array.Length; i++)
        {
            spawnLocations[dimension,i-1] = array[i];
        }
    }

    // Update is called once per frame

}
