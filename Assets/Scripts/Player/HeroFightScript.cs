using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFightScript : MonoBehaviour
{
    [SerializeField] private int currentWeapon = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){if (currentWeapon != -1){ ChooseWeapon(-1); }}
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ChooseWeapon(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ChooseWeapon(1); }
    }

    private void ChooseWeapon(int newWeapon)
    { 
        if (newWeapon == -1 || newWeapon == currentWeapon)
        {
            transform.GetChild(3).GetChild(currentWeapon).gameObject.SetActive(false);
            currentWeapon = -1;
        }
        else
        {
            if (currentWeapon != -1)
            {
                transform.GetChild(3).GetChild(currentWeapon).gameObject.SetActive(false);
                transform.GetChild(3).GetChild(newWeapon).gameObject.SetActive(true);
                currentWeapon = newWeapon;
            }
            else
            {
                transform.GetChild(3).GetChild(newWeapon).gameObject.SetActive(true);
                currentWeapon = newWeapon;
            }
            
        }
    }
}
