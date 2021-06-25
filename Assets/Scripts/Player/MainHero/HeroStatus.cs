using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour
{
    int health = 20;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeroGetDamage(int damage)
    {
        health -= damage;
        Debug.Log("Hero get damage: " + damage);
        if (health <= 0)
        {
            Death();
            Debug.Log("Hero was murdered");
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<PolygonCollider2D>().enabled = false;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
    }
}
