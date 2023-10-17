using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool Dead = false;

    int PlayerHealth = 100;
       
    void Update()
    {
        if(transform.position.y < -3f && !Dead)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlyerMovement>().enabled = false;
        Invoke(nameof(ReloadLavel), 1.3f);
        Dead = true;
    }

    void ReloadLavel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
