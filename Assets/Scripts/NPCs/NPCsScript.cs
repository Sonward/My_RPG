using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsScript : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    [SerializeField] private bool isDead = false;

    public int Healthpoints { get => healthPoints; set => healthPoints = value; }
    public bool IsDead { get => isDead; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints<=0) { isDead = true; Debug.Log("NPC was murdered"); }
    }
}
