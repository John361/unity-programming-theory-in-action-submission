using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoUiController : MonoBehaviour
{
    // Private attributes
    public static UnitInfoUiController Instance { get; private set; }
    private TextMeshProUGUI unitName;
    private TextMeshProUGUI unitLevel;
    private TextMeshProUGUI unitProductionRate;
    private TextMeshProUGUI unitCurrentProduction;
    private Button collectButton;
    private UnitController unitController;

    private bool _isActivated;
    private bool IsActivated
    {
        get { return this._isActivated; }
        set
        {
            this._isActivated = value;
            this.gameObject.SetActive(value);

            if (this.IsActivated)
            {
                StartCoroutine(this.GetRealTimeUnitInfoCoroutine());
            }
            else
            {
                StopCoroutine(this.GetRealTimeUnitInfoCoroutine());
            }
        }
    }

    // Private methods
    private void Start()
    {
        this.IsActivated = false;
    }

    private void Awake()
    {
        if (UnitInfoUiController.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        this.InitializeComponents();
        UnitInfoUiController.Instance = this;
        DontDestroyOnLoad(this.gameObject);
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
        this.unitLevel.text = "Unit level: " + unit.Level.Level;
        this.unitProductionRate.text = "Production rate: " + unit.ToStringProductionRate();
        this.unitCurrentProduction.text = "Current production: " + unit.ToStringProduction();
    }

    private IEnumerator GetRealTimeUnitInfoCoroutine()
    {
        while (this.IsActivated)
        {
            yield return new WaitForSeconds(1);
            this.SetInfo();
        }
    }

    // Public methods
    public void Show(UnitController unitController)
    {
        this.IsActivated = true;
        this.unitController = unitController;

        this.SetInfo();
    }

    public void Hide()
    {
        this.unitController = null;
        this.IsActivated = false;
    }
}
