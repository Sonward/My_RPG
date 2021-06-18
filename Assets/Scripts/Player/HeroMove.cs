using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float cameraSize = 10f;
    [SerializeField] private float speed = 15f;

    private bool walk;

    private Vector3 mousePosition3D;

    public float Speed { get => speed; }
    public Vector3 MousePosition3D { get => mousePosition3D; }

    // Start is called before the first frame update
    void Start()
    {
        //speed = 15f;
        Camera.main.orthographicSize = cameraSize;
        walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition3D.z = transform.position.z;

        if (Input.GetMouseButtonDown(1))
        {
            walk = true;
        }

        if (walk)
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePosition3D, speed * Time.deltaTime);
        }
        if (transform.position == mousePosition3D) { walk = false; }
    }
}
