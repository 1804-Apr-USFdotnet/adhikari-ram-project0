using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using BusinessLogic;

namespace Client
{
    /* Console application
    *  Should have no reference to data project
    *  Should provide a menu of possible actions for the user to enter
    *  Should handle invalid user input gracefully 
    */
    sealed class Program
    {
        static void Main(string[] args)
        {
            //Use business logic library instance to access Functionalities
            Library logic = new Library();
            int minId = logic.MinId();
            int maxId = logic.MaxId();

            Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Please press enter key to start the program.");            

            int number;
            while (true)
            {
                Console.Write("Enter to Continue...");
                Console.ReadKey();
                Console.Clear();
                DisplayMenu();
                Console.Write(">");
                var input = Console.ReadLine();
                if (input == "10")
                {
                    break;
                }
                try
                {
                    number = int.Parse(input);
                    switch (number)
                    {
                        case 1:
                            List<string> newResData = AddNewResaurant1();
                            logic.Add(newResData);
                            break;

                        case 2:
                            logic.PrintIds();
                            List<string> list2 = UpdateRestaurant2();
                            logic.Modify(list2);
                            break;

                        case 3:
                            logic.PrintIds();
                            int restaurantId3 = DeleteId();
                            logic.Delete(restaurantId3);
                            break;
                        case 4:
                            string id = "";
                            int i = 0;
                            int checkMe = 0;
                            while (true)
                            {
                                if (checkMe >= minId && checkMe <= maxId)
                                {
                                    logic.DisplayRestaurantById(checkMe);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the restaurant's id that you would like to display(" + minId + "-" + maxId + "): ");
                                    Console.Write("->");
                                    id = Console.ReadLine();
                                    int.TryParse(id, out i);
                                    checkMe = i;
                                }
                            }                   
                            break;

                        case 5:
                            logic.DisplaySortedId();
                            break;

                        case 6:
                            logic.DisplaySortedName();
                            break;

                        case 7:
                            string id7 = "";
                            int result = 0;
                            int checkMe7 = 0;
                            while (true)
                            {
                                if (checkMe7 >= minId && checkMe7 <= maxId)
                                {
                                    logic.DisplayReviewsOfRestaurant(checkMe7);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the restaurant's id to display all the reviews " +
                                        "of that restaurant (" + minId + "-" + maxId + "): ");
                                    Console.Write("->");
                                    id7 = Console.ReadLine();
                                    int.TryParse(id7, out result);
                                    checkMe7 = result;
                                }
                            }                            
                            break;

                        case 8:
                            logic.TopThree();
                            break;

                        case 9:
                            Console.WriteLine("Enter the partial name of a restaurant: ");
                            Console.Write("->");
                            string partialName = Console.ReadLine();
                            logic.PartialSearch(partialName);
                            break;

                        default:
                            logger.Info("Refer to menu and enter a number between (1-10): ");
                            break;

                    }
                }
                catch (FormatException)
                {
                    logger.Error("Refer to menu and enter a number between (1-10): ");
                    continue;
                }
            }

            logger.Info("Press enter key to close this window.");
            Console.ReadKey();
        }

        //Print this menu on the console when the program starts
        private static void DisplayMenu()
        {
            Console.WriteLine("\nPlease enter a number from the following menu: " +
                "\n1.  Add a restaurant" +
                "\n2.  Modify a restaurant" +
                "\n3.  Delete a restaurant" +
                "\n4.  Display details of a restaurant" +
                "\n5.  Display all restaurants sorted by id" +
                "\n6.  Display all restaurants sorted by name" +
                "\n7.  Display all the reviews of a restaurant" +
                "\n8.  Display top 3 restaurants by average rating" +
                "\n9.  Display the restaurants searched by partial name" +
                "\n10. Quit application");
        }

