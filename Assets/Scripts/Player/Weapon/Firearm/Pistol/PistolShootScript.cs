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

    public int TargetLayer { get; set; }

    private float reload;

    private void Start(){ reload = 0; }

    private void Update()
    {
        //Attack();
    }

    public void Attack()
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
            if (GetComponent<SpriteRenderer>().flipY == false) { Shoot(0.5f); }
            else { Shoot(-0.5f); }
        }
    }

    private void Shoot(float upCoef)
    {
        Transform weapon = GetComponentInParent<Transform>();
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * 2 + transform.up * upCoef, weapon.rotation * Quaternion.Euler(0, 0, -90));

        bullet.GetComponent<BulletScript>().Damage = damage;
        bullet.GetComponent<BulletScript>().TargetLayer = TargetLayer;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
