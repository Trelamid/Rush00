[System.Serializable]
public class Items
{
    public enum WeaponType
    {
        Null,
        Uzi,
        Shotgun,
        Saber,
        RocketLauncher,
        Magnum,
        Cricket,
        MachineGun
    }

    public WeaponType weaponType;
}