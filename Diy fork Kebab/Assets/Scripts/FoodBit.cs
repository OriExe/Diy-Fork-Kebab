using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FoodBit : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private Rigidbody2D rb;
    private BoxCollider2D Foodcollision;
    public enum direction {left, middle, right }
    [SerializeField] private int score;
    [SerializeField] private FoodBit[] foodstoDestroy;
    [SerializeField] private direction forceDirection;
    [SerializeField] private float force;

    [SerializeField]private Rigidbody2D parentRb;
    private MainFoodObject parent;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Foodcollision = GetComponent<BoxCollider2D>();
        parent = parentRb.GetComponent<MainFoodObject>();
    }

  

    /// <summary>
    /// Activates force and destory object
    /// </summary>
    public void activateForce()
    {
        Foodcollision.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        switch (forceDirection)
        {
            case direction.left:
                rb.velocity = new Vector2(-1, 0.02f) * force;
                break;
            case direction.middle:
                rb.velocity =  Vector2.up * force;
                break;
            case direction.right:
                rb.velocity = new Vector2(1, 0.02f) * force;
                break;
        }
        particles.Play();
        Destroy(gameObject,1f);
   
    }

    

    public IEnumerator moveParentToForkArea(Vector2 positon)
    {
        Transform foodObj;
        if (foodstoDestroy.Length == 0)
        {
            foodObj = transform.parent;
        }
        else
        {
            foodObj = transform;
        }

        while (Vector2.Distance(transform.position, positon) > 0.02f)
        {

            foodObj.position =Vector2.MoveTowards(foodObj.position, positon, 0.3f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    //Destroys other foods that aren't connected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Fork") 
        {
            if (Input.GetMouseButton(0) || parent.isInFork) return;
            Score.increaseScore(score); //Increases score for player
            Foodcollision.enabled = false;
            parentRb.simulated = false;
            parent.disableControllers();
            if (foodstoDestroy.Length == 0) return;
            foreach (FoodBit leftovers in foodstoDestroy)
            {
                leftovers.activateForce();
            }
        }
    }
}

