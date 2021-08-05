using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup menuGroup;

    [SerializeField]
    private CanvasGroup gameEndGroup;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text buttomText;

    public void OnClickPlay()
    {
        menuGroup.DOFade(0f, 0.3f);
        GameManager.Instance.IsPlay = true;

        menuGroup.interactable = false;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameEnd(GameState state)
    {
        gameEndGroup.DOFade(1f, 0.3f);
        gameEndGroup.interactable = true;
        gameEndGroup.blocksRaycasts = true;
        titleText.text = state == GameState.GameOver ? "Game Over" : "Completed level";
        buttomText.text = state == GameState.GameOver ? "Restart" : "Play";
    }

}
