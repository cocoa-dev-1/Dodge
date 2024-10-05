using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float defaultCoolTime = 1.0f;
    public float DefaultCoolTime => defaultCoolTime;

    private float currentCoolTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.AddUpdateListener(OnUpdate);
    }

    private void OnUpdate(object sender, System.EventArgs e)
    {
        if (currentCoolTime <= 0.0f)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Vector3 direction = PlayerManager.Instance.Position - spawnPosition;

            BMovement bullet = PoolManager.Instance.GetOne<BMovement>("Bullet");
            bullet.transform.position = new Vector3(spawnPosition.x, 1.0f, spawnPosition.z);
            bullet.Move(new Vector3(direction.x, 0.0f, direction.z));

            currentCoolTime = defaultCoolTime;
        }
        else
        {
            currentCoolTime -= Time.deltaTime;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float value = Random.Range(-23.0f, 23.0f);
        float value2 = Random.Range(0, 2) == 0 ? 23.0f : -23.0f;

        return Random.Range(0, 2) == 0 ? new Vector3(value, 0.0f, value2) : new Vector3(value2, 0.0f, value);
    }
}
