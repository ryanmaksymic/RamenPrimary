using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer enemySprite;

    AsyncOperationHandle<Sprite> opHandle;

    public void Start()
    {
        StartCoroutine(LoadEnemySprite());
    }

    private IEnumerator LoadEnemySprite()
    {
        opHandle = Addressables.LoadAssetAsync<Sprite>("bowser");

        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            enemySprite.sprite = opHandle.Result;
        }
    }

    private void OnDestroy()
    {
        Addressables.Release(opHandle);
    }
}
