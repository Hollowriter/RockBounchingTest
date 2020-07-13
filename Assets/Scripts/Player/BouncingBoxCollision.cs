using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBoxCollision : MonoBehaviour
{
    public float bounceFactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock") 
        {
            RockMovement rock = collision.gameObject.GetComponent<RockMovement>();
            rock.SetSpeed(rock.GetSpeed() * bounceFactor);
        }
    }
}
