using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : IFishState
{
	private const float MOVE_TIME = 1.0f;
	private readonly StatePatternFish fish;

	private float movementProgress = 0.0f;

	private static float easeOutQuad(float start, float end, float value)
	{
		end -= start;
		return -end * value * (value - 2) + start;
	}

	public EscapeState(StatePatternFish statePatternFish)
	{
		fish = statePatternFish;
	}
	
	public void UpdateState()
	{
		ProcessFishMovement();
	}

	void ProcessFishMovement()
	{
		movementProgress += Time.deltaTime / MOVE_TIME;
		if (movementProgress < 1.0f)
		{
			fish.transform.localPosition =
				Vector2.Lerp(fish.currentPosition, fish.targetPosition, easeOutQuad(0.0f, 1.0f, movementProgress));
		}
		else
		{
			movementProgress = 0.0f;
			ToFloatingState();
		}
	}

	public void ToFloatingState()
	{
		fish.currentState = fish.floatingState;
	}

	public void ToEscapeState()
	{
		throw new System.NotImplementedException();
	}

	public void ToWinState()
	{
		fish.currentState = fish.winState;
	}
}
