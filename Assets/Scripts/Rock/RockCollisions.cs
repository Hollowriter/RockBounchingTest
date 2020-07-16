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
            this.gameObject.GetComponent<RockMoveManager>().CheckAdequateMovement();
        }

        if (collision.gameObject.tag == "Floor") 
        {
            this.gameObject.GetComponent<RockMovement>().enabled = false;
            this.gameObject.GetComponent<RockToGoal>().enabled = false;
            this.gameObject.GetComponent<RockClock>().SetTime(0);
            this.gameObject.GetComponent<RockFloorDisabler>().ConfirmCollisionWithFloor();
        }
    }
}
