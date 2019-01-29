using UnityEngine;

public class TerrestrialEnemy : EnemyController
{
    void Start() => Health = 10;

    void Update()
    {
		var distance = GetPlayerDistance();

		IsMoving = distance <= DistanceAttack;

		if (IsMoving)
		{
			if ((Player.position.x > transform.position.x && !SpriteRenderer.flipX) ||
				(Player.position.x < transform.position.x && SpriteRenderer.flipX))
			{
				FlipCharacter();
				InvertSpeed();
			}
		}
    }

	private void FixedUpdate() => Rigidbody2D.velocity = new Vector2(IsMoving ? Speed : 0, Rigidbody2D.velocity.y);
}