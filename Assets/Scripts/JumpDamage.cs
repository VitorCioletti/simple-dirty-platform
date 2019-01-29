using UnityEngine;

public class JumpDamage : MonoBehaviour
{
	public int Damage { get; set; } = 5;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			var enemy = collision.GetComponent<EnemyController>();

			if (enemy != null)
			{
				enemy.TakeDamage(Damage);

				var player = transform.parent.GetComponent<Player>(); 

				player.JumpAfterDamaging();

				Debug.Log("Jumped");
			}
		}
	}
}
