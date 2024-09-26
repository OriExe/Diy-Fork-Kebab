using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFoodObject : MonoBehaviour
{
    public bool isInFork = false;
    private float minX, maxX, minY, maxY;
    [SerializeField]private Rigidbody2D[] rigidbodies;
    [SerializeField] private Rigidbody2D Main_rb;
    private float padding = 1f;
    private static Camera mainCamera;
    [SerializeField] private FoodBit[] objectChilds;
    [SerializeField] private PlayerController[] controllers;
    private bool destroyed = false;
    [SerializeField] private AudioSource popsound;
    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        try
        {
        Score.increaseScore(-1);
        }
        catch
        {
            print("Running in unity editor");
        }

    }
    public void disableControllers()
    {
        foreach (PlayerController controller in controllers) 
        {
            controller.enabled = false;
            popsound.Play();
        }
    }
    public void enableRidigbodies()
    {
        Main_rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void disableRidigbodies()
    {
        Main_rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        if (Main_rb.isKinematic == false)
        {
            CalculateScreenBounds();

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
            if ((clampedPosition.x != transform.position.x || clampedPosition.y != transform.position.y) && destroyed == false)
            {
                destroyed = true;
                foreach(FoodBit child in objectChilds)
                {
                    child.activateForce();
                }
                Destroy(gameObject, 1f);
                popsound.Play();
            }
        }
    }
    void CalculateScreenBounds()
    {
        float screenPaddingX = padding * (Screen.width / Screen.height);
        float screenPaddingY = padding;

        minX = mainCamera.ViewportToWorldPoint(Vector3.zero).x + screenPaddingX;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - screenPaddingX;
        minY = mainCamera.ViewportToWorldPoint(Vector3.zero).y + screenPaddingY;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - screenPaddingY;
    }

 
}
