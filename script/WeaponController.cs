using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject weaponRoot;
	public float delayBetweenShots = 0.1f;
	private float _lastShotTime = Mathf.NegativeInfinity;
	public bool isWeaponActive { get; private set; }
	public GameObject owner { get; set; }
	public GameObject sourcePrefab { get; set; }
	public void ShowWeapon(bool show)
	{
		weaponRoot.SetActive(show);
		isWeaponActive = show;
	}
	public bool HandleShootInputs(bool inputHeld)
	{
		if(inputHeld)
		{
			return TryShoot();
		}
		return false;
	}
	private bool TryShoot()
	{
		if(_lastShotTime + delayBetweenShots< Time.time)
		{
			HandleShoot();
			print(message:"shot");
			return true;
		}
		return false;
	}
	private void HandleShoot()
	{
		_lastShotTime = Time.time;
	}
}
