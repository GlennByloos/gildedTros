using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        public GildedTrosTest()
        {
            GildedTros.Items = new List<Item>();
        }

        public void UpdateQualityTest(string name, int sellIn, int quality, int expectedQuality)
        {
            // Arrange
            GildedTros.Items.Add(new Item { Name = name, SellIn = sellIn, Quality = quality });

            // Act
            GildedTros.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, GildedTros.Items[0].Quality);

            // Clear
            GildedTros.Items.Clear();
        }

        [Theory]
        [InlineData("Ring of Cleansening Code", 0, 1, 0)]
        [InlineData("Ring of Cleansening Code", 0, 2, 0)]
        [InlineData("Ring of Cleansening Code", 1, 25, 24)]
        [InlineData("Ring of Cleansening Code", 2, 49, 48)]
        [InlineData("Ring of Cleansening Code", 6, 1, 0)]
        public void UpdateQuality_CommonItemsBoundaryTesting_Positive(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        /*[Theory]
        [InlineData("Ring of Cleansening Code", 0, 51, 0)]
        [InlineData("Ring of Cleansening Code", 0, -1, 0)]
        [InlineData("Ring of Cleansening Code", 1, 51, 0)]
        [InlineData("Ring of Cleansening Code", 2, 51, 0)]
        [InlineData("Ring of Cleansening Code", 6, -1, 0)]
        public void UpdateQuality_CommonItemsBoundaryTesting_Negative(string name, int sellIn, int quality, int expectedQuality)
        {
           UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }*/

        [Theory]
        [InlineData("Ring of Cleansening Code", 0, 0, 0)]
        [InlineData("Ring of Cleansening Code", 1, 0, 0)]
        [InlineData("Ring of Cleansening Code", 2, 0, 0)]
        [InlineData("Ring of Cleansening Code", 6, 0, 0)]
        public void UpdateQuality_CommonItemsBoundaryTesting_ReturnsZero(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Ring of Cleansening Code", 0, 50, 48)]
        [InlineData("Ring of Cleansening Code", 1, 50, 49)]
        [InlineData("Ring of Cleansening Code", 2, 50, 49)]
        [InlineData("Ring of Cleansening Code", 6, 50, 49)]
        public void UpdateQuality_CommonItemsBoundaryTesting_ReturnsUnderFifty(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Good Wine", 0, 1, 2)]
        [InlineData("Good Wine", 0, 49, 50)]
        [InlineData("Good Wine", 1, 25, 26)]
        [InlineData("Good Wine", 2, 49, 50)]
        [InlineData("Good Wine", 6, 1, 2)]
        public void UpdateQuality_WineItemsBoundaryTesting_Positive(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        /*[Theory]
        [InlineData("Good Wine", 0, 51, 0)]
        [InlineData("Good Wine", 0, -1, 0)]
        [InlineData("Good Wine", 1, 51, 0)]
        [InlineData("Good Wine", 2, 51, 0)]
        [InlineData("Good Wine", 6, -1, 0)]
        public void UpdateQuality_WineItemsBoundaryTesting_Negative(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }*/

        [Theory]
        [InlineData("Good Wine", 0, 0, 1)]
        [InlineData("Good Wine", 1, 0, 1)]
        [InlineData("Good Wine", 2, 0, 1)]
        [InlineData("Good Wine", 6, 0, 1)]
        public void UpdateQuality_WineItemsBoundaryTesting_ReturnsAboveZero(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Good Wine", 0, 50, 50)]
        [InlineData("Good Wine", 1, 50, 50)]
        [InlineData("Good Wine", 2, 50, 50)]
        [InlineData("Good Wine", 6, 50, 50)]
        public void UpdateQuality_WineItemsBoundaryTesting_ReturnsFifty(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("B-DAWG Keychain", 0, 80, 80)]
        [InlineData("B-DAWG Keychain", 1, 80, 80)]
        [InlineData("B-DAWG Keychain", 2, 80, 80)]
        [InlineData("B-DAWG Keychain", 6, 80, 80)]
        public void UpdateQuality_LegendaryItemsBoundaryTesting_ReturnsEighty(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        /*[Theory]
        [InlineData("B-DAWG Keychain", 0, 81, 0)]
        [InlineData("B-DAWG Keychain", 1, 79, 0)]
        [InlineData("B-DAWG Keychain", 2, 81, 0)]
        [InlineData("B-DAWG Keychain", 6, 79, 0)]
        public void UpdateQuality_LegendaryItemsBoundaryTesting_Negative(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }*/

        [Theory]
        [InlineData("Backstage passes for Re:factor", 1, 47, 50)]
        [InlineData("Backstage passes for Re:factor", 2, 0, 3)]
        [InlineData("Backstage passes for Re:factor", 5, 25, 28)]
        [InlineData("Backstage passes for Re:factor", 6, 47, 50)]
        [InlineData("Backstage passes for Re:factor", 7, 48, 50)]
        [InlineData("Backstage passes for Re:factor", 10, 25, 27)]
        [InlineData("Backstage passes for Re:factor", 11, 0, 2)]
        [InlineData("Backstage passes for Re:factor", 12, 25, 25)]
        public void UpdateQuality_BackStagePassItemsBoundaryTesting_Positive(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor", 0, 1, 0)]
        [InlineData("Backstage passes for Re:factor", 0, 50, 0)]
        public void UpdateQuality_BackStagePassItemsBoundaryTesting_Negative(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor", 1, 48, 50)]
        [InlineData("Backstage passes for Re:factor", 2, 49, 50)]
        [InlineData("Backstage passes for Re:factor", 6, 50, 50)]
        [InlineData("Backstage passes for Re:factor", 7, 49, 50)]
        [InlineData("Backstage passes for Re:factor", 11, 50, 50)]
        public void UpdateQuality_BackStagePassItemsBoundaryTesting_ReturnsFifty(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Duplicate Code", 0, 2, 0)]
        [InlineData("Duplicate Code", 0, 4, 0)]
        [InlineData("Duplicate Code", 1, 25, 23)]
        [InlineData("Duplicate Code", 2, 49, 47)]
        [InlineData("Duplicate Code", 6, 1, 0)]
        public void UpdateQuality_SmellyItemsBoundaryTesting_Positive(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        /*[Theory]
        [InlineData("Duplicate Code", 0, 51, 0)]
        [InlineData("Duplicate Code", 0, -1, 0)]
        [InlineData("Duplicate Code", 1, 51, 0)]
        [InlineData("Duplicate Code", 2, 51, 0)]
        [InlineData("Duplicate Code", 6, -1, 0)]
        public void UpdateQuality_SmellyItemsBoundaryTesting_Negative(string name, int sellIn, int quality, int expectedQuality)
        {
           UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }*/

        [Theory]
        [InlineData("Duplicate Code", 0, 0, 0)]
        [InlineData("Duplicate Code", 0, 3, 0)]
        [InlineData("Duplicate Code", 1, 0, 0)]
        [InlineData("Duplicate Code", 1, 1, 0)]
        [InlineData("Duplicate Code", 2, 0, 0)]
        [InlineData("Duplicate Code", 6, 0, 0)]
        public void UpdateQuality_SmellyItemsBoundaryTesting_ReturnsZero(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }

        [Theory]
        [InlineData("Duplicate Code", 0, 50, 46)]
        [InlineData("Duplicate Code", 1, 50, 48)]
        [InlineData("Duplicate Code", 2, 50, 48)]
        [InlineData("Duplicate Code", 6, 50, 48)]
        public void UpdateQuality_SmellyItemsBoundaryTesting_ReturnsUnderFifty(string name, int sellIn, int quality, int expectedQuality)
        {
            UpdateQualityTest(name, sellIn, quality, expectedQuality);
        }
    }
}