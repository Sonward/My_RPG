using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsFightScript : MonoBehaviour
{
    private Transform player;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NPCsAI>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        player = GetComponent<NPCsAI>().Player;

        if (player != null)
        {
            _direction = (player.position - transform.position).normalized;
            float rotation_z = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;

            transform.GetChild(4).rotation = Quaternion.Euler(0f, 0f, -rotation_z + 90);
        }
    }
}
