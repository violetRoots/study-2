using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;
    [SerializeField] private float spawnAngleOffset = 10.0f;

    [SerializeField] private Transform contentContainer;
    [SerializeField] private SpawnInfo cloudSpawnInfo;

    private bool _canSpawn = false;

    private void Awake()
    {
        _canSpawn = true;

        StartCoroutine(SpawnProcess(cloudSpawnInfo));
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        contentContainer.Rotate(-rotationSpeed * Time.smoothDeltaTime, 0, 0);
    }

    private IEnumerator SpawnProcess(SpawnInfo spawnInfo)
    {
        while (_canSpawn)
        {
            var newObj = Instantiate(spawnInfo.spawnObject, contentContainer, true);
            newObj.Rotate(Vector3.up, Mathf.LerpAngle(-spawnAngleOffset, spawnAngleOffset, UnityEngine.Random.value));
            //newObj.Rotate(Vector3.right, contentContainer.rotation.x);

            yield return new WaitForSeconds(spawnInfo.spawnTimeInterval);
        }
    }
}

[Serializable]
public class SpawnInfo
{
    public Transform spawnObject;
    public float spawnTimeInterval;
}
