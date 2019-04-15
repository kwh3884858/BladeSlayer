//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public AbilityComponent ability { get { return (AbilityComponent)GetComponent(PlayerComponentsLookup.Ability); } }
    public bool hasAbility { get { return HasComponent(PlayerComponentsLookup.Ability); } }

    public void AddAbility(float newHealth, float newEnergy, float newAttack, float newDefense, float newTough, float newMechanicalResistance, float newBiologicalResistance, float newAbilitiesResistance, float newToxicResistance) {
        var index = PlayerComponentsLookup.Ability;
        var component = (AbilityComponent)CreateComponent(index, typeof(AbilityComponent));
        component.health = newHealth;
        component.energy = newEnergy;
        component.attack = newAttack;
        component.defense = newDefense;
        component.tough = newTough;
        component.mechanicalResistance = newMechanicalResistance;
        component.biologicalResistance = newBiologicalResistance;
        component.abilitiesResistance = newAbilitiesResistance;
        component.toxicResistance = newToxicResistance;
        AddComponent(index, component);
    }

    public void ReplaceAbility(float newHealth, float newEnergy, float newAttack, float newDefense, float newTough, float newMechanicalResistance, float newBiologicalResistance, float newAbilitiesResistance, float newToxicResistance) {
        var index = PlayerComponentsLookup.Ability;
        var component = (AbilityComponent)CreateComponent(index, typeof(AbilityComponent));
        component.health = newHealth;
        component.energy = newEnergy;
        component.attack = newAttack;
        component.defense = newDefense;
        component.tough = newTough;
        component.mechanicalResistance = newMechanicalResistance;
        component.biologicalResistance = newBiologicalResistance;
        component.abilitiesResistance = newAbilitiesResistance;
        component.toxicResistance = newToxicResistance;
        ReplaceComponent(index, component);
    }

    public void RemoveAbility() {
        RemoveComponent(PlayerComponentsLookup.Ability);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherAbility;

    public static Entitas.IMatcher<PlayerEntity> Ability {
        get {
            if (_matcherAbility == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Ability);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherAbility = matcher;
            }

            return _matcherAbility;
        }
    }
}
