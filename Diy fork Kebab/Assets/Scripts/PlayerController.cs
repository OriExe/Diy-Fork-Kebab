using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private static Camera cam;
    
    private Vector2 offset;
    private bool mouseClicked = false;
    [SerializeField] private MainFoodObject main;
    [SerializeField] private bool isMiddle;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null) 
        {
            cam = Camera.main;
        }
        offset = transform.localPosition;
        if (isMiddle)
        {
            mouseClicked = true;
            main.disableRidigbodies();
        }
    }

    private void Update()
    {
        if (mouseClicked) 
        {
            Vector2 position = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.parent.position = position - offset;
        }
       
        if (mouseClicked && Input.GetMouseButtonUp(0)) 
        {
            mouseClicked = false;
            main.enableRidigbodies();
            //And rigidbody activate or whatever 
        }
        
    }
    // Update is called once per frame
    //Detects if mouse is OverObject
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
           mouseClicked = true;
           main.disableRidigbodies();
        }
    }

}
