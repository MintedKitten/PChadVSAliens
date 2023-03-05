using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int blade_dmg = 20;
    public int smash_dmg = 30;
	

	public Vector2 bladeOffset;

	public Vector2 smashOffset;

	public float blade_range = 1f;

	public float smash_range = 1f;

	public LayerMask attackMask;

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * bladeOffset.x;
		pos += transform.up * bladeOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, blade_range, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerMovement>().TakeDamage(blade_dmg);
		}
	}

    public void Smash()
	{
		Vector3 pos2 = transform.position;
        pos2 += transform.right * smashOffset.x;
		pos2 += transform.up * smashOffset.y;


		Collider2D colInfo = Physics2D.OverlapCircle(pos2, smash_range, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerMovement>().TakeDamage(smash_dmg);
		}
	}

	
	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * bladeOffset.x;
		pos += transform.up * bladeOffset.y;

		Vector3 pos2 = transform.position;
        pos2 += transform.right * smashOffset.x;
		pos2 += transform.up * smashOffset.y;

		Gizmos.DrawWireSphere(pos, blade_range);
		Gizmos.DrawWireSphere(pos2, smash_range);

	}
}
