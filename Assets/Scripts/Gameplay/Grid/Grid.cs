using UnityEngine;

public class Grid
{
    private int gridSize = 50;
    private CellData[,] grid;
    
    public Grid()
    {
        grid = new CellData[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                var cell = new CellData(new Vector2Int(i, j), true);
                grid[i, j] = cell;
            }
        }
    }

    public CellData GetCell(Vector2Int position)
    {
        return grid[position.x, position.y];
    }

    public bool IsCellEmpty(Vector2Int position)
    {
        return grid[position.x, position.y].IsCellEmpty;
    }

    public void PlaceObjectOnGrid(IPlaceable obj, Vector2Int position)
    {
        grid[position.x, position.y].PlaceObject(obj);
    }
    
    public void RemoveObjectFromGrid(Vector2Int position)
    {
        grid[position.x, position.y].RemoveObject();
    }
}
