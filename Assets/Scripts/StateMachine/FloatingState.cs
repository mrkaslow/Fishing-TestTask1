using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingState : IFishState {
    private readonly StatePatternFish fish;

    public FloatingState(StatePatternFish statePatternFish)
    {
        fish = statePatternFish;
    }
    
    public void UpdateState()
    {
        var fishposition = Camera.main.WorldToScreenPoint(fish.transform.position);
        var boxPosition = Camera.main.WorldToScreenPoint(fish.greenField.position);
        
        if (fishposition.y > boxPosition.y - 2000 && fishposition.y < boxPosition.y + 2000)
        {
            ToEscapeState();
        }
    }

    public void ToFloatingState()
    {
        throw new System.NotImplementedException();
    }

    public void ToEscapeState()
    {
        fish.currentPosition = fish.transform.localPosition;
        fish.targetPosition = new Vector2(fish.transform.localPosition.x, fish.CreateWayPoint());
        fish.currentState = fish.escapeState;
    }

    public void ToWinState()
    {
        fish.currentState = fish.winState;
    }
}
