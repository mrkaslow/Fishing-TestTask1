using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	private GameObject canvas;
	
	void Start () {
		InitController();
	}

	private void InitController()
	{
		App app = App.Instance;
		canvas = FindObjectOfType<Canvas>().gameObject;
		StartMinigame();
	}

	private void StartMinigame()
	{
		App.Instance.view.UI.SetActive(true);
		App.Instance.controller.Input.Init();
		App.Instance.controller.fish.Init();
		App.Instance.controller.fill.Init();
		App.Instance.controller.rod.Init();
	}

	private void HideMinigame()
	{
		App.Instance.controller.Input.gameObject.SetActive(false);
		App.Instance.controller.fish.gameObject.SetActive(false);
		App.Instance.controller.fill.gameObject.SetActive(false);
		App.Instance.controller.rod.gameObject.SetActive(false);
	}

	private void ResetMinigame()
	{
		HideMinigame();
		StartMinigame();
	}
}
