using Code.Interfaces.Models;

namespace Code.Models
{
    internal sealed class AmmoModel: IAmmoModel
    {
        public float MaxAmmo { get; }
        public float CurrentAmmo { get; set; }

        public AmmoModel(float maxAmmo)
        {
            MaxAmmo = maxAmmo;
            CurrentAmmo = MaxAmmo;
        }
    }
}