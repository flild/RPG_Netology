using RPG.Units.Extensions;
using UnityEngine;

public class UnitStats:MonoBehaviour
{
    [Range(0, 10)] public float moveSpeed;
    [Range(0, 15)] public float SprintSpeed;
    [Range(0, 20)] public float MaxSpeed;
    [Range(0, 10)] public float rotateSpeed;
    [Range(0, 100)] public float Currenthealth;
    [Range(0, 100)] public float MaxHealth;
    [Range(0, 10)] public float jumpHight;

    public SideType side;
    public string unitName;
    private void Start()
    {
        MaxHealth = Currenthealth;
    }

}
