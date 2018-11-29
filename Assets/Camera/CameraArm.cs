using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraArm : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 2f;

    private GameObject _player;
    private Vector3 _armRotation;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _armRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        _armRotation.y += CrossPlatformInputManager.GetAxis("RSHorizontal") * panSpeed;
        _armRotation.x += CrossPlatformInputManager.GetAxis("RSVertical") * panSpeed;

        gameObject.transform.position = _player.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(_armRotation);
    }
}