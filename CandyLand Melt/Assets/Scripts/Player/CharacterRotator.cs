using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] bool lookingLeftAtStart;
    [SerializeField] private bool constantRotation;
    [SerializeField] private Vector3 rotationSpeedAndDirection;
    private bool lookingLeft;
    float rotationValue;
    void Start()
    {
        lookingLeft = lookingLeftAtStart;
    }
    public void LookLeft()
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 1, 0, 0);
        transform.rotation = newQuaternion;
        lookingLeft = true;
    }
    public void LookRight()
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 0, 0, 1);
        transform.rotation = newQuaternion;
        lookingLeft = false;
    }
    public void IdleRotation()
    {
        if(!lookingLeft)
        {
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(0, 0, 0, 1);
            transform.rotation = newQuaternion;
        }
        else
        {
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(0, 1, 0, 0);
            transform.rotation = newQuaternion;
        }
    }
    public bool GetLookingLeft()
    {
        return lookingLeft;
    }
    private void RotateInDirection()
    {
        transform.Rotate(rotationSpeedAndDirection.x * Time.deltaTime, rotationSpeedAndDirection.y * Time.deltaTime, rotationSpeedAndDirection.z * Time.deltaTime);
    }
    private void Update()
    {
        if (constantRotation)
            RotateInDirection();
    }
}
