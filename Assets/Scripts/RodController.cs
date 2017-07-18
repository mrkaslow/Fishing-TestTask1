using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RodController : MonoBehaviour {

	private Image fillMeter;
	private GameObject playerRod;
	private bool initialized = false;
	
	public void Init ()
	{
		fillMeter = App.Instance.view.FillMeter;
		playerRod = App.Instance.view.playerRod;
		initialized = true;
	}
	
	void Update () {
		if(initialized)
		RotateRod();
	}
	
	public void RotateRod() {
		var fillAmount = fillMeter.fillAmount;
		playerRod.transform.localEulerAngles = new Vector3(0, 0, fillAmount*25);	
	}
}
