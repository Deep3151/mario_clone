using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectors : MonoBehaviour
{

    int coins = 0;

    [SerializeField] Text CoinsText;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coins++;
            CoinsText.text = "coins: " + coins;
        }
    }
}
