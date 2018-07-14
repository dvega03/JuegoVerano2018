using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject [] tilePrefabs;


	void Start ()
    {
        CreateLevel();
	}
	
	
	void Update ()
    {
		
	}

    public float TileSize()
    {
        return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    private void CreateLevel()
    {

        string[] mapData = ReadLevelText();

        int mapXSize = mapData[0].Length;
        int mapYSize = mapData.Length;


        Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));

        for (int j = 0; j < mapYSize; j++)
        {
            for (int i = 0; i < mapXSize; i++)
            {
                PlaceTile(mapData[j][i].ToString(),i,j, worldStartPosition);
            }
        }
    }

    private void PlaceTile(string tileType, int i, int j, Vector3 worldStartPosition)
    {
        int tileIndex = int.Parse(tileType); 


        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);
        newTile.transform.position = new Vector3(worldStartPosition.x + TileSize()/2 + (TileSize() * i), worldStartPosition.y - (TileSize()/2) - (TileSize() * j), 0);
    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;

        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

}
