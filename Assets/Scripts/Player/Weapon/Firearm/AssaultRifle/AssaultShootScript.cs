using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultShootScript : MonoBehaviour
{
    //[SerializeField] Transform firePont;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int damage = 7;
    [SerializeField] float bulletForce = 20f;

    // reloading 
    [SerializeField] float reloadTime = 0.1f;

    float reload;

    private void Start(){ reload = 0; }

    private void Update()
    {
        if (reload > 0) { reload -= Time.deltaTime; }
        if (Input.GetButton("Fire1"))
        {
            if (reload <= 0f)
            {
                reload = reloadTime;
                if (GetComponent<SpriteRenderer>().flipY == false) { Shoot(0.4f); }
                else { Shoot(-0.4f); }
            }
        }  
    }

    void Shoot(float upCoef)
    {
        Transform weapon = GetComponentInParent<Transform>();
        Quaternion bulletRotation = new Quaternion(weapon.rotation.x, weapon.rotation.y, weapon.rotation.z - 90f, weapon.rotation.w);
        GameObject bullet = Instantiate(bulletPrefab, transform.position - transform.right * 2.5f + transform.up * upCoef, bulletRotation);
        
        bullet.GetComponent<BulletScript>().Damage = damage;
        bullet.GetComponent<BulletScript>().TargetLayer = 9;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
