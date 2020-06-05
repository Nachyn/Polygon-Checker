using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using NUnit.Framework;
using PolygonApp.Model;

namespace PolygonApp.UnitTests
{
    public class PolygonCheckerTests
    {
        [TestCaseSource(typeof(PolygonTestsData), nameof(PolygonTestsData.ValidPolygons))]
        public void IsPointInsidePolygon_ShouldReturnExpectedValue(
            List<Point> polygon, Point point, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, PolygonChecker.IsPointInsidePolygon(polygon, point));
        }

        [Test]
        public void IsPointInsidePolygon_GivenInvalidArguments_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                PolygonChecker.IsPointInsidePolygon(null, new Point()));

            Assert.Throws<ArgumentException>(() =>
                PolygonChecker.IsPointInsidePolygon(new List<Point>(), new Point()));
        }
    }

    public static class PolygonTestsData
    {
        public static IEnumerable ValidPolygons
        {
            get
            {
                var polygon = new List<Point>
                {
                    new Point {X = -2, Y = 0},
                    new Point {X = 1, Y = 3},
                    new Point {X = 4, Y = 0},
                    new Point {X = 2, Y = 0},
                    new Point {X = 2, Y = -2},
                    new Point {X = 0, Y = -2}
                };

                yield return new TestCaseData(polygon, new Point {X = 0, Y = 0}, true);
                yield return new TestCaseData(polygon, new Point {X = 2, Y = 2}, true);
                yield return new TestCaseData(polygon, new Point {X = 2, Y = 0}, true);
                yield return new TestCaseData(polygon, new Point {X = -2, Y = -1}, false);
                yield return new TestCaseData(polygon, new Point {X = 3, Y = -1}, false);

                polygon = new List<Point>
                {
                    new Point {X = -2, Y = -2},
                    new Point {X = -2, Y = 2},
                    new Point {X = 2, Y = 2},
                    new Point {X = 2, Y = -2}
                };

                yield return new TestCaseData(polygon, new Point {X = 0, Y = 0}, true);
                yield return new TestCaseData(polygon, new Point {X = 2, Y = 2}, true);
                yield return new TestCaseData(polygon, new Point {X = 2, Y = 0}, true);
                yield return new TestCaseData(polygon, new Point {X = 1, Y = -1}, true);
                yield return new TestCaseData(polygon, new Point {X = 3, Y = -1}, false);
                yield return new TestCaseData(polygon, new Point {X = 1, Y = 3}, false);
            }
        }
    }
}