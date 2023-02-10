using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopUpEffect : MonoBehaviour
{
    [SerializeField] private Image popUpPanel;
    [SerializeField] private float effectValue = 0.5f;
    [SerializeField] private float duration = 0.5f;
    
    private void Start()
    {
        PlayerRespawn.playerDeathEvent.AddListener(ClosePopUP);
        PlayerRespawn.playerRespawnEvent.AddListener(Reset);

        popUpPanel.gameObject.SetActive(false);
    }

    public void ClosePopUP()
    {
        popUpPanel.gameObject.SetActive(true);
        popUpPanel.DOFade(0f, duration);
    }

    public void Reset()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        var tempColor = popUpPanel.color;
        tempColor.a = 0.5f;
        popUpPanel.color = tempColor;

        popUpPanel.gameObject.SetActive(false);
    }
}
