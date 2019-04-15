using Entitas;
using Entitas.CodeGeneration.Attributes;

[Player]
/// 生命值：受伤消耗，归零死亡。只能靠道具或回存档点回复
/// 精力：攻击时消耗，随时间回复
/// 攻击力：当前攻击力 计算公式：角色本身攻击+主武器攻击+50%副武器攻击
/// 防御力：当前防御值 减伤比例：(防御值*0.06)/(防御值*0.06+1)
/// 强韧：受到高于该值的武器攻击时，动作会被打断。再高后退，更高击飞。
/// 机械抗性：对机械属性攻击的抗性
/// 生物抗性：对生物属性攻击的抗性
/// 异能抗性：对异能属性攻击的抗性
/// 毒抗性：对毒的抗性
public sealed class AbilityComponent : IComponent
{
	public float health;
	public float energy;
	public float attack;
	public float defense;
	public float tough;
	public float mechanicalResistance;
	public float biologicalResistance;
	public float abilitiesResistance;
	public float toxicResistance;


}
