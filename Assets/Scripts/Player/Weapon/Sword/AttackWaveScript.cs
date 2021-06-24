using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D[] colliders = Physics2D.OverlapCollider(GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>(), );
    }
}
