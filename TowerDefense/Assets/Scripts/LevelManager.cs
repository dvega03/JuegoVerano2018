using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;


	void Start ()
    {
        CreateLevel();
	}
	
	
	void Update ()
    {
		
	}

    public float TileSize()
    {
        return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    private void CreateLevel()
    {

        Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                PlaceTile(i,j, worldStartPosition);
            }
        }
    }

    private void PlaceTile(int i, int j, Vector3 worldStartPosition)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(worldStartPosition.x + TileSize()/2 + (TileSize() * i), worldStartPosition.y - (TileSize()/2) - (TileSize() * j), 0);
    }
}
