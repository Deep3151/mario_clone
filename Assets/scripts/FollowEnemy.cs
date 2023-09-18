using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{

    public Transform targetObj;

    [SerializeField] GameObject player;
    [SerializeField] float chasingDistence = 0.5f;

    // Update is called once per frame
    void Update()
    {

        if(getDistence() <= chasingDistence)
        {
            transform.LookAt(player.transform);
           /* transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 2 * Time.deltaTime);*/
            


        }
            
        
    }

    float getDistence()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

}
