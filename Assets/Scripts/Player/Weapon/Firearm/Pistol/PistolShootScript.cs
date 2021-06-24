using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShootScript : MonoBehaviour
{
    //[SerializeField] Transform firePont;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int damage = 5;
    [SerializeField] float bulletForce = 20f;

    // reloading // maybe will be useful
    [SerializeField] bool needReload = false;
    [SerializeField] float reloadTime = 0.1f;

    float reload;

    private void Start(){ reload = 0; }

    private void Update()
    {
        if (needReload)
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
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (GetComponent<SpriteRenderer>().flipY == false) { Shoot(0.5f); }
                else { Shoot(-0.5f); }
            }
        }
        
    }

    void Shoot(float upCoef)
    {
        Transform weapon = GetComponentInParent<Transform>();
        //Quaternion bulletRotation = new Quaternion(weapon.rotation.x, weapon.rotation.y, weapon.rotation.z, weapon.rotation.w);
        //Debug.Log("Weapon Rotation: " + weapon.rotation + "Bullet Rotation: " + bulletRotation);
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * 2 + transform.up * upCoef, weapon.rotation * Quaternion.Euler(0, 0, -90));
        Debug.Log("Weapon Rotation: " + weapon.rotation + "Bullet Rotation: " + weapon.rotation * Quaternion.Euler(0, 0, -90));

        bullet.GetComponent<BulletScript>().Damage = damage;
        bullet.GetComponent<BulletScript>().TargetLayer = 9;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
