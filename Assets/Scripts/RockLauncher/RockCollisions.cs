using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BouncingBox") 
        {
            BouncingBoxCollision bounceBox = collision.gameObject.GetComponent<BouncingBoxCollision>();
            this.gameObject.GetComponent<RockMovement>().Bounce(bounceBox.bounceFactor);
        }
    }
}
