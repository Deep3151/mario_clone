using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool Dead = false;

    [SerializeField] private HealthSystem _healthSystem ;
    [SerializeField] private float _maxHealth = 3;
    private float _currentHealth;



   void Start()
    {
        _currentHealth = _maxHealth;
        _healthSystem.updateHealthBar(_maxHealth, _currentHealth);

    }

   void Update()
    {
        if(transform.position.y < -3f && !Dead)
        {
            _healthSystem.updateHealthBar(_maxHealth, _currentHealth);
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            _currentHealth -= 1f;
            _healthSystem.updateHealthBar(_maxHealth, _currentHealth);
        }
        
        if(_currentHealth <= 0)
        {
            Die();
        }

        else
        {
            _healthSystem.updateHealthBar(_maxHealth, _currentHealth);
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
