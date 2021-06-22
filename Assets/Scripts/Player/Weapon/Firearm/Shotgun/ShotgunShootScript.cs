using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShootScript : MonoBehaviour
{
    //[SerializeField] Transform firePont;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int damage = 2;
    [SerializeField] float bulletForce = 20f;

    // reloading // maybe will be useful
    [SerializeField] float reloadTime = 0.15f;

    float reload;

    private void Start() { reload = 0; }

    private void Update()
    {
        if (reload > 0) { reload -= Time.deltaTime; }
        if (Input.GetButtonDown("Fire1"))
        {
            if (reload <= 0f)
            {
                reload = reloadTime;
                if (GetComponent<SpriteRenderer>().flipY == false) { Shoot(0.5f); }
                else { Shoot(-0.5f); }
            }
        }
    }

    void Shoot(float upCoef)
    {
        Transform weapon = GetComponentInParent<Transform>();
        Quaternion bulletRotation = new Quaternion(weapon.rotation.x, weapon.rotation.y, weapon.rotation.z - 90f, weapon.rotation.w);
        
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position - transform.right + transform.up * upCoef, bulletRotation);
            bullet.GetComponent<BulletScript>().Damage = damage;
            bullet.GetComponent<BulletScript>().TargetLayer = 9;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
