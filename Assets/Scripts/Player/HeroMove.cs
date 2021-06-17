using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float cameraSize = 10f;
    [SerializeField] private float speed = 15f;

    private bool walk;

    Vector3 MousePosition3D;

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
        if (Input.GetMouseButtonDown(1))
        {
            MousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition3D.z = transform.position.z;
            walk = true;
        }

        if (walk)
        {
            transform.position = Vector3.MoveTowards(transform.position, MousePosition3D, speed * Time.deltaTime);
        }
        if (transform.position == MousePosition3D) { walk = false; }
    }
}
