using System;
using Game.Constants;
using Game.Data;
using UnityEngine;

namespace Game.Components.Upgrades
{
    public sealed class ShuttleDrillUpgradeImproved : Upgrade
    {
        public override string Icon
		{
			get
			{
				return "Obj/Upgrades/ShuttleDrillUpgradeImproved";
			}
		}

		public override string Title
		{
			get
			{
				return "Improved Shuttle Drill Upgrade";
			}
		}

		public override string UpgradeId
		{
			get
			{
				return "ShuttleDrillImproved";
			}
		}

		public override string MatTypeId
		{
			get
			{
				return "ShuttleDrillUpgradeImproved";
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
			Upgrade.Add("ShuttleDrillImproved", new ShuttleDrillUpgradeImproved());
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
				shuttleComp.AddMiningPower(100);
			}
		}

		public override void OnUninstall(Entity entity)
		{
			Tile tile = entity as Tile;
			ShuttleComp shuttleComp;
			if (tile != null && tile.TryGetComponent<ShuttleComp>(out shuttleComp))
			{
				shuttleComp.AddMiningPower(-100);
			}
		}

		public const string Id = "ShuttleDrillImproved";
    }
}