using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Oxide.Core;
using VLB;

namespace Oxide.Plugins
{

	[Info("HealGun", "Wolfleader101", "1.2.0")]
	class HealGun : RustPlugin
	{
		#region Variables

		private PluginConfig config;
		public const string HealgunPerms = "healgun.use";
		

		#endregion
		#region Hooks
		private void Init()
		{
			config = Config.ReadObject<PluginConfig>();
			
			permission.RegisterPermission(HealgunPerms, this);
		}
		
		void OnPlayerAttack(BasePlayer attacker, HitInfo info)
		{
			if (info == null) return;
			if (attacker == null) return;
			if (!permission.UserHasPermission(attacker.UserIDString, HealgunPerms)) return;
			var healgun = info.Weapon.ShortPrefabName;
			if (healgun != config.Healgun) return;
			if (!(info.HitEntity is BasePlayer)) return;
			
			info.damageTypes.ScaleAll(0); // disable damage
			var player = info.HitEntity as BasePlayer;
			player.Heal(config.HealAmount);



		}
		#endregion

		#region Custom Methods

		

		#endregion

		#region Config
		private class PluginConfig
		{
			[JsonProperty("Healgun")] public string Healgun { get; set; }
			[JsonProperty("Heal Amount")] public float HealAmount { get; set; }
		}

		private PluginConfig GetDefaultConfig()
		{
			return new PluginConfig
			{
				Healgun = "nailgun.entity",
				HealAmount = 10f
			};
		}

		protected override void LoadDefaultConfig()
		{
			Config.WriteObject(GetDefaultConfig(), true);
		}

		

		#endregion
	}
}