using System.Collections;
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

	public void TakeDamage(int damage)
	{
		Health -= damage;

		StartCoroutine(DamageColorChange());

		if (Health < 1)
		{
			this.Animator.SetBool("IsDead", true);

			Destroy(gameObject, 0.8f);
		}
	}

	protected void FlipCharacter() => SpriteRenderer.flipX = !SpriteRenderer.flipX;

	protected void InvertSpeed() => Speed *= -1;

	private IEnumerator DamageColorChange()
	{
		SpriteRenderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		SpriteRenderer.color = Color.white;
	}

	private void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
		SpriteRenderer = GetComponent<SpriteRenderer>();

		Player = GameObject.Find("Player").GetComponent<Transform>();
	}

	protected float GetPlayerDistance() => Vector2.Distance(Player.position, transform.position);
}
