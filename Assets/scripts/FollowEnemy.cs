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

        if (getDistence() <= chasingDistence)
        {
            var CalculatedRot = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, CalculatedRot, Time.deltaTime);
            /* transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 2 * Time.deltaTime);*/



        }


    }

    float getDistence()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

}
