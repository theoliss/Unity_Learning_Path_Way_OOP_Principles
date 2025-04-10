using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusSpawnManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> bonusPrefabs; 
    [SerializeField] private int bonusNumberCap;
    private float X_boundary;
    private float Z_boundary;

    private int m_numberOfBonusOnScene;

    //ENCAPSULATION
    public int numberOfBonusOnScene
    {
        get {return m_numberOfBonusOnScene;}

        set 
        {
            if(value < 0 )
            {
                Debug.LogError("The Number of bonus on scene can never be negative !" + value);
            }
            else
            {
                m_numberOfBonusOnScene = value;
            }
        }
    }

    // Start is called before the first frame updates
    void Start()
    {   
        numberOfBonusOnScene = 0;
        GameObject ground =  GameObject.Find("Ground");
        BoxCollider groundSpecs = ground.GetComponent<BoxCollider>();
        float groundScaleX =  ground.transform.localScale.x;
        float groundScaleZ =  ground.transform.localScale.z;
        X_boundary = groundSpecs.size.x/2 * groundScaleX;  
        Z_boundary = groundSpecs.size.z/2 * groundScaleZ;
        
        StartCoroutine(SpawnRandomBonus(0));
    }

    private IEnumerator SpawnRandomBonus(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(numberOfBonusOnScene < bonusNumberCap)
        {
            GameObject prefabToInstantiate = bonusPrefabs[Random.Range(0,bonusPrefabs.Count)];
            Vector3 randomPosition = new Vector3(Random.Range(-X_boundary,X_boundary),0,Random.Range(-Z_boundary,Z_boundary));
            Instantiate(prefabToInstantiate, randomPosition, prefabToInstantiate.transform.rotation);
            numberOfBonusOnScene++;
        }
        StartCoroutine(SpawnRandomBonus(2.0f));
    }
}
