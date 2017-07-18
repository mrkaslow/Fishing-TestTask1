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
        public GameObject UI;
    }

    [Serializable]
    public class Model
    {
        public GamePrefabs prefabs;
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
