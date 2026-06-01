using UnityEngine;
using UnityEngine.Tilemaps;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }
    [field: SerializeField]
    public GameObject TurretPrefab { get; set; }
    [field: SerializeField]
    public PlayerController Controller { get; private set; }


    void OnEnable()
    {
        Controller.InfoLabel.text = "Select a Tile";
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        Controller.InfoLabel.text = "Click 'Build' To Place A Turret";
        if (TargetGrid == null)
        {
            return;
        }
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(HandleTileExited);
            tile.OnCursorClicked.AddListener(SpawnTurret);
        }
    }
    public void SpawnTurret(TileController tileController)
    {
        if (tileController.IsOccupied) { return ;}
        if (CanSpawn(tileController))
        {
            GameObject newTurret = Instantiate(TurretPrefab, Controller.transform);
            newTurret.transform.position = tileController.transform.position;
            tileController.IsOccupied = true;
            Controller.Gold -= 50;
            gameObject.SetActive(false);
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }

    public bool CanSpawn(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            return false;
        }

        if (Controller.Gold < 50)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Unable To Build Here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Insufficient Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }

    public void HandleTileExited(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }

}
