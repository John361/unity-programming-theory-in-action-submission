using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Private attributes
    private readonly List<Unit> units = new List<Unit>();

    // Public attributes
    public static GameDataManager Instance { get; private set; }
    public Player player { get; private set; }
    public bool isGameOver = false;

    // Private methods
    private void Awake()
    {
        if (GameDataManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        this.InitializePlayer();
        GameDataManager.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void InitializePlayer()
    {
        // TODO: get from file if exists and use a welcome screen for player name
        this.player = new Player
        {
            name = "Player",
            stars = 0
        };
    }

    // Public methods
    public Unit GetUnit(string name)
    {
        return this.units.Find(u => u.Name == name);
    }

    public void AddUnit(Unit unit)
    {
        if (this.GetUnit(unit.Name) == null)
        {
            this.units.Add(unit);
        }
    }
}
