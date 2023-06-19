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
        newQuaternion.Set(0.500087261f, 0.500087261f, 0.499912739f, -0.499912739f);
        transform.rotation = newQuaternion;

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);


        lookingLeft = true;
    }
    public void LookRight()
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(-0.500087261f, 0.500087261f, 0.499912739f, 0.499912739f);
        transform.rotation = newQuaternion;

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90);
        lookingLeft = false;
    }
    public void IdleRotation()
    {
        if(!lookingLeft)
        {
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(-0.248887718f, 0.661956489f, 0.661725163f, 0.248974666f);
            transform.rotation = newQuaternion;
        }
        else
        {
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(0.249009162f, 0.661811531f, 0.661811531f, -0.249009162f);
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
