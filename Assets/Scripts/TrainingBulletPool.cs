using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletPool : MonoBehaviour
{
    [System.Serializable]
    public class BulletType
    {
        public string bulletName; //�Ѿ� �̸� ���ؼ� Fire �Լ� ����� �� ����ؾ� ��
        public GameObject bulletPrefab;
        public int poolSize;
        public List<GameObject> bullets;
    }

    [SerializeField] private List<BulletType> bulletTypes;

    private void Start()
    {
        //�� �Ѿ˿� ���� Ǯ ����
        foreach (BulletType bulletType in bulletTypes)
        {
            bulletType.bullets = new List<GameObject>();

            for (int i = 0; i < bulletType.poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletType.bulletPrefab);
                bullet.SetActive(false);
                bullet.transform.parent = this.transform;
                bulletType.bullets.Add(bullet);
            }
        }
    }

    public GameObject GetBullet(string bulletName)
    {
        //�̸��� �ش��ϴ� �Ѿ� Ÿ�� ã��
        BulletType bulletType = bulletTypes.Find(bt => bt.bulletName == bulletName);

        if (bulletType != null)
        {
            //��Ȱ��ȭ�� �Ѿ� ��ȯ
            foreach (GameObject bullet in bulletType.bullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    bullet.SetActive(true);
                    return bullet;
                }
            }
        }
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
