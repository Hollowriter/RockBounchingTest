using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.activeInHierarchy)
            {
                CoinCounter.instance.SetCoinsCollected(CoinCounter.instance.GetCoinsCollected() + 1);
                this.gameObject.transform.position = Vector3.zero;
                this.gameObject.SetActive(false);
            }
        }
    }
}
