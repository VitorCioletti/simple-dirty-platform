using UnityEngine;

public class Player : MonoBehaviour
{
	public float MoveSpeed;

	public float JumpForce;

	public Transform GroundCheck;

	private bool _hitGround;

	private bool _isJumping;

	private Rigidbody2D _rigidBody2D;

	private Animator _animator;

	private SpriteRenderer _spriteRenderer;

	private bool _flipAxis;

	public void FlipCharacter() => _spriteRenderer.flipX = !_spriteRenderer.flipX;

	public void JumpAfterDamaging() => Jump(2, JumpForce);

	private void Awake()
	{
		_rigidBody2D = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		var move = Input.GetAxis("Horizontal");

		_rigidBody2D.velocity = new Vector2(move * MoveSpeed, _rigidBody2D.velocity.y);

		if ((move > 0 && _spriteRenderer.flipX) || (move < 0 && !_spriteRenderer.flipX)) FlipCharacter();

		if (_isJumping) Jump(0, JumpForce);
	}

	private void Jump(float xAxis, float yAxis)
	{
		_rigidBody2D.AddForce(new Vector2(xAxis, yAxis));

		_isJumping = false;
	}

	private void Update()
	{
		_hitGround = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && _hitGround) _isJumping = true;

		if (_animator.gameObject.activeSelf)
		{
			var horizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
			var vertical = Mathf.Abs(Input.GetAxisRaw("Vertical"));

			_animator.SetFloat("HorizontalMovement", horizontal);
			_animator.SetBool("VerticalMovement", _rigidBody2D.velocity.y != 0);
		}
	}
}
