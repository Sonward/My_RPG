using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFightScript : MonoBehaviour
{
    [SerializeField] Camera cam;

    private float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
 
    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<HeroMove>().Speed;
        rb = GetComponent<Rigidbody2D>();
        mousePos = GetComponent<HeroMove>().MousePosition3D;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = GetComponent<HeroMove>().MousePosition3D;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
