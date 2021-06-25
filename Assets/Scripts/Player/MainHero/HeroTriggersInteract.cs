using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTriggersInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("You stepped on the button");
        }
        if (collision.gameObject.layer == 9)
        {
            collision.GetComponent<NPCsAI>().GetDialog();
        }
        // Крч всі об'єкти з трігерами будуть мати функцію Interact()
        //Debug.Log("You stepped on the button");
    }
}
