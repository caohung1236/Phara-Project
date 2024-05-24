using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCondition : OurMonoBehaviour
{
    [SerializeField] private int slimeCount = 0;
    [SerializeField] string nextLevel;

    void Update()
    {
        if (slimeCount == 2)
        {
            LevelChanger.Instance.NextLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            slimeCount++;
            Destroy(other.gameObject);
        }
    }
}
