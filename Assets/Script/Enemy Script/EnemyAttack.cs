using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int bite_damage = 10;
    

	public Vector2 bite_offset;

	public float bite_range = 1f;
	public LayerMask attackMask;

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * bite_offset.x;
		pos += transform.up * bite_offset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, bite_range, attackMask);
		if (colInfo != null)
		{
			PlayerMovement.instance.TakeDamage(bite_damage);
		}
	}

    
	
	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * bite_offset.x;
		pos += transform.up * bite_offset.y;

		Gizmos.DrawWireSphere(pos, bite_range);
		

	}
}
