using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private Transform map;

    [Header("Tiles del nivel")]
    [SerializeField]
    private GameObject [] tilePrefabs;

    [Header("Instanciado del Spawn de los enemigos")]
    [SerializeField]
    private GameObject spawnPortal;
    public Vector2 spawnPortalPoint;
    [Header("Instanciado de la Meta de los enemigos")]

    [SerializeField]
    private GameObject goalPortal;
    public Vector2 goalPortalPoint;

    public Dictionary<Point,TileScript> Tiles { get; set; }


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

        Tiles = new Dictionary<Point, TileScript>();

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

        Portals();

    }

    private void PlaceTile(string tileType, int i, int j, Vector3 worldStartPosition)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        
        newTile.Setup(new Point(i,j), new Vector3(worldStartPosition.x + TileSize() / 2 + (TileSize() * i), worldStartPosition.y - (TileSize() / 2) - (TileSize() * j), 0),map);

    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;

        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

    private void Portals()
    {
        Point pointSpawn = new Point((int)spawnPortalPoint.x,(int)spawnPortalPoint.y);
        Instantiate(spawnPortal,Tiles[pointSpawn].transform.position, Quaternion.identity);

        Point pointGoal = new Point((int)goalPortalPoint.x, (int)goalPortalPoint.y);
        Instantiate(goalPortal, Tiles[pointGoal].transform.position, Quaternion.identity);
    }

   

    
}
