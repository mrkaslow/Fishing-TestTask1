using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StatePatternFish : MonoBehaviour
{
	[HideInInspector]
	public IFishState currentState;
	[HideInInspector]
	public CatchingState catchingState;
	[HideInInspector]
	public WinState winState;
	[HideInInspector]
	public EscapeState escapeState;	
	[HideInInspector]
	public FloatingState floatingState;

	private bool initialized = false;
	private bool fishCatched = false;
	
	[HideInInspector]
	public RectTransform greenField;	
	
	[HideInInspector]
	public RectTransform leftFrame;
	[HideInInspector]
	public Vector2 currentPosition;
	[HideInInspector]
	public Vector2 targetPosition;

	private Image fillMeter;

	public void Init()
	{
		greenField = App.Instance.view.InnerScroll.handleRect;
		leftFrame = App.Instance.view.LeftFrame.GetComponent<RectTransform>();
		fillMeter = App.Instance.view.FillMeter;
		escapeState = new EscapeState(this);
		winState = new WinState(this);
		floatingState = new FloatingState(this);
		currentState = floatingState;
		initialized = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(initialized)
		CheckCatching();
		CheckScore();
		currentState.UpdateState();
	}

	public float CreateWayPoint()
	{
		var newPoint = 0.0f;
		do
		{
			newPoint = Random.Range(leftFrame.rect.yMin + 200, leftFrame.rect.yMax - 200);
		} while (Math.Abs(newPoint - transform.localPosition.y) < leftFrame.rect.height/4);
		
		return newPoint;
	}

	public void ResetFish()
	{
		currentState = floatingState;
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;
		fillMeter.fillAmount = 0.0f;
		fishCatched = false;
	}

	private void CheckCatching()
	{
		if (!fishCatched)
		{
			if (isCatching())
			{
				fillMeter.fillAmount += Time.deltaTime * 0.2f;
			}
			else
			{
				fillMeter.fillAmount -= Time.deltaTime * 0.2f;
			}
		}
	}
	
	private void CheckScore()
	{
		if (fillMeter.fillAmount >= 1 && !fishCatched)
		{
			currentState.ToWinState();
			fishCatched = true;
		}
	}
	
	private bool isCatching()
	{
		var fishposition = Camera.main.WorldToScreenPoint(transform.position);
		var boxPosition = Camera.main.WorldToScreenPoint(greenField.position);

		if (fishposition.y > boxPosition.y - 2000 && fishposition.y < boxPosition.y + 2000)
		{
			return true;
		}
		return false;
	}
}
