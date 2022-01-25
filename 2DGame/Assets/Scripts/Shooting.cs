using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public int clipSize;
    private int ammo;
    public int reloadTimeSecs = 2;


    public float bulletForce = 20f;


    public Text AmmoAmount;
    public Text AmmoAmount2;

    private Boolean started = false;
    public bool Started { get => started; set => started = value; }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            ammo = clipSize;
            ChangeAmmoText(ammo.ToString());
            started = true;
        }

        if (!PauseMenu.GamePaused)
        {
            // Waits for key presses
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            if (Input.GetButtonDown("Reload"))
            {
                Reload();
            }
        }
    }

    void Shoot()
    {
        if (ammo > 0) {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            ammo = ammo - 1;
            ChangeAmmoText(ammo.ToString());

        }
    }

    async void Reload()
    {
        ammo = 0;
        ChangeAmmoText("...");
        await Task.Delay(reloadTimeSecs*1000);
        ammo = clipSize;
        ChangeAmmoText(ammo.ToString());
    }

    void ChangeAmmoText(string text)
    {
        // Changes ammo amount text
        AmmoAmount.text = text;
        AmmoAmount2.text = text;
    }
}
