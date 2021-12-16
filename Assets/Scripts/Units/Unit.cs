[System.Serializable]
public class Unit
{
    // Private attributes
    private string _name;
    private UnitLevel _level;
    private float _productionRatePerSecond;
    private float _currentProduction;
    private int _maxProduction;

    // Public/Protected/Private attributes
    public string Name
    {
        get { return this._name; }
        set { this._name = value; }
    }

    public UnitLevel Level
    {
        get { return this._level; }
        set { this._level = value; }
    }

    public float ProductionRatePerSecond
    {
        get { return this._productionRatePerSecond; }
        set { this._productionRatePerSecond = value; }
    }

    public float CurrentProduction
    {
        get { return this._currentProduction; }
        set
        {
            if (value >= this.MaxProduction)
            {
                this._currentProduction = this.MaxProduction; // avoid something like 15/10
            }
            else
            {
                this._currentProduction = value;
            }
        }
    }

    public int MaxProduction
    {
        get { return this._maxProduction; }
        set
        {
            this._maxProduction = value;

            if (this._maxProduction <= this.CurrentProduction)
            {
                this.CurrentProduction = value; // avoid something like 15/10
            }
        }
    }

    // Public methods
    public void Produce()
    {
        this.CurrentProduction += this.ProductionRatePerSecond * 1;
    }

    public string ToStringProductionRate()
    {
        return this.ProductionRatePerSecond + "/s";
    }

    public string ToStringProduction()
    {
        return this.CurrentProduction + "/" + this.MaxProduction;
    }
}
