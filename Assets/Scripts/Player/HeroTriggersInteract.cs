using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTriggersInteract : MonoBehaviour
{
    [SerializeField] private LayerMask buttonsMask;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("You stepped on the button");
        }
        // ��� �� ��'���� � �������� ������ ���� ������� Interact()
        //Debug.Log("You stepped on the button");
    }
}
