using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Bonus : Bonus
{
    protected override void Handle_Destroy()
    {
        GameObject player = GameObject.Find("Player");
        gameObject.transform.position = new Vector3( player.transform.position.x , player.transform.position.y + 1.5f, player.transform.position.z);
        gameObject.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        gameObject.transform.parent = player.transform;
    }

    protected override void Bonus_Effect(PlayerController player)
    {
        IncreaseSpeed(player);
    }

    private void IncreaseSpeed(PlayerController player)
    {
        player.player_speed *= 2;
        StartCoroutine(DeacreaseSpeed(player));
    }

    private IEnumerator DeacreaseSpeed(PlayerController player)
    {
        yield return new WaitForSeconds(3);
        player.player_speed /= 2;
        Destroy(gameObject);
    }
}
