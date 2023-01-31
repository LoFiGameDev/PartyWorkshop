using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class RecursiveGenerator : MonoBehaviour
{
    [Header("Map Information")]
    [Tooltip("The width of the map. Must be an uneven integer.")]
    [Min(5)] public int Width;
    [Tooltip("The height of the map. Must be an uneven integer.")]
    [Min(5)] public int Height;
    [Header("Ground Tiles")]
    [SerializeField] private string seeed;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject floor;

    private Tile[,] tileMap;
    private System.Random pseudoRandom;
    private Stack<Vector2Int> positions;

    void Start()
    {
        tileMap = new Tile[Width, Height];
        positions = new Stack<Vector2Int>();
        pseudoRandom = new System.Random(string.IsNullOrEmpty(seeed) ? DateTime.Now.Millisecond.GetHashCode() : seeed.GetHashCode());

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                tileMap[x, y] = Tile.Wall;
            }
        }

        int startX = pseudoRandom.Next(0, (Width - 1) / 2) * 2 + 1;
        int startY = pseudoRandom.Next(0, (Height - 1) / 2) * 2 + 1;

        positions.Push(new Vector2Int(startX, startY));

        while (positions.Count > 0)
        {
            List<Vector2Int> directions = GetDirections();

            if (directions.Count > 0)
            {
                Vector2Int thisDirection = directions[pseudoRandom.Next(0, directions.Count)];
                Dig(thisDirection);
            }
            else
            {
                positions.Pop();
            }
        }

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                GameObject toPlace = tileMap[x, y] == Tile.Floor ? floor : wall;
                Instantiate(toPlace, new Vector3Int(x, 0, y), Quaternion.identity, transform);
            }
        }
    }

    private List<Vector2Int> GetDirections()
    {
        List<Vector2Int> possibleDirections = new List<Vector2Int>();
        Vector2Int currPos = positions.Peek();

        for (Direction i = 0; i <= Direction.Left; i++)
        {
            switch (i)
            {
                case Direction.Up:
                    if ((currPos + Vector2Int.up * 2).y < Height - 1
                        && tileMap[(currPos + Vector2Int.up * 2).x, (currPos + Vector2Int.up * 2).y] == Tile.Wall)
                    {
                        possibleDirections.Add(Vector2Int.up);
                    }
                    break;
                case Direction.Right:
                    if ((currPos + Vector2Int.right * 2).x < Width - 1
                        && tileMap[(currPos + Vector2Int.right * 2).x, (currPos + Vector2Int.right * 2).y] == Tile.Wall)
                    {
                        possibleDirections.Add(Vector2Int.right);
                    }
                    break;
                case Direction.Down:
                    if ((currPos + Vector2Int.down * 2).y > 0
                        && tileMap[(currPos + Vector2Int.down * 2).x, (currPos + Vector2Int.down * 2).y] == Tile.Wall)
                    {
                        possibleDirections.Add(Vector2Int.down);
                    }
                    break;
                case Direction.Left:
                    if ((currPos + Vector2Int.left * 2).x > 0
                        && tileMap[(currPos + Vector2Int.left * 2).x, (currPos + Vector2Int.left * 2).y] == Tile.Wall)
                    {
                        possibleDirections.Add(Vector2Int.left);
                    }
                    break;
                default:
                    break;
            }
        }

        return possibleDirections;
    }

    private void Dig(Vector2Int direction)
    {
        Vector2Int current = positions.Peek();

        // NICHT MACHEN IST KACKE
        current += direction;
        tileMap[current.x, current.y] = Tile.Floor;
        current += direction;
        tileMap[current.x, current.y] = Tile.Floor;

        positions.Push(current);
    }

    private void OnValidate()
    {
        if (Width % 2 == 0) Width++;
        if (Height % 2 == 0) Height++;
    }
}

public enum Tile
{
    Wall,
    Floor,
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left,
}