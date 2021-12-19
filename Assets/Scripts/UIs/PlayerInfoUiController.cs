using TMPro;
using System.Collections;
using UnityEngine;

public class PlayerInfoUiController : MonoBehaviour
{
    // Private attributes
    private TextMeshProUGUI playerStars;

    // Private methods
    private void Start()
    {
        this.playerStars = GameObject.Find("PlayerStars").GetComponent<TextMeshProUGUI>();
        StartCoroutine(this.GetPlayerInfoCoroutine());
    }

    private IEnumerator GetPlayerInfoCoroutine()
    {
        while (!GameDataManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(1);
            this.SetPlayerInfo();
        }

        if (GameDataManager.Instance.isGameOver)
        {
            StopCoroutine(this.GetPlayerInfoCoroutine());
        }
    }

    private void SetPlayerInfo()
    {
        float stars = GameDataManager.Instance.player.stars;
        this.playerStars.text = "Stars: " + stars;
    }
}
