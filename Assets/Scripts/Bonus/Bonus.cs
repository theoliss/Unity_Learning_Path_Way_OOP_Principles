using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected abstract void Bonus_Effect(PlayerController other);
    protected abstract void Handle_Destroy();

    protected BonusSpawnManager bonusSpawnManager;

    void Start()
    {
        bonusSpawnManager = GameObject.Find("BonusSpawnManager").GetComponent<BonusSpawnManager>();

        SetStartingHigh();
    }

    protected virtual void SetStartingHigh()
    {
        transform.position = new Vector3(transform.position.x, 1.0f ,transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Bonus_Effect(other.gameObject.GetComponent<PlayerController>());
            Handle_Destroy();
            bonusSpawnManager.numberOfBonusOnScene -= 1;
        }
    }
}
