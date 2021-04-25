using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<WeaponController> startingWeapons = new List<WeaponController>();
    public Transform weaponParentSocket;
    public UnityAction<WeaponController>onSwitchedToWeapon;
    private WeaponController[] _weaponSlots = new WeaponController[9];
    private void Start()
    { 
        onSwitchedToWeapon += OnWeaponSwitched;
        foreach (WeaponController weapon in startingWeapons)
        {
            Addweapon(weapon);
        }
        SwitchWeapon();
    }

    private void Update()
    {
        WeaponController activeWeapon = _weaponSlots[0];
        if (activeWeapon)
        {
            activeWeapon.HandleShootInputs(PlayerInputHandler.Instance.GetFireInputHeld());
        }
        
    }
    public bool Addweapon(WeaponController weaponPrefab)
    {
        for(int i=0;i<_weaponSlots.Length;i++)
        {
            WeaponController weaponInstance = Instantiate(weaponPrefab,weaponParentSocket);
            weaponInstance.transform.localPosition = Vector3.zero;
            weaponInstance.transform.localRotation = Quaternion.identity;
		
            weaponInstance.owner = gameObject;
            weaponInstance.sourcePrefab = weaponPrefab.gameObject;
            weaponInstance.ShowWeapon(false);
		
            _weaponSlots[i]=weaponInstance;
            return true;
        }
        return false;
    }
    public void SwitchWeapon()
    {
        SwitchWeaponToIndex(0);
    }
    public void SwitchWeaponToIndex(int newWeaponIndex)
    {
        if(newWeaponIndex >= 0)
        {
            WeaponController newWeapon = GetWeaponAtSlotIndex(newWeaponIndex);

            if (onSwitchedToWeapon != null)
            {
                onSwitchedToWeapon.Invoke(newWeapon);
            }
        }
    }	
    public WeaponController GetWeaponAtSlotIndex(int index)
    {
        if (index >= 0 && index < _weaponSlots.Length)
        {
            return _weaponSlots[index];
        }

        return null;
    }
    private void OnWeaponSwitched(WeaponController newWeapon)
    {
        if(newWeapon != null)
        {
            newWeapon.ShowWeapon(true);
        }
    }
}