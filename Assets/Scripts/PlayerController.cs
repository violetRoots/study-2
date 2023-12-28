using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out CollectableCloud collectableCloud)) return;

        GameManager.instance.AddRainPoints(collectableCloud.rainPoints);
        collectableCloud.OnCollectHandler();
    }
}
