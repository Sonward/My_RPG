using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotateScript : MonoBehaviour
{
    private Vector3 MousePosition;

    // Update is called once per frame
    void Update()
    {
        MousePosition = GetComponentInParent<HeroMove>().MousePosition3D;
        Vector3 difference = MousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
