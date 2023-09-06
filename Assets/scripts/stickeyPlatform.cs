using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickeyPlatform : MonoBehaviour
{
   void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
