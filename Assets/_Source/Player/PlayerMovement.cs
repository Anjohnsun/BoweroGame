using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public bool CanMove;

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;

    private PlayerInput _input;
    private Vector2 _direction;

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Awake()
    {
        CanMove = true;
        _input = new PlayerInput();
    }

    private void Update()
    {
        if (CanMove)
        {
            _direction = _input.Player.Move.ReadValue<Vector2>();
            Move(_direction);
            if (_direction.x == 0 && _direction.y == 0 && _rb.velocity.magnitude != 0)
                Stop();
        }
    }

    private void Move(Vector2 direction)
    {
        DOTween.Kill(gameObject);
        _rb.AddForce(new Vector3(direction.x, 0, direction.y) * _speed/10, ForceMode.VelocityChange);
    }

    private void Stop()
    {
        DOTween.To(() => _rb.velocity, (x) => _rb.velocity = x, new Vector3(), 0.1f);
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
