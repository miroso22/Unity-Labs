using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    private const int HorizontalSpeed = 15;
    public int jumpSpeed = 20;
    public float gravityMultiplier = 0.02f;

    private IAirState _airState;
    private CharacterController _controller;
    private Vector3 _movement;
    private Text _textField;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _textField = GameObject.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        _movement.x = 0;
        if (Input.GetKey("a")) _movement.x = -HorizontalSpeed;
        if (Input.GetKey("d")) _movement.x = HorizontalSpeed;

        CheckAirState();
        _movement = _airState.GetMovement(_movement);
        _controller.Move(_movement * Time.deltaTime);
    }

    private void CheckAirState()
    {
        if (_controller.isGrounded)
        {
            _airState = new IAirState.Grounded(this);
            _textField.text = "Grounded";
        }
        else
        {
            _airState = new IAirState.InTheAir(this);
            _textField.text = "In the air";
        }
    }

    private interface IAirState
    {
        public Vector3 GetMovement(Vector3 currentMovement);

        class Grounded : IAirState
        {
            private readonly MoveScript _stateHolder;

            public Grounded(MoveScript stateHolder)
            {
                _stateHolder = stateHolder;
            }

            public Vector3 GetMovement(Vector3 currentMovement)
            {
                return Input.GetKey("w") ? new Vector3(currentMovement.x, _stateHolder.jumpSpeed, 0) : currentMovement;
            }
        }

        class InTheAir : IAirState
        {
            private readonly MoveScript _stateHolder;

            public InTheAir(MoveScript stateHolder)
            {
                _stateHolder = stateHolder;
            }

            public Vector3 GetMovement(Vector3 currentMovement)
            {
                return new Vector3(currentMovement.x,
                    currentMovement.y + Physics.gravity.y * _stateHolder.gravityMultiplier, 0);
            }
        }
    }
}