using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsAI : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 20, 1 << 6) != null)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 20, 1 << 6);
            player = playerCollider.gameObject;
        }
        else
        {
            player = null;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(player);
        }
    }
}
