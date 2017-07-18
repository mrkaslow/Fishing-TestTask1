using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
	private Scrollbar innerScrollbar;
	private RectTransform leftFrame;
	private bool move = false;
	private float greenFieldSize;
	
	public void Init ()
	{
		innerScrollbar = App.Instance.view.InnerScroll.GetComponent<Scrollbar>();
		leftFrame = App.Instance.view.LeftFrame.GetComponent<RectTransform>();
		move = true;
	}

	void Update()
	{
		if (!move)
			return;
		var scrollValue = Input.mousePosition.y / Screen.height;
		innerScrollbar.value = scrollValue;
	}
}
