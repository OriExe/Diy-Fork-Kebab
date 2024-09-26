using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkDisplay : MonoBehaviour
{
    /// <summary>
    /// Index in the 2D to access the spawns 
    /// </summary>
    [SerializeField] private int index;
    private int currentCount;
    [SerializeField] private Transform leftForkTransform;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food" && Input.GetMouseButton(0) == false)
        {
            MainFoodObject food = collision.GetComponentInParent<MainFoodObject>();
            if (food.isInFork == true) return;
            //
            food.isInFork = true;
            StartCoroutine(collision.GetComponent<FoodBit>().moveParentToForkArea(Spawns.spawnLocations[index, currentCount].position));
            currentCount++;
            if (currentCount >= leftForkTransform.childCount)
            {
                this.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                EndGame.count++;
            }
        }
    }
}
