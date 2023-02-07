using System;
using UnityEngine;
using System.Collections;
public Grid Environment;
public Tilemap ColorTiles;
public Tile RedTile;
public Tile GreenTile;


public class Grid : MonoBehaviour
{
    public int xSize, ySize;


    private void start
    {
        ColorTiles = GetComponent<tilemap>();
        BoundsInt bounds = ColorTiles.CellBounds
        Tilebase[] allTiles = ColorTiles.GetTilesBlock(bounds);
    int colorcounter = 0;
    var RedTile = Resources.Load<Tile>("Assets/Resources/TileRed.asset");
    var GreenTile = Resources.Load<Tile>("Assets/Resources/TileGreen.asset");
        for (int x = 0; x<bounds.size.x; x++){
            for (int y = 0; y<bounds.size.y; y++){
                if (allTiles[x, y].GetTileData == GreenTile||allTiles[x, y].GetTileData == GreenTile){
                        colorcounter++;
        }}}
        
                   }
}