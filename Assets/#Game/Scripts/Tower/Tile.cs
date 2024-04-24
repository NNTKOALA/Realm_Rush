using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = GetComponent<GridManager>();
        pathfinder = GetComponent<Pathfinder>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);           
            isPlaceable = !isPlaced;
        }
    }
}