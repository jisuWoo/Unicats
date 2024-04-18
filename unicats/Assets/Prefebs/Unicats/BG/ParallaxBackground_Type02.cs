using UnityEngine;

public class ParallaxBackground_Type02 : MonoBehaviour
{
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float moveSpeed = 0.1f;
    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Vector2 offset = Vector2.right * moveSpeed * Time.time;
        material.SetTextureOffset("_MainTex", offset);
        material.SetTextureOffset("_BumpMap", offset); // �븻 �� �ؽ�ó�� ������ �������� �����մϴ�.
    }
}
