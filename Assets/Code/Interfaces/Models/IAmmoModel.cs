namespace Code.Interfaces.Models
{
    public interface IAmmoModel
    {
        float MaxAmmo { get; }
        float CurrentAmmo { get; set; }
    }
}