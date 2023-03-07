using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32 (247, 0, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32 (20, 20, 20, 20);
    [SerializeField] float timeRemaining = 10f;

    bool isGameRunning;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    bool hasPackage;

    [SerializeField] float timeToDestroy = 0.5f;

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch, that hurt...");    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // If we trigger the package, then we print "picked up package"
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, timeToDestroy);
        }


        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }
}
