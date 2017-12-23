using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using Verse.AI;

namespace PrisonExpansion
{
    // JobDriver_Wear
    public class JobGiver_TakeFromLocker : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            //if (pawn.outfits == null)
            //{
            //    Log.ErrorOnce(pawn + " tried to run JobGiver_TakeFromLocker without an OutfitTracker", 5643897);
            //    return null;
            //}
            if (!pawn.IsPrisoner)
            {
                Log.ErrorOnce("Non-prisoner " + pawn + " tried to take from locker.", 764323);
                return null;
            }

            if (Find.TickManager.TicksGame < pawn.mindState.nextApparelOptimizeTick)
            {
                return null;
            }

            //Outfit currentOutfit = pawn.outfits.CurrentOutfit;
            List<Apparel> wornApparel = pawn.apparel.WornApparel;

            Thing thing = null;
            float num = 0f;
            List<Thing> list = FindItemToWear(pawn);
            if (list.Count == 0)
            {
                SetNextOptimizeTick(pawn);
                return null;
            }
            var neededWarmth = PawnApparelGenerator.CalculateNeededWarmth(pawn, pawn.Map.Tile, GenLocalDate.Twelfth(pawn));
            for (int j = 0; j < list.Count; j++)
            {
                Apparel apparel = (Apparel)list[j];
                if (apparel.Map.slotGroupManager.SlotGroupAt(apparel.Position) != null)
                {
                    float num2 = JobGiver_OptimizeApparel.ApparelScoreGain(pawn, apparel);

                    if (num2 >= 0.05f && num2 >= num)
                    {
                        if (ApparelUtility.HasPartsToWear(pawn, apparel.def))
                        {
                            if (pawn.CanReserveAndReach(apparel, PathEndMode.OnCell, pawn.NormalMaxDanger(), 1, -1, null, false))
                            {
                                thing = apparel;
                                num = num2;
                            }
                        }
                    }
                }
            }
            if (thing == null)
            {
                SetNextOptimizeTick(pawn);
                return null;
            }
            return new Job(JobDefOf.Wear, thing);
        }

        private static void SetNextOptimizeTick(Pawn pawn)
        {
            pawn.mindState.nextApparelOptimizeTick = Find.TickManager.TicksGame + UnityEngine.Random.Range(6000, 9000);
        }

        private static List<Thing> FindItemToWear(Pawn pawn)
        {
            List<Thing> list = pawn.Map.listerThings.ThingsInGroup(ThingRequestGroup.Apparel);
            for (int i = 0; i < list.Count; i++)
            {
				if(list[i].StoringBuilding() == null || list[i].StoringBuilding().def != PEDefOf.PrisonExpansion_Locker)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }
    }
}
