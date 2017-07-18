using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingState : IFishState
{
    private readonly StatePatternFish fish;

    public CatchingState(StatePatternFish statePatternFish)
    {
        fish = statePatternFish;
    }
    
    public void UpdateState()
    {
        Debug.Log("JEAH!");
    }

    public void ToFloatingState()
    {
        throw new System.NotImplementedException();
    }

    public void ToCatchingState()
    {
        throw new System.NotImplementedException();
    }

    public void ToEscapeState()
    {
        throw new System.NotImplementedException();
    }

    public void ToWinState()
    {
        throw new System.NotImplementedException();
    }
}
