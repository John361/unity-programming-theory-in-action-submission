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

    private IEnumerator UnitProductionCoroutine()
    {
        while (true) // TODO: check if game is over
        {
            yield return new WaitForSeconds(this.Unit.ProductionRatePerSecond);
            this.Unit.Produce();
        }
    }

    private void InitializeUnit()
    {
        // TODO: check if there is a file with this unit otherwise create a new one
        this.Unit = new Unit
        {
            Name = this.name,
            Level = UnitLevel.Build(1),
            ProductionRatePerSecond = 1.0f,
            CurrentProduction = 0,
            MaxProduction = 10
        };
    }
}
