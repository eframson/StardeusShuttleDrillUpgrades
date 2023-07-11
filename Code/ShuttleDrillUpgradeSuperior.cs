using System;
using Game.Constants;
using Game.Data;
using UnityEngine;

namespace Game.Components.Upgrades
{
    public sealed class ShuttleDrillUpgradeSuperior : Upgrade
    {
        public override string Icon
		{
			get
			{
				return "Obj/Upgrades/ShuttleDrillUpgradeSuperior";
			}
		}

		public override string Title
		{
			get
			{
				return "Superior Shuttle Drill Upgrade";
			}
		}

		public override string UpgradeId
		{
			get
			{
				return "ShuttleDrillSuperior";
			}
		}

		public override string MatTypeId
		{
			get
			{
				return "ShuttleDrillUpgradeSuperior";
			}
		}

		public override int InstallDifficulty
		{
			get
			{
				return 1;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Register()
		{
			Upgrade.Add("ShuttleDrillSuperior", new ShuttleDrillUpgradeSuperior());
		}

		public override bool IsCompatibleWith(Entity entity)
		{
			return entity.HasComponent<ShuttleComp>();
		}

		public override void OnInstall(Entity entity)
		{
			Tile tile = entity as Tile;
			ShuttleComp shuttleComp;
			if (tile != null && tile.TryGetComponent<ShuttleComp>(out shuttleComp))
			{
				shuttleComp.AddMiningPower(300);
			}
		}

		public override void OnUninstall(Entity entity)
		{
			Tile tile = entity as Tile;
			ShuttleComp shuttleComp;
			if (tile != null && tile.TryGetComponent<ShuttleComp>(out shuttleComp))
			{
				shuttleComp.AddMiningPower(-300);
			}
		}

		public const string Id = "ShuttleDrillSuperior";
    }
}