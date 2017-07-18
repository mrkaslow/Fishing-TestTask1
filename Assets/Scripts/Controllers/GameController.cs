using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	private GameObject canvas;

	void Start()
	{
		InitController();
	}

	private void InitController()
	{
		App app = App.Instance;
		App.Instance.model.score.OnScoreChange += UpdateScoreText;
		App.Instance.view.playButton.onClick.AddListener(() =>
		{
			StartCoroutine(FadeUI(1, 0, App.Instance.view.UIMenu, StartMinigame));
		});
		canvas = FindObjectOfType<Canvas>().gameObject;
	}

	private void StartMinigame()
	{
		App.Instance.model.score.Score = 0;
		App.Instance.view.UIMenu.SetActive(false);
		App.Instance.view.UIGameplay.SetActive(true);
		App.Instance.controller.Input.gameObject.SetActive(true);
		App.Instance.controller.fish.gameObject.SetActive(true);
		App.Instance.controller.fill.gameObject.SetActive(true);
		App.Instance.controller.rod.gameObject.SetActive(true);
		App.Instance.controller.Input.Init();
		App.Instance.controller.fish.Init();
		App.Instance.controller.fill.Init();
		App.Instance.controller.rod.Init();
		App.Instance.view.closeButton.onClick.AddListener(() =>
		{
			StartCoroutine(FadeUI(1, 0, App.Instance.view.UIGameplay, HideMinigame));
		});
		App.Instance.view.restartButton.onClick.AddListener(ResetMinigame);
		StartCoroutine(FadeUI(0, 1, App.Instance.view.UIGameplay, null));
	}

	private void HideMinigame()
	{
		App.Instance.view.UIMenu.SetActive(true);
		App.Instance.view.UIGameplay.SetActive(false);
		App.Instance.controller.Input.gameObject.SetActive(false);
		App.Instance.controller.fish.gameObject.SetActive(false);
		App.Instance.controller.fill.gameObject.SetActive(false);
		App.Instance.controller.rod.gameObject.SetActive(false);
		StartCoroutine(FadeUI(0, 1, App.Instance.view.UIMenu, null));
	}

	private void UpdateScoreText(int score)
	{
		App.Instance.view.ScoreText.text = string.Format("Fish: {0}", score);
	}

private void ResetMinigame()
	{
		HideMinigame();
		StartMinigame();
	}

	IEnumerator FadeUI(float start, float end, GameObject objectToFade, [CanBeNull] Action action)
	{
		var wait = new WaitForEndOfFrame();
		var images = objectToFade.GetComponentsInChildren<Image>();
		var totalTime = 0.0f;
		var time = 1.0f;
		while (totalTime < time)
		{
			totalTime += Time.deltaTime;
			foreach (var image in images)
			{
				var imageColor = image.color;
				imageColor.a = Mathf.Lerp(start, end, totalTime);
				image.color = imageColor;
			}
			yield return wait;
		}
		if (action != null)
		{
			action();
		}
	}
}
