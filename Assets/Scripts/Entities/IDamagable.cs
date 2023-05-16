
namespace Entities
{
    public interface IDamagable
    {
        bool IsInvincible { get; }
        
        void TakeDamage(float value, IDamageSource source);

        void Kill();
    }
}
