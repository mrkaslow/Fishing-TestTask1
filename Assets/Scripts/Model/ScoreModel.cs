using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public Action<int> OnScoreChange;
    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (OnScoreChange != null) OnScoreChange(score);
        }
    }
}