        //Ask and validate user input to add a new restaurant. 
        private static List<String> AddNewResaurant1()
        {
            string name, address, phone, website, delivery, foodType;
            name = address = phone = website = delivery = foodType = string.Empty;
            bool again = false;
            do
            {
                if (name.Length == 0)
                {
                    Console.WriteLine("Enter restaurant name: ");
                    name = Console.ReadLine();
                }
                if (address.Length <= 10)
                {
                    Console.WriteLine("Enter restaurnt's full address: ");
                    address = Console.ReadLine();
                }
                if (!IsTenDigits(phone))
                {
                    Console.WriteLine("Enter restaurnt's 10 digit phone number(no spaces): ");
                    phone = Console.ReadLine();
                }
                if (!(delivery.ToLower() == "y" || delivery.ToLower() == "n"))
                {
                    Console.WriteLine("Enter restaurnt's delivery option(y/n): ");
                    delivery = Console.ReadLine();
                }
                if (again == false)
                {
                    Console.WriteLine("Enter restaurant food type(vegan, veg, non-veg): ");
                    foodType = Console.ReadLine();
                    Console.WriteLine("Enter restaurnt's website: ");
                    website = Console.ReadLine();
                    again = true;
                }
            } while (name.Length == 0 || address.Length <= 10 || !IsTenDigits(phone) ||
            !(delivery.ToLower() == "y" || delivery.ToLower() == "n"));

            delivery = delivery.ToLower().Equals("y") ? "Yes" : "No";
            List<string> newRes = new List<string> { name, address, phone, website, delivery, foodType };
            return newRes;
        }

        //@returns - true if the string has 10 characters and contains only digits
        private static bool IsTenDigits(string phone)
        {
            if (phone.Length != 10)
            {
                return false;
            }
            else
            {
                foreach (char c in phone)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }

        //@returns - an updated list of restaurant's properties
        private static List<String> UpdateRestaurant2()
        {
            string name, address, phone, website, delivery, foodType, id;
            name = address = phone = website = delivery = foodType = id = string.Empty;

            int i = 0;
            do
            {
                Console.WriteLine("Enter the restaurant's id that you would like to modify: ");
                Console.Write("->");
                id = Console.ReadLine();
                i = int.Parse(id);
            } while (i == 0);

            DisplayUpdateMenu();

            int number;
            while (true)
            {
                Console.Write("->");
                var input = Console.ReadLine();
                if (input == "7")
                {
                    break;
                }
                try
                {
                    number = int.Parse(input);
                    switch (number)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Modify restaurant name: ");
                                Console.Write("->");
                                name = Console.ReadLine();
                            } while (name.Length == 0);
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("Modify restaurnt's full address: ");
                                Console.Write("->");
                                address = Console.ReadLine();
                            } while (address.Length <= 10);
                            break;
                        case 3:
                            do
                            {
                                Console.WriteLine("Modify restaurnt's 10 digit phone number(no spaces): ");
                                Console.Write("->");
                                phone = Console.ReadLine();
                            } while (!IsTenDigits(phone));
                            break;
                        case 4:
                            Console.WriteLine("Enter restaurnt's website: ");
                            Console.Write("->");
                            website = Console.ReadLine();
                            break;
                        case 5:
                            do
                            {
                                Console.WriteLine("Enter restaurnt's delivery option(y/n): ");
                                Console.Write("->");
                                delivery = Console.ReadLine();
                            } while (!(delivery.ToLower() == "y" || delivery.ToLower() == "n"));
                            break;
                        case 6:
                            Console.WriteLine("Enter restaurant food type(vegan, veg, non-veg): ");
                            Console.Write("->");
                            foodType = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Refer to the modify menu and enter a number between (1-7): ");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Refer to the modify menu and enter a number between (1-7): ");
                    continue;
                }
            }

            delivery = delivery.ToLower().Equals("y") ? "Yes" : "No";
            List<string> updatedRes = new List<string> { id, name, address, phone, website, delivery, foodType };
            return updatedRes;
        }

        //Print this menu on the console when the user wants to update a restaurant
        private static void DisplayUpdateMenu()
        {
            Console.WriteLine("Pick a number to modify the following: ");
            Console.WriteLine("1. Name             " +
                               "\n2. Address       " +
                               "\n3. Phone Number  " +
                               "\n4. Website       " +
                               "\n5. Delivery      " +
                               "\n6. FoodType      " +
                               "\n7. Exit          ");
        }

        //Ask this when deleting a restaurant
        private static int DeleteId()
        {
            string id = "";
            int i = 0;
            do
            {
                Console.WriteLine("Enter the restaurant's id that you would like to delete: ");
                Console.Write("->");
                id = Console.ReadLine();
                int.TryParse(id, out i);
            } while (i == 0);
            return i;
        }

        //Helper method
        private static int GetResId(string message, int min, int max)
        {
            string id = "";
            int i = 0;
            while(i < min && i > max)
            {
                Console.WriteLine("Enter the restaurant's id that you would like " + message + " (" + min + "-" + max + "): ");
                id = Console.ReadLine();
                int.TryParse(id, out i);
            }
            return i;
        }
    }
}