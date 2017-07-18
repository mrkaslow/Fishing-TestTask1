using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class App : MonoBehaviour {

    public static App Instance;
    
    [Serializable]
    public class View
    {
        public Scrollbar InnerScroll;
        public GameObject LeftFrame;
        public Image FillMeter;
        public GameObject playerRod;
        public GameObject UIGameplay;
        public GameObject UIMenu;
        public Button playButton;
        public Button restartButton;
        public Button closeButton;
        public Text ScoreText;
    }

    [Serializable]
    public class Model
    {
        public GamePrefabs prefabs;
        public ScoreModel score;
    }

    [Serializable]
    public class Controller
    {
        public InputController Input;
        public StatePatternFish fish;
        public FillMeterController fill;
        public RodController rod;
    }

    public Model model;
    public View view;
    public Controller controller;


    void Awake() {
        App.Instance = this;
    }

}
