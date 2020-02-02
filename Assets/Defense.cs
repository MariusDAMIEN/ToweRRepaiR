using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public float startHealth = 100f;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDammage(float amount)
    {
        health -= amount;

        // healthbar.fillAmount = health / startHealth;
        if(health <= 0)
        {
             Debug.Log("FIN DU GAME");
        }
    }
}
