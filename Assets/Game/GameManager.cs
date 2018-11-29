using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    private bool _isRecording = true;
    private bool _isPaused = false;
    private float _fixedDeltaTime;

    public bool IsRecording
    {
        get { return _isRecording; }
    }


    private void Start()
    {
        _fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            _isRecording = false;
        }
        else
        {
            _isRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
    }

    private void TogglePauseGame()
    {
        if (!_isPaused)
        {
            _isPaused = true;

            Time.timeScale = 0f;
            Time.fixedDeltaTime = 1f;
        }
        else
        {
            _isPaused = false;

            Time.timeScale = 1f;
            Time.fixedDeltaTime = _fixedDeltaTime;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        _isPaused = pause;
    }
}