using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public TowerButton ClickedButton { get; private set; }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickTower(TowerButton towerButton)
    {
        ClickedButton = towerButton;
    }
}
