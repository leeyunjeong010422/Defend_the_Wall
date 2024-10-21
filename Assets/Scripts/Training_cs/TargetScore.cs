using UnityEngine;

public class TargetScore : MonoBehaviour
{
    [SerializeField] float maxDistance = 10; //점수가 10~6 총 다섯개라 10으로 해둠
    [SerializeField] int maxScore = 10;

    public int CalculateScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(transform.position, hitPoint); //충돌 지점과 과녁 중심 사이 거리 계산
        //그냥 distance로 하니까 10,9,8 밖에 안 나와서 2를 곱해줌
        int score = Mathf.Clamp(maxScore - Mathf.FloorToInt((2 * distance / maxDistance) * maxScore), 0, maxScore);

        ScoreManager.Instance.UpdateScore(score);

        return score;
    }
}
