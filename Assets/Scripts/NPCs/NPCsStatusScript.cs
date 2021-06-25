using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsStatusScript : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    [SerializeField] private bool isDead = false;

    public int Healthpoints { get => healthPoints; }
    public bool IsDead { get => isDead; }

    public void GetDamage(int damage)
    {
        healthPoints -= damage;
        Debug.Log("NPC get damage: " + damage);
        if (healthPoints <= 0)
        {
            Death();
            Debug.Log("NPC was murdered");
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
