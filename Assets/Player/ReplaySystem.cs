using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int BUFFER_FRAMES = 1000;
    private MyKeyFrame[] _keyFrames = new MyKeyFrame[BUFFER_FRAMES];
    private int _currentFrame;

    private Rigidbody _rigidBody;
    private GameManager _gameManager;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (_gameManager.IsRecording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }

    private void PlayBack()
    {
        _rigidBody.isKinematic = true;

        //int frame = Time.frameCount % BUFFER_FRAMES;
        int frame = _currentFrame;
        _currentFrame = Time.frameCount % BUFFER_FRAMES;

        transform.position = _keyFrames[frame].Position;
        transform.rotation = _keyFrames[frame].Rotation;
    }

    private void Record()
    {
        _rigidBody.isKinematic = false;

        int frame = Time.frameCount % BUFFER_FRAMES;
        _currentFrame = frame;

        float time = Time.time;

        _keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, position and rotation
/// </summary>
public struct MyKeyFrame
{
    private float _frameTime;
    private Vector3 _position;
    private Quaternion _rotation;


    public MyKeyFrame(float frameTime, Vector3 position, Quaternion rotation)
    {
        _frameTime = frameTime;
        _position = position;
        _rotation = rotation;
    }


    public float FrameTime
    {
        get { return _frameTime; }
    }

    public Vector3 Position
    {
        get { return _position; }
    }

    public Quaternion Rotation
    {
        get { return _rotation; }
    }
}