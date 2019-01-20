using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public int Health;

	public int Speed;

	protected Rigidbody2D Rigidbody2D;

	protected Animator Animator;

	protected bool IsMoving;

	protected Transform Player;

	void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
		Player = GameObject.Find("Player").GetComponent<Transform>();
	}

	void Start()
    {
        
    }

    void Update()
    {
        
    }
}
