using System;
using System.Collections.Generic;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace TestDriven
{
    /* Unit tests
    *  Should not cause actual database access
    *  Should develop some parts of application with test-driven development - writing the tests first
    */
    [TestClass]
    public class UnitTest
    {
        private DataLayer crudTest = new DataLayer();        

        [TestMethod]
        public void CheckRestaurantData()
        {
            List<Restaurant> restaurantList = crudTest.GetRestaurantsList();

            //Arrange - arranging the things that needs to be tested
            int expectedId = 2;
            string expectedName = "Columbia";
            string expectedAddress = "2117 E 7th Ave, Tampa, Fl 33605";
            string expectedPhone = "8132484961";
            string expectedWebsite = "columbiarestaurant.com";
            string expectedDelivery = "No";
            string expectedFoodtype = "Non-veg";

            //Act - perform the operation on the method
            int actualId = restaurantList[0].RestaurantId;
            string actualName = restaurantList[0].Name;
            string actualAddress = restaurantList[0].Address;
            string actualPhone = restaurantList[0].Phone;
            string actualWebsite = restaurantList[0].Website;
            string actualDelivery = restaurantList[0].DeliveryOption;
            string actualFoodtype = restaurantList[0].FoodType;


            //Assert - Compare against what you are expecting
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAddress, actualAddress);
            Assert.AreEqual(expectedPhone, actualPhone);
            Assert.AreEqual(expectedWebsite, actualWebsite);
            Assert.AreEqual(expectedDelivery, actualDelivery);
            Assert.AreEqual(expectedFoodtype, actualFoodtype);
        }

        [TestMethod]
        public void CheckReviewData()
        {
            Review review = crudTest.FindReviewById(8);
            //Arrange - arranging the things that needs to be tested
            int expectedReviewId = 8;
            int expectedRestaurantId = 2;
            double expectedRating = 6.0; //divided by 2 for display only
            string expectedUsername = "Her";
            string expectedComment = "Only Non-Veg";

            //Act - perform the operation on the method
            int actualReviewId = review.ReviewId;
            int actualRestaurantId = review.RestaurantId;
            double actualRating = review.Rating;
            string actualUsername = review.Username;
            string actualComment = review.Comment;

            //Assert - Compare against what you are expecting
            Assert.AreEqual(expectedReviewId, actualReviewId);
            Assert.AreEqual(expectedRestaurantId, actualRestaurantId);
            Assert.AreEqual(expectedRating, actualRating);
            Assert.AreEqual(expectedUsername, actualUsername);
            Assert.AreEqual(expectedComment, actualComment);
        }

    }
}
