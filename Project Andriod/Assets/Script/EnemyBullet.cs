using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] float destroyTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
