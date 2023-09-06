using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyerMovement : MonoBehaviour
{
    Rigidbody palyer;

    public float movementSpeed = 6f;

    public float jumpForce = 5f;

    [SerializeField] Transform Feet;

    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        palyer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float getInputHorizontal = Input.GetAxis("Horizontal");
        float getInputVertical = Input.GetAxis("Vertical");


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        palyer.velocity = new Vector3(getInputHorizontal * movementSpeed, palyer.velocity.y, getInputVertical * movementSpeed);

    }


    void Jump()
    {
        palyer.velocity = new Vector3(palyer.velocity.x, jumpForce, palyer.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }


    bool IsGrounded()
    {
        return Physics.CheckSphere(Feet.position, .1f, ground);
    }

}