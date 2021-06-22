using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int Damage { get; set; }
    public int TargetLayer { get; set; }

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TargetLayer == 6)
        {
            // TODO
        }
        if (TargetLayer == 9)
        {
            if (collision.gameObject.layer != 6 && collision.gameObject.layer != 10)
            {
                if (collision.gameObject.layer == 9) { collision.gameObject.GetComponent<NPCsScript>().GetDamage(Damage); }
                Destroy(gameObject);
            }
        }
    }
}
