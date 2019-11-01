using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool _IsPlayerAtExit = false;
    float _Timer;

    void OnTriggerEnter( Collider other)
    {
        if (other.gameObject == player)
        {
            _IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        if (_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        _Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = _Timer / fadeDuration;

        if (_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
