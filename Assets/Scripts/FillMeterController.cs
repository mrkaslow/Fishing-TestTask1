using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillMeterController : MonoBehaviour
{

	private Image fillMeter;
	public Color MaxColor = Color.green;
	public Color MinColor = Color.red;
	private bool initialized = false;

	public void Init ()
	{
		fillMeter = App.Instance.view.FillMeter;
		initialized = true;
	}
	
	void Update () {
		if(initialized)
		ChangeColor();
	}
	
	public void ChangeColor() {
		var fillAmount = fillMeter.fillAmount;
		fillMeter.color = Color.Lerp(MinColor, MaxColor, fillAmount / 1.0f);
	}
}
