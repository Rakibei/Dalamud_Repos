using ECommons;
using ECommons.DalamudServices;
using ECommons.GameHelpers;
using ECommons.Schedulers;
using Splatoon.SplatoonScripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatoonScriptsOfficial.Duties.Dawntrail;
public class M5N_Night_Fever : SplatoonScript
{
    public override HashSet<uint>? ValidTerritories { get; } = [1256];
    public override Metadata? Metadata => new(1, "Rakibei");
    uint RightCleave = 42764;
    uint LeftCleave = 42765;

    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBED) as Frogtourage1;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBEC) as Frogtourage2;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBEB) as Frogtourage3;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBEA) as Frogtourage4;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBE9) as Frogtourage5;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBE8) as Frogtourage6;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBE7) as Frogtourage7;
    IBattleNpc? Frogtourage => Svc.Objects.FirstOrDefault(x => x is IBattleNpc b && b.ObjectId == 0x4000EBE6) as Frogtourage8;

    public override void OnSetup()
    {
        Controller.RegisterElementFromCode("Right", "{\"Name\":\"Right Cleave\",\"type\":2,\"refX\":110.0,\"refY\":80.0,\"offX\":110.0,\"offY\":120.0,\"radius\":10.0,\"fillIntensity\":0.5,\"refActorDataID\":18358,\"refActorRequireCast\":true,\"refActorCastId\":[42757],\"refActorComparisonType\":3,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0}");
        Controller.RegisterElementFromCode("Left", "{\"Name\":\"Left Cleave\",\"type\":2,\"refX\":90.0,\"refY\":80.0,\"offX\":90.0,\"offY\":120.0,\"offZ\":1.9073486E-06,\"radius\":10.0,\"fillIntensity\":0.5,\"refActorDataID\":18358,\"refActorRequireCast\":true,\"refActorCastId\":[42757],\"refActorComparisonType\":3,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0}");
    }

    public override void OnUpdate()
    {
        if (Player.Available)
        {
            Controller.GetRegisteredElements().Each(x => x.Value.Enabled = false);
            if (Player.Object.StatusList.Any(x => x.StatusId == DebuffYellow))
            {
                Controller.GetElementByName("Yellow")!.Enabled = true;
            }
            if (Player.Object.StatusList.Any(x => x.StatusId == DebuffBlue))
            {
                Controller.GetElementByName("Blue")!.Enabled = true;
            }
        }
    }
}