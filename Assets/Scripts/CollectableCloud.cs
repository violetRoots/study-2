using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableCloud : MonoBehaviour
{
    public float rainPoints = 5.0f;

    [SerializeField] private float scaleDuartion = 0.1f;
    [SerializeField] private Collider cloudCollider;

    public void OnCollectHandler()
    {
        cloudCollider.enabled = false;
        transform.DOScale(Vector3.zero, scaleDuartion).OnComplete(() => Destroy(gameObject));
    }
}
