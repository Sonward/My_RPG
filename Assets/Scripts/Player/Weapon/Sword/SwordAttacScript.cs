using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacScript : MonoBehaviour
{
    [SerializeField] private int swordDamage = 10;
    [SerializeField] private GameObject attackWavePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        GameObject attackWave = Instantiate(attackWavePrefab, transform.position, transform.rotation, transform);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0f, 0.5f, 0f), 2f);
        
        //Collider2D[] colliders = Physics2D.OverlapCapsuleAll(transform.position + new Vector3(0, 0.5f, 0))

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == 9) { collider.gameObject.GetComponent<NPCsScript>().GetDamage(swordDamage); }
        }
    }
}
