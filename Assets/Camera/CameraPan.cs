using UnityEngine;

public class CameraPan : MonoBehaviour
{
    private GameObject _player;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        gameObject.transform.LookAt(_player.transform);
    }
}