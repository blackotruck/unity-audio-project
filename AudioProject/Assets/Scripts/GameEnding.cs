using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    bool _IsPlayerAtExit = false;
    bool _IsPlayerCaught = false;
    float _Timer;

    public int _Lives = 3;



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
            EndLevel(exitBackgroundImageCanvasGroup, false);
        } 
        else if (_IsPlayerCaught)
        {
            if( _Lives == 0)
            {
                EndLevel(caughtBackgroundImageCanvasGroup, true);
            } else {
                ResetPlayerPosition();
            }
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        _Timer += Time.deltaTime;
        imageCanvasGroup.alpha = _Timer / fadeDuration;

        if (_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            } 
            else
            {
                Application.Quit();
            }
        }
    }

    public void CaughtPlayer()
    {
        _IsPlayerCaught = true;
        _Lives -= 1;
    }

    void ResetPlayerPosition()
    {
        _IsPlayerCaught = false;
        Rigidbody playerRb = player.gameObject.GetComponent<Rigidbody>();
        Quaternion startRotation = Quaternion.LookRotation(Vector3.forward);
        Vector3 startPosition = new Vector3(-9.8f, 0f, -3.2f);
        player.transform.position = startPosition;
        playerRb.MovePosition(startPosition);
        playerRb.MoveRotation(startRotation);
    }
}
