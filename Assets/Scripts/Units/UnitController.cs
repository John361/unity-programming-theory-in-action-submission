using System.Collections;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // Private attributes
    public Unit Unit { get; private set; }

    // Private methods
    private void Start()
    {
        this.InitializeUnit();
        StartCoroutine(this.UnitProductionCoroutine());
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("CLICKED");    
    }

    private IEnumerator UnitProductionCoroutine()
    {
        while (!GameDataManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(this.Unit.ProductionRatePerSecond);
            this.Unit.Produce();
        }
    }

    private void InitializeUnit()
    {
        Unit unit = GameDataManager.Instance.GetUnit(this.name);

        if (unit != null)
        {
            this.Unit = unit;
        }
        else
        {
            this.Unit = new Unit
            {
                Name = this.name,
                Level = UnitLevel.Build(1),
                ProductionRatePerSecond = 1.0f,
                CurrentProduction = 0,
                MaxProduction = 10
            };

            GameDataManager.Instance.AddUnit(this.Unit);
        }
    }

    // public methods
    public void OnCollect()
    {
        float production = this.Unit.CurrentProduction;
        GameDataManager.Instance.player.stars += production;

        this.Unit.CurrentProduction = 0;
    }
}
