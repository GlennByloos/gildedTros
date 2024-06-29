using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact] //Allows test runner to see this
        public void GildedTros_UpdateQuality_ReturnItem()
        {
            // Boundary Value Testing

            // Normal Items
            IList<Item> NormalItems = new List<Item>
            { 
                // Quality <= 50 AND Quality > 0
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 1 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 2 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 1, Quality = 25 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 2, Quality = 49 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 6, Quality = 1 },

                // Quality > 50 AND Quality < 0
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 51 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = -1 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 1, Quality = 51 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 2, Quality = 51 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 6, Quality = -1 },

                // Quality == 0
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 0 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 1, Quality = 0 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 2, Quality = 0 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 6, Quality = 0 },

                // Quality == 50
                new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 50 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 1, Quality = 50 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 2, Quality = 50 },
                new Item { Name = "Ring of Cleansening Code", SellIn = 6, Quality = 50 }
            };

            GildedTros appNormal = new GildedTros(NormalItems);
            appNormal.UpdateQuality();

            // Quality <= 50 AND Quality > 0
            Assert.Equal(0, NormalItems[0].Quality);
            Assert.Equal(0, NormalItems[1].Quality);
            Assert.Equal(24, NormalItems[2].Quality);
            Assert.Equal(48, NormalItems[3].Quality);
            Assert.Equal(0, NormalItems[4].Quality);

            // Quality > 50 AND Quality < 0
            /*Assert.Equal(0, NormalItems[5].Quality);
            Assert.Equal(0, NormalItems[6].Quality);
            Assert.Equal(0, NormalItems[7].Quality);
            Assert.Equal(0, NormalItems[8].Quality);
            Assert.Equal(0, NormalItems[9].Quality);*/

            // Quality == 0
            Assert.Equal(0, NormalItems[10].Quality);
            Assert.Equal(0, NormalItems[11].Quality);
            Assert.Equal(0, NormalItems[12].Quality);
            Assert.Equal(0, NormalItems[13].Quality);

            // Quality == 50
            Assert.Equal(48, NormalItems[14].Quality);
            Assert.Equal(49, NormalItems[15].Quality);
            Assert.Equal(49, NormalItems[16].Quality);
            Assert.Equal(49, NormalItems[17].Quality);



            // Good Wine Items
            IList<Item> GoodWineItems = new List<Item>
            { 
                // Quality <= 50 AND Quality > 0
                new Item { Name = "Good Wine", SellIn = 0, Quality = 1 }, // +2 or +1?
                new Item { Name = "Good Wine", SellIn = 0, Quality = 49 },
                new Item { Name = "Good Wine", SellIn = 1, Quality = 25 }, // +2 or +1?
                new Item { Name = "Good Wine", SellIn = 2, Quality = 49 },
                new Item { Name = "Good Wine", SellIn = 6, Quality = 1 },

                // Quality > 50 AND Quality < 0
                new Item { Name = "Good Wine", SellIn = 0, Quality = 51 },
                new Item { Name = "Good Wine", SellIn = 0, Quality = -1 },
                new Item { Name = "Good Wine", SellIn = 1, Quality = 51 },
                new Item { Name = "Good Wine", SellIn = 2, Quality = 51 },
                new Item { Name = "Good Wine", SellIn = 6, Quality = -1 },

                // Quality == 0
                new Item { Name = "Good Wine", SellIn = 0, Quality = 0 }, // +2 or +1?
                new Item { Name = "Good Wine", SellIn = 1, Quality = 0 }, // +2 or +1?
                new Item { Name = "Good Wine", SellIn = 2, Quality = 0 },
                new Item { Name = "Good Wine", SellIn = 6, Quality = 0 },

                // Quality == 50
                new Item { Name = "Good Wine", SellIn = 0, Quality = 50 },
                new Item { Name = "Good Wine", SellIn = 1, Quality = 50 },
                new Item { Name = "Good Wine", SellIn = 2, Quality = 50 },
                new Item { Name = "Good Wine", SellIn = 6, Quality = 50 }
            };

            GildedTros appGoodWine = new GildedTros(GoodWineItems);
            appGoodWine.UpdateQuality();

            // Quality <= 50 AND Quality > 0
            Assert.Equal(3, GoodWineItems[0].Quality); // +2 or +1?
            Assert.Equal(50, GoodWineItems[1].Quality);
            Assert.Equal(26, GoodWineItems[2].Quality); // +2 or +1?
            Assert.Equal(50, GoodWineItems[3].Quality);
            Assert.Equal(2, GoodWineItems[4].Quality);

            // Quality > 50 AND Quality < 0
            /*Assert.Equal(0, GoodWineItems[5].Quality);
            Assert.Equal(0, GoodWineItems[6].Quality);
            Assert.Equal(0, GoodWineItems[7].Quality);
            Assert.Equal(0, GoodWineItems[8].Quality);
            Assert.Equal(0, GoodWineItems[9].Quality);*/

            // Quality == 0 
            Assert.Equal(2, GoodWineItems[10].Quality); // +2 or +1?
            Assert.Equal(1, GoodWineItems[11].Quality); // +2 or +1?
            Assert.Equal(1, GoodWineItems[12].Quality);
            Assert.Equal(1, GoodWineItems[13].Quality);

            // Quality == 50
            Assert.Equal(50, GoodWineItems[14].Quality);
            Assert.Equal(50, GoodWineItems[15].Quality);
            Assert.Equal(50, GoodWineItems[16].Quality);
            Assert.Equal(50, GoodWineItems[17].Quality);



            // Legendary Items
            IList<Item> LegendaryItems = new List<Item>
            { 
                // Quality == 80
                new Item { Name = "B-DAWG Keychain", SellIn = 0, Quality = 80 },
                new Item { Name = "B-DAWG Keychain", SellIn = 1, Quality = 80 },
                new Item { Name = "B-DAWG Keychain", SellIn = 2, Quality = 80 },
                new Item { Name = "B-DAWG Keychain", SellIn = 6, Quality = 80 },

                // Quality > 80 OR Quality < 80
                new Item { Name = "B-DAWG Keychain", SellIn = 0, Quality = 81 },
                new Item { Name = "B-DAWG Keychain", SellIn = 1, Quality = 79 },
                new Item { Name = "B-DAWG Keychain", SellIn = 2, Quality = 81 },
                new Item { Name = "B-DAWG Keychain", SellIn = 6, Quality = 79 },
            };

            GildedTros appLegendary = new GildedTros(LegendaryItems);
            appLegendary.UpdateQuality();

            // Quality <= 50 AND Quality > 0
            Assert.Equal(80, LegendaryItems[0].Quality);
            Assert.Equal(80, LegendaryItems[1].Quality);
            Assert.Equal(80, LegendaryItems[2].Quality);
            Assert.Equal(80, LegendaryItems[3].Quality);

            // Quality > 50 AND Quality < 0
            /*Assert.Equal(0, LegendaryItems[5].Quality);
            Assert.Equal(0, LegendaryItems[6].Quality);
            Assert.Equal(0, LegendaryItems[7].Quality);
            Assert.Equal(0, LegendaryItems[9].Quality);*/



            // BackStagePass Items
            IList<Item> BackStagePassItems = new List<Item>
            { 
                // Quality <= 48 AND Quality > 0 --> max 47 when +3, max 48 when +2 so it only goes till 50.
                new Item { Name = "Backstage passes for Re:factor", SellIn = 1, Quality = 47 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 2, Quality = 0 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 25 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 6, Quality = 47 }, // Error, expected 50 actual 49
                new Item { Name = "Backstage passes for Re:factor", SellIn = 7, Quality = 48 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 25 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 11, Quality = 0 }, // Error, expected 2 actual 1
                new Item { Name = "Backstage passes for Re:factor", SellIn = 12, Quality = 25 }, // +1 or +0?

                // SellIn == -1
                new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 1 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 50 },

                // Quality == 50
                new Item { Name = "Backstage passes for Re:factor", SellIn = 1, Quality = 48 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 2, Quality = 49 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 6, Quality = 50 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 7, Quality = 49 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 11, Quality = 50 },

            };

            GildedTros appBackStagePass = new GildedTros(BackStagePassItems);
            appBackStagePass.UpdateQuality();

            // Quality <= 48 AND Quality > 0
            Assert.Equal(50, BackStagePassItems[0].Quality);
            Assert.Equal(3, BackStagePassItems[1].Quality);
            Assert.Equal(28, BackStagePassItems[2].Quality);
            Assert.Equal(50, BackStagePassItems[3].Quality); // Error, expected 50 actual 49
            Assert.Equal(50, BackStagePassItems[4].Quality);
            Assert.Equal(27, BackStagePassItems[5].Quality);
            Assert.Equal(2, BackStagePassItems[6].Quality); // Error, expected 2 actual 1
            Assert.Equal(26, BackStagePassItems[7].Quality); // +1 or +0?

            // SellIn == -1
            Assert.Equal(0, BackStagePassItems[8].Quality);
            Assert.Equal(0, BackStagePassItems[9].Quality);

            // Quality == 50
            Assert.Equal(50, BackStagePassItems[10].Quality);
            Assert.Equal(50, BackStagePassItems[11].Quality);
            Assert.Equal(50, BackStagePassItems[12].Quality);
            Assert.Equal(50, BackStagePassItems[13].Quality);
            Assert.Equal(50, BackStagePassItems[14].Quality);



            // Smelly Items
            IList<Item> SmellyItems = new List<Item>
            { 
                // Quality <= 50 AND Quality > 0
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 2 },
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 4 },
                new Item { Name = "Duplicate Code", SellIn = 1, Quality = 25 },
                new Item { Name = "Duplicate Code", SellIn = 2, Quality = 49 },
                new Item { Name = "Duplicate Code", SellIn = 6, Quality = 1 },

                // Quality > 50 AND Quality < 0
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 51 },
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = -1 },
                new Item { Name = "Duplicate Code", SellIn = 1, Quality = 51 },
                new Item { Name = "Duplicate Code", SellIn = 2, Quality = 51 },
                new Item { Name = "Duplicate Code", SellIn = 6, Quality = -1 },

                // Quality == 0
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 0 },
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 3 },
                new Item { Name = "Duplicate Code", SellIn = 1, Quality = 0 },
                new Item { Name = "Duplicate Code", SellIn = 1, Quality = 1 },
                new Item { Name = "Duplicate Code", SellIn = 2, Quality = 0 },
                new Item { Name = "Duplicate Code", SellIn = 6, Quality = 0 },

                // Quality == 50
                new Item { Name = "Duplicate Code", SellIn = 0, Quality = 50 },
                new Item { Name = "Duplicate Code", SellIn = 1, Quality = 50 },
                new Item { Name = "Duplicate Code", SellIn = 2, Quality = 50 },
                new Item { Name = "Duplicate Code", SellIn = 6, Quality = 50 }
            };

            GildedTros appSmelly = new GildedTros(SmellyItems);
            appSmelly.UpdateQuality();

            // Quality <= 50 AND Quality > 0
            Assert.Equal(0, SmellyItems[0].Quality);
            Assert.Equal(0, SmellyItems[1].Quality);
            Assert.Equal(23, SmellyItems[2].Quality);
            Assert.Equal(47, SmellyItems[3].Quality);
            Assert.Equal(0, SmellyItems[4].Quality);

            // Quality > 50 AND Quality < 0
            /*Assert.Equal(0, SmellyItems[5].Quality);
            Assert.Equal(0, SmellyItems[6].Quality);
            Assert.Equal(0, SmellyItems[7].Quality);
            Assert.Equal(0, SmellyItems[8].Quality);
            Assert.Equal(0, SmellyItems[9].Quality);*/

            // Quality == 0
            Assert.Equal(0, SmellyItems[10].Quality);
            Assert.Equal(0, SmellyItems[11].Quality);
            Assert.Equal(0, SmellyItems[12].Quality);
            Assert.Equal(0, SmellyItems[13].Quality);
            Assert.Equal(0, SmellyItems[14].Quality);
            Assert.Equal(0, SmellyItems[15].Quality);

            // Quality == 50
            Assert.Equal(46, SmellyItems[16].Quality);
            Assert.Equal(48, SmellyItems[17].Quality);
            Assert.Equal(48, SmellyItems[18].Quality);
            Assert.Equal(48, SmellyItems[19].Quality);
        }
    }
}