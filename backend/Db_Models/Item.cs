using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ChatLink { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IconURL { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Rarity { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int VendorValue { get; set;}
        [Required]
        public List<string> Flags { get; set; }
        [Required]
        public List<string> GameTypes { get; set; }
        [Required]
        public List<string> Restrictions { get; set; }

        public int? ArmorId { get; set; }
        public Armor Armor { get; set; }

        public int? BackItemId { get; set; }
        public BackItem BackItem { get; set; }

        public int? ConsumableId { get; set; }
        public Consumable Consumable { get; set; }

        public int? ContainerId { get; set; }
        public Container Container { get; set; }

        public int? GatheringToolId { get; set; }
        public GatheringTool GatheringTool {get; set;}

        public int? GizmoId { get; set; }
        public Gizmo Gizmo { get; set; }

        public int? MiniatureId { get; set; }
        public Miniature Miniature { get; set; }

        public int? SalvageKitId { get; set; }
        public SalvageKit SalvageKit { get; set; }

        public int? SkinId { get; set; }
        public Skin Skin { get; set; }

        public int? TrinketId { get; set; }
        public Trinket Trinket { get; set; }

        public int? UpgradeComponentId { get; set; }
        public UpgradeComponent UpgradeComponent { get; set; }

        public int? WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}
