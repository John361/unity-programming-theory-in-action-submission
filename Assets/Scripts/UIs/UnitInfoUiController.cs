using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoUiController : MonoBehaviour
{
    // Private attributes
    private TextMeshProUGUI unitName;
    private TextMeshProUGUI unitLevel;
    private TextMeshProUGUI unitProductionRate;
    private TextMeshProUGUI unitCurrentProduction;
    private Button collectButton;
    private UnitController unitController;

    // Private methods
    private void Start()
    {
        this.InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.unitName = GameObject.Find("UnitName").GetComponent<TextMeshProUGUI>();
        this.unitLevel = GameObject.Find("UnitLevel").GetComponent<TextMeshProUGUI>();
        this.unitProductionRate = GameObject.Find("UnitProductionRate").GetComponent<TextMeshProUGUI>();
        this.unitCurrentProduction = GameObject.Find("UnitCurrentProduction").GetComponent<TextMeshProUGUI>();
        this.collectButton = GameObject.Find("CollectButton").GetComponent<Button>();

        this.collectButton.onClick.AddListener(this.OnCollectButtonClicked);
    }

    private void OnCollectButtonClicked()
    {
        this.unitController.OnCollect();
        this.SetInfo();
    }

    private void SetInfo()
    {
        Unit unit = this.unitController.Unit;

        this.unitName.text = "Unit name: " + unit.Name;
        this.unitLevel.text = "Unit level: " + unit.Level;
        this.unitProductionRate.text = "Production rate: " + unit.ToStringProductionRate();
        this.unitCurrentProduction.text = "Current production: " + unit.ToStringProduction();
    }

    // Public methods
    public void Show(UnitController unitController)
    {
        this.unitController = unitController;
        this.SetInfo();

        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.unitController = null;
        this.gameObject.SetActive(false);
    }
}
