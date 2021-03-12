using HarmonyLib;
using PulsarPluginLoader;
using PulsarPluginLoader.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using static PulsarPluginLoader.Patches.HarmonyHelpers;

namespace DragonReactor.Items
{
    class ItemPluginManager
    {
        public readonly int VanillaItemMaxType = 0;
        private static ItemPluginManager m_instance = null;
        public readonly List<ItemPlugin> ItemTypes = new List<ItemPlugin>();
        public static ItemPluginManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new ItemPluginManager();
                }
                return m_instance;
            }
        }
        ItemPluginManager()
        {
            VanillaItemMaxType = Enum.GetValues(typeof(EPawnItemType)).Length;
            Logger.Info($"ItemMaxTypeint = {VanillaItemMaxType - 1}");
            foreach (PulsarPlugin plugin in PluginManager.Instance.GetAllPlugins())
            {
                Assembly asm = plugin.GetType().Assembly;
                Type ItemPlugin = typeof(ItemPlugin);
                foreach (Type t in asm.GetTypes())
                {
                    if (ItemPlugin.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        Logger.Info("Loading Item from assembly");
                        ItemPlugin ItemPluginHandler = (ItemPlugin)Activator.CreateInstance(t);
                        GetItemIDsFromName(ItemPluginHandler.Name, out int MainType, out int SubType);
                        if (MainType == -1)
                        {
                            ItemTypes.Add(ItemPluginHandler);
                            GetItemIDsFromName(ItemPluginHandler.Name, out MainType, out SubType);
                            Logger.Info($"Added Item: '{ItemPluginHandler.Name}' with MainTypeID '{MainType}' and SubTypeID {SubType}");
                        }
                        else
                        {
                            Logger.Info($"Could not add Item from {plugin.Name} with the duplicate name of '{ItemPluginHandler.Name}'");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Finds Item type equivilent to given name and returns MainType ID and SubType ID needed to spawn. Returns -1 if couldn't find Item.
        /// </summary>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        public void GetItemIDsFromName(string ItemName, out int MainType, out int SubType)
        {
            MainType = -1;
            SubType = -1;
            for (int i = 0; i < ItemTypes.Count; i++)
            {
                if (ItemTypes[i].Name == ItemName)
                {
                    GetIntsFromIndex(i, out MainType, out SubType);
                    return;
                }
            }
        }
        public void GetIntsFromIndex(int Index, out int MainType, out int SubType)
        {
            if (Index > 63)
            {
                for (int a = 1; Index - 63 * a > 63; a++)
                {
                    if (Index - 63 * a < 63)
                    {
                        MainType = a + VanillaItemMaxType;
                        SubType = Index % 63;
                        Logger.Info($"Ids {MainType}, {SubType}");
                        return;
                    }
                }
            }
            MainType = VanillaItemMaxType;
            SubType = Index;
            Logger.Info($"Ids {MainType}, {SubType}");
            return;
        }
        public static PLPawnItem CreatePawnItem(int Maintype, int Subtype, int level)
        {
            PLPawnItem InItem = null;
            if (Maintype >= Instance.VanillaItemMaxType)
            {
                int MainTypeformodded = (Maintype - Instance.VanillaItemMaxType) * 63 + Subtype;
                Logger.Info($"MainType for modded is {MainTypeformodded}");
                if (MainTypeformodded <= Instance.ItemTypes.Count && MainTypeformodded > -1)
                {
                    Logger.Info("Creating Item from list info");
                    ItemPlugin ItemType = Instance.ItemTypes[MainTypeformodded];
                    InItem = ItemType.PLPawnItem;
                    InItem.Level = level;
                    InItem.SubType = 64 + (MainTypeformodded * 64) + Subtype;
                    Logger.Info($"CreatePawnItem gave item subtype {InItem.SubType}");
                }
            }
            if (InItem == null)
            {
                InItem = PLPawnItem.CreateFromInfo((EPawnItemType)Maintype, Subtype, level);
            }
            return InItem;
        }
        public void GetActualMainAndSubTypesFromSubtype(int InSubType, out int MainType, out int SubType)
        {
            if(InSubType > 63)
            {
                ItemPluginManager.Instance.GetIntsFromIndex(InSubType - 64, out MainType, out SubType);
            }
            else
            {
                Logger.Info("Wrap me in an if statement checking InSubType > 63");
                throw new System.NotImplementedException();
            }
        }
        /*//Change Name, it's not just the specied method. Basically need to find all datablock ussages of UpdateItem and replace the line with this method.
        public void PLNetManSWFHIDALLIHelper(PawnItemDataBlock pawnItemDataBlock, PLPawnInventoryBase classlockerinv, int NetID) 
        {
            if (pawnItemDataBlock.SubType > 63)
            {
                Instance.GetIntsFromIndex(pawnItemDataBlock.SubType - 64, out int MainType, out int SubType);
                //Logger.Info($"GetHash found subtype greater than 63 ({__instance.SubType}). output is {MainType}, {SubType}");
                classlockerinv.UpdateItem(NetID, MainType, SubType, pawnItemDataBlock.Level, -1);
            }
            else
            {
                classlockerinv.UpdateItem(NetID, (int)pawnItemDataBlock.ItemType, pawnItemDataBlock.SubType, pawnItemDataBlock.Level, -1);
            }
        }*/
        /*Dictionary<PLPawnItem, int> MainTypeRegistry = new Dictionary<PLPawnItem, int>();
        /// <summary>
        /// Registers PawnItem with MainType
        /// </summary>
        /// <param name="InPawnItem">PLPawnItem to register</param>
        /// <param name="InMainType">Maintype of PLPawnItem</param>
        void RegisterItem(PLPawnItem InPawnItem, int InMainType)
        {
            if (!MainTypeRegistry.ContainsKey(InPawnItem))
            {
                MainTypeRegistry.Add(InPawnItem, InMainType);
            }
        }
        /// <summary>
        /// Gets Main Item type from registered PawnItem. If pawn item isn't registered/found, returns 31. (ammo clip)
        /// </summary>
        /// <param name="InPawnItem">PLPawnItem To Get Maintype of</param>
        /// <returns>Returns Main Item Type ID from registered item. If PawnItem isn't registered/found, returns PawnIten.PawnItemType as an int</returns>
        public int GetItemMainType(PLPawnItem InPawnItem)
        {
            if (MainTypeRegistry.ContainsKey(InPawnItem))
            {
                return MainTypeRegistry[InPawnItem];
            }
            else
            {
                return (int)InPawnItem.PawnItemType;
            }
        }*/
    }
    /*[HarmonyPatch(typeof(PLNetworkManager), "ServerWaitForHubIDAndLoadLevel")]
    class PLNetManSWFHIDALLIPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence4 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_SubType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_Level")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
            };

            List<CodeInstruction> injectedSequence4 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            return PatchBySequence(instructions, targetSequence4, injectedSequence4, patchMode: PatchMode.REPLACE);
        }
    }*/

    [HarmonyPatch(typeof(PLPawnItem), "GetPawnInfoFromHash")]
    class GetPawnInfoFromHashPatch
    {
        static bool Prefix(int inHash, ref uint actualSlotTypePart, ref uint subTypePart, ref uint levelPart)
        {
            actualSlotTypePart = (uint)(inHash & 63);
            subTypePart = ((uint)inHash >> 6 & 63U);
            levelPart = ((uint)inHash >> 12 & 15U);
            Logger.Info($"GetPawnInfoFromHash returned {actualSlotTypePart}, {subTypePart}, {levelPart}");
            return false;
        }
    }
    [HarmonyPatch(typeof(PLPawnItem), "getHash")]
    class PawnItemGetHash
    {
        static bool Prefix(PLPawnItem __instance, ref uint __result)
        {
            uint num;
            uint num2;
            if (__instance.SubType > 63)
            {
                ItemPluginManager.Instance.GetIntsFromIndex(__instance.SubType - 64, out int MainType, out int SubType);
                num = (uint)(MainType & 63);
                num2 = (uint)((uint)(SubType & 63) << 6);
                Logger.Info($"GetHash found subtype greater than 63 ({__instance.SubType}). output is {MainType}, {SubType}");
            }
            else
            {
                num = (uint)(__instance.PawnItemType & (EPawnItemType)63);
                num2 = (uint)((uint)(__instance.SubType & 63) << 6);
            }
            uint num3 = (uint)((uint)(__instance.Level & 15) << 12);
            __result = (num | num2 | num3);
            return false;
        }
    }
    [HarmonyPatch(typeof(PLPawnItem), "CreatePawnItemFromHash")]
    class CreatePawnItemFromHashPatch
    {
        static bool Prefix(int inHash, ref PLPawnItem __result)
        {
            PLPawnItem.GetPawnInfoFromHash(inHash, out uint inType, out uint inSubType, out uint inLevel);
            /*if((int)inType > 33)
            {
                Logger.Info("making modded item from hash");
            }*/
            __result = ItemPluginManager.CreatePawnItem((int)inType, (int)inSubType, (int)inLevel);
            /*if ((int)inType > 33)
            {
                Logger.Info("should have made modded item from hash");
            }*/
            return false;
        }
    }

    [HarmonyPatch(typeof(PLPawnInventoryBase), "UpdateItem")]
    class UpdateItemPatch
    {
        /*IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Ldarg_2),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
            };

            List<CodeInstruction> injectedSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Ldarg_2),
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Method(typeof(ItemPluginManager), "get_Instance")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(ItemPluginManager), "GetItemMainType"))
            };

            IEnumerable<CodeInstruction> Modified1st = PatchBySequence(instructions, targetSequence1, injectedSequence1, patchMode: PatchMode.REPLACE);

            List<CodeInstruction> targetSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, 0.0005f),
            };

            List<CodeInstruction> injectedSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld, ),
            };

            return PatchBySequence(Modified1st, targetSequence2, injectedSequence2, patchMode: PatchMode.REPLACE);
        }*/
        static bool Prefix(PLPawnInventoryBase __instance, int inNetID, int inType, int inSubType, int inLevel, int inEquipID)
        {
            PLPawnItem itemAtNetID = __instance.GetItemAtNetID(inNetID);
            if (itemAtNetID != null)
            {
                itemAtNetID.EquipID = inEquipID;
                itemAtNetID.Level = inLevel;
                itemAtNetID.SubType = inSubType;
            }
            else
            {
                if(inSubType > 63)
                {
                    ItemPluginManager.Instance.GetActualMainAndSubTypesFromSubtype(inSubType, out inType, out inSubType);
                }
                PLPawnItem plpawnItem = ItemPluginManager.CreatePawnItem(inType, inSubType, inLevel);
                if (plpawnItem != null)
                {
                    plpawnItem.NetID = inNetID;
                    plpawnItem.EquipID = inEquipID;
                    __instance.GetType().GetMethod("AddItem_Internal", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(__instance, new object[] { inNetID, plpawnItem });
                }
            }
            if (PLNetworkManager.Instance.IsInternalBuild)
            {
                Logger.Info("UpdateItem:    player: " + ((__instance.PlayerOwner != null) ? __instance.PlayerOwner.GetPlayerName(false) : "null") + "    equipID: " + inEquipID.ToString());
            }
            if (PLTabMenu.Instance != null)
            {
                PLTabMenu.Instance.ShouldRecreateLocalInventory = true;
            }
            return false;
        }
    }
    /*[HarmonyPatch(typeof(PLSaveGameIO), "SaveToFile")]
    class SaveToFilePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 26),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 26),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_SubType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 26),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_Level")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
            };

            List<CodeInstruction> injectedSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 26),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            IEnumerable<CodeInstruction> Modified1st1 = PatchBySequence(instructions, targetSequence1, injectedSequence1, patchMode: PatchMode.REPLACE);

            List<CodeInstruction> targetSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 27),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 27),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_SubType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 27),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_Level")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
            };

            List<CodeInstruction> injectedSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 27),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            IEnumerable<CodeInstruction> Modified1st2 = PatchBySequence(Modified1st1, targetSequence2, injectedSequence2, patchMode: PatchMode.REPLACE);

            List<CodeInstruction> targetSequence3 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 30),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 30),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_SubType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 30),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_Level")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
            };

            List<CodeInstruction> injectedSequence3 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 30),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            IEnumerable<CodeInstruction> Modified1st3 = PatchBySequence(Modified1st1, targetSequence3, injectedSequence3, patchMode: PatchMode.REPLACE);

            List<CodeInstruction> targetSequence4 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPawnItem), "PawnItemType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_SubType")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "get_Level")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(int) })),
            };

            List<CodeInstruction> injectedSequence4 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 32),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "MyInventory")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnInventoryBase), "get_AllItems")),
                new CodeInstruction(OpCodes.Ldloc_S, 37),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<PLPawnItem>), "get_Item", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            return PatchBySequence(Modified1st3, targetSequence4, injectedSequence4, patchMode: PatchMode.REPLACE);
        }
    }*/
    /*[HarmonyPatch(typeof(PLSaveGameIO), "LoadFromFile")]
    class LoadFromFilePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_S, 24),
                new CodeInstruction(OpCodes.Ldloc_1),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryReader), "ReadInt32")),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PawnItemDataBlock), "ItemType")),
                new CodeInstruction(OpCodes.Ldloc_S, 24),
                new CodeInstruction(OpCodes.Ldloc_1),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryReader), "ReadInt32")),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt), "op_Implicit", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PawnItemDataBlock), "SubType")),
                new CodeInstruction(OpCodes.Ldloc_S, 24),
                new CodeInstruction(OpCodes.Ldloc_1),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryReader), "ReadInt32")),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt), "op_Implicit", new Type[] { typeof(int) })),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PawnItemDataBlock), "Level")),
            };

            List<CodeInstruction> injectedSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 26),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLPawnItem), "getHash")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(System.IO.BinaryWriter), "Write", new Type[] { typeof(uint) })),
            };

            return PatchBySequence(Modified1st3, targetSequence4, injectedSequence4, patchMode: PatchMode.REPLACE);
        }
    }*/
}
