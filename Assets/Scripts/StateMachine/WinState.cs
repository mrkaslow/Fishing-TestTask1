using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IFishState 
{    
    private const float SCALEUP_TIME = 1.0f;
    private readonly StatePatternFish fish;


    private float scaleProgress = 0.0f;

    private static float easeOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }
    public WinState(StatePatternFish statePatternFish)
    {
        fish = statePatternFish;
    }
    
    public void UpdateState()
    {
        ProcessFishScaleUp();
    }

    void ProcessFishScaleUp()
    {
        scaleProgress += Time.deltaTime / SCALEUP_TIME;
        if (scaleProgress < 1.0f)
        {
            fish.transform.localScale =
                Vector2.Lerp(new Vector2(1,1), new Vector2(2,2), easeOutQuad(0.0f, 1.0f, scaleProgress));
        }
        else
        {
            scaleProgress = 0.0f;
            fish.ResetFish();
        }
    }
    
    public void ToFloatingState()
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
