using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Bonus : Bonus
{
    protected override void Handle_Destroy()
    {
        Destroy(gameObject);
    }
    
    protected override void Bonus_Effect(PlayerController player)
    {
        player.canJump = true;
    }

    protected override void SetStartingHigh()
    {
        transform.position = new Vector3(transform.position.x, 3.0f ,transform.position.z);
    }
}
