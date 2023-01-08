using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class Weapon : ScriptableObject
{

    [SerializeField]
    public Bullet BulletPrefab;

    [SerializeField]
    public int BulletCount;
    [SerializeField]
    public float RelaodTime, TimeBetwenShoots;

}
