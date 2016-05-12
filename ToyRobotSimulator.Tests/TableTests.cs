using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_ValidateCoordinates_InvalidCoordinates_ThrowsInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(5, 5);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_ValidateCoordinates_NegativeCoordinates_ThrowsInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(-1, 1);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_ValidateCoordinates_ValidX_InvalidY_ThrowsInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 5);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_ValidateCoordinates_InValidX_ValidY_ThrowsInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(5, 3);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_ValidateCoordinates_NullCoordinates_ThrowsInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(null, null);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        public void Table_ValidateCoordinates_ValidCoordinates_DoesNotrThrowInvalidOperationException()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 3);
            tbl.ValidateCoordinates(coordinates);
        }

        [TestMethod]
        public void Table_Move_North_IncreasesY()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 3);
            var newCoordinates = tbl.Move(coordinates, DirectionList.NORTH);


            Assert.AreEqual(3, newCoordinates.X, "x coordinate should be set to 3");
            Assert.AreEqual(4, newCoordinates.Y, "y coordinate should be set to 4");
        }


        [TestMethod]
        public void Table_Move_East_IncreasesX()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 3);
            var newCoordinates = tbl.Move(coordinates, DirectionList.EAST);


            Assert.AreEqual(4, newCoordinates.X, "x coordinate should be set to 4");
            Assert.AreEqual(3, newCoordinates.Y, "y coordinate should be set to 3");
        }

        [TestMethod]
        public void Table_Move_West_DecreasesX()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 3);
            var newCoordinates = tbl.Move(coordinates, DirectionList.WEST);


            Assert.AreEqual(2, newCoordinates.X, "x coordinate should be set to 2");
            Assert.AreEqual(3, newCoordinates.Y, "y coordinate should be set to 3");
        }

        [TestMethod]
        public void Table_Move_South_DecreasesY()
        {
            var width = 5;
            var height = 5;
            var tbl = new Table(width, height);
            var coordinates = new Coordinates(3, 3);
            var newCoordinates = tbl.Move(coordinates, DirectionList.SOUTH);


            Assert.AreEqual(3, newCoordinates.X, "x coordinate should be set to 3");
            Assert.AreEqual(2, newCoordinates.Y, "y coordinate should be set to 2");
        }


    }
}
