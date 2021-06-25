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

    public int TargetLayer { get; set; }

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
                if (GetComponent<SpriteRenderer>().flipY == false) { Shoot(0.3f); }
                else { Shoot(-0.3f); }
            }
        }
    }

    void Shoot(float upCoef)
    {
        Transform weapon = GetComponentInParent<Transform>();
        //Quaternion bulletRotation = new Quaternion(weapon.rotation.x, weapon.rotation.y, weapon.rotation.z - 90f, weapon.rotation.w);

        float angleForOneBullet = 10f / 8f;

        Debug.Log(transform.right);

        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right*2 + transform.up * upCoef, weapon.rotation * Quaternion.Euler(0, 0, -90));
            bullet.GetComponent<BulletScript>().Damage = damage;
            bullet.GetComponent<BulletScript>().TargetLayer = TargetLayer;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce + new Vector3(transform.right.x * angleForOneBullet * i, transform.right.y * angleForOneBullet * (1 - i), 0f), ForceMode2D.Impulse);
        }
    }
}
