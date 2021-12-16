using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Public static attributes
    public static GameDataManager Instance { get; private set; }

    // Public attributes
    public List<Unit> units = new List<Unit>();
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
}
