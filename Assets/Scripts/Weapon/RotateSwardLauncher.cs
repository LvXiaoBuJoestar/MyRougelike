using UnityEngine;

public class RotateSwardLauncher : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float rotateSpeed = 150f;
    [SerializeField] float distance = 2f;
    [SerializeField] int count = 2;

    private void OnEnable()
    {
        SetSward(count);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            SetSward(++count);
    }

    void SetSward(int count)
    {
        if(count > transform.childCount)
        {
            for(int i = 0; i < count; i++)
            {
                Transform tf;
                if (i < transform.childCount)
                    tf = transform.GetChild(i);
                else
                    tf = Instantiate(prefab, transform).transform;

                tf.localPosition = Vector3.zero;
                tf.localRotation = Quaternion.identity;

                Vector3 rotateVec = Vector3.forward * 360 * i / count;
                tf.Rotate(rotateVec);
                tf.Translate(Vector3.up * distance, Space.Self);
            }
        }
    }
}
