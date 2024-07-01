﻿using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        public static IList<Item> Items;

        public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "B-DAWG Keychain")
                {
                    Items[i].SellIn -= 1;
                }

                switch (Items[i].Name)
                {
                    case "Ring of Cleansening Code"         // Common Items
                    or "Elixir of the SOLID":
                        UpdateQualityCommonItems(i);
                        break;
                    case "Good Wine":                       // Wine Items
                        UpdateQualityWineItems(i);
                        break;
                    case "B-DAWG Keychain":                 // Legendary Items
                        break;
                    case "Backstage passes for Re:factor"   // BackStage Pass Items
                    or "Backstage passes for HAXX":
                        UpdateQualityBackStagePassItems(i);
                        break;
                    case "Duplicate Code"                   // Smelly Items
                    or "Long Methods"
                    or "Ugly Variable Names":
                        UpdateQualitySmellyItems(i);
                        break;
                }

                /*if (Items[i].Name != "B-DAWG Keychain")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].Name != "Good Wine" 
                    && Items[i].Name != "Backstage passes for Re:factor"
                    && Items[i].Name != "Backstage passes for HAXX")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "B-DAWG Keychain")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }

                        if ((Items[i].Name == "Duplicate Code"
                        || Items[i].Name == "Long Methods"
                        || Items[i].Name == "Ugly Variable Names")
                        && Items[i].Quality > 0) //Faulty, can go negative.
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes for Re:factor"
                        || Items[i].Name == "Backstage passes for HAXX")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Good Wine")
                    {
                        if (Items[i].Name != "Backstage passes for Re:factor"
                            && Items[i].Name != "Backstage passes for HAXX")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "B-DAWG Keychain")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }

                                if ((Items[i].Name == "Duplicate Code"
                                || Items[i].Name == "Long Methods"
                                || Items[i].Name == "Ugly Variable Names")
                                && Items[i].Quality > 0)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }*/
            }
        }

        private static void UpdateQualityCommonItems(int i)
        {
            if (Items[i].SellIn < 0)
            {
                Items[i].Quality = Math.Max(0, Items[i].Quality - 2);
            }
            else
            {
                Items[i].Quality = Math.Max(0, Items[i].Quality - 1);
            }
        }
        private static void UpdateQualityWineItems(int i)
        {
            Items[i].Quality = Math.Min(50, Items[i].Quality + 1);
        }
        private static void UpdateQualityBackStagePassItems(int i)
        {
            if (Items[i].SellIn < 0)
            {
                Items[i].Quality -= Items[i].Quality;
            }
            else if (Items[i].SellIn <= 5
            && Items[i].SellIn >= 0)
            {
                Items[i].Quality = Math.Min(50, Items[i].Quality + 3);
            }
            else if (Items[i].SellIn <= 10
            && Items[i].SellIn > 5)
            {
                Items[i].Quality = Math.Min(50, Items[i].Quality + 2);
            }
        }
        private static void UpdateQualitySmellyItems(int i)
        {
            if (Items[i].SellIn < 0)
            {
                Items[i].Quality = Math.Max(0, Items[i].Quality - 4);
            }
            else
            {
                Items[i].Quality = Math.Max(0, Items[i].Quality - 2);
            }
        }
    }
}
