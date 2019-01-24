using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public int DistanceAttack;

	public int Speed;

	protected int Health;

	protected bool IsMoving;

	protected Rigidbody2D Rigidbody2D;

	protected Animator Animator;

	protected Transform Player;

	protected SpriteRenderer SpriteRenderer;

	void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
		SpriteRenderer = GetComponent<SpriteRenderer>();

		Player = GameObject.Find("Player").GetComponent<Transform>();
	}

	protected float GetPlayerDistance() => Vector2.Distance(Player.position, transform.position);

	protected void FlipCharacter() => SpriteRenderer.flipX = !SpriteRenderer.flipX;

	protected void InvertSpeed() => Speed *= -1;
}
