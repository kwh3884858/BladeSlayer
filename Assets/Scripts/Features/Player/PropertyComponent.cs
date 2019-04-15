using Entitas;
using Entitas.CodeGeneration.Attributes;

[Player]
/// <summary>
/// 体力:影响生命值最大值
/// 耐力:影响精力最大值
/// 力量:影响攻击力
/// 敏捷:影响精力回复速度与防御力
/// 智力:影响抗性
/// 机械 
/// 生物 
/// 异能 (依次相克) 克制属性伤害*1.5
/// </summary>
public sealed class PropertyComponent : IComponent
{
	public float strength;
	public float endurance;
	public float power;
	public float agile;
	public float intelligence;
	public float mechanical;
	public float biological;
	public float psionic;

}
