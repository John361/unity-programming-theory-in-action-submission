using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Public attributes
    public static GameDataManager Instance { get; private set; }
    private readonly List<Unit> units = new List<Unit>();

    // Public attributes
    public bool isGameOver = false;

    // Private methods
    private void Awake()
    {
        if (GameDataManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        GameDataManager.Instance = this;
        DontDestroyOnLoad(this.gameObject);
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
