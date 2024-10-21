using UnityEngine;

public class TargetScore : MonoBehaviour
{
    [SerializeField] float maxDistance = 10; //������ 10~6 �� �ټ����� 10���� �ص�
    [SerializeField] int maxScore = 10;

    public int CalculateScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(transform.position, hitPoint); //�浹 ������ ���� �߽� ���� �Ÿ� ���
        //�׳� distance�� �ϴϱ� 10,9,8 �ۿ� �� ���ͼ� 2�� ������
        int score = Mathf.Clamp(maxScore - Mathf.FloorToInt((2 * distance / maxDistance) * maxScore), 0, maxScore);

        ScoreManager.Instance.UpdateScore(score);

        return score;
    }
}
