using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBulletPool : MonoBehaviour
{
    [System.Serializable]
    public class BulletType
    {
        public string bulletName; //총알 이름 정해서 Fire 함수 사용할 때 사용해야 함
        public GameObject bulletPrefab;
        public int poolSize;
        public List<GameObject> bullets;
    }

    [SerializeField] private List<BulletType> bulletTypes;

    private void Start()
    {
        //각 총알에 대해 풀 생성
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
        //이름에 해당하는 총알 타입 찾기
        BulletType bulletType = bulletTypes.Find(bt => bt.bulletName == bulletName);

        if (bulletType != null)
        {
            //비활성화된 총알 반환
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
