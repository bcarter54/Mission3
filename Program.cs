// See https://aka.ms/new-console-template for more information
// Call in Mission3 to allow the classes to work together 
using Mission3;

// Initialize the list of foodItems to store the items added 
List<FoodItem> foodItems = new List<FoodItem>();

// Initialize userChoice as a string to use TryParse later to ensure a valid input
string userChoice = "";

Console.WriteLine("Welcome to your Food Bank Manager System!");

// Begin while loop to allow for easy return to the main menu
Boolean continueUser = false;
while (continueUser == false)
{
    // Present options and ask for user input
    Console.WriteLine("\nPlease select one of the following options:\n" +
                      "\n1 Add a food item" +
                      "\n2 Delete a food item" +
                      "\n3 Print a list of the current food items" +
                      "\n4 Exit the program\n");
    
    userChoice = Console.ReadLine();
    
    // Check to make sure the entry is valid and provide error message if it isn't
    if (int.TryParse(userChoice, out int userChoiceInt))
    {
        if (userChoiceInt >= 1 && userChoiceInt <= 4)
        {
            
            // Add item option
            if (int.Parse(userChoice) == 1)
            {
                Console.WriteLine("Enter food item name:\n");
                string foodName = Console.ReadLine();
                Console.WriteLine("Enter the food category name:\n");
                string foodCategory = Console.ReadLine();
                string foodQuantity = "";
                
                // While loop to make sure the quantity entered is valid. If not, allow for re-entry
                Boolean validQuantity = false;
                while (validQuantity == false)
                {
                    Console.WriteLine("Enter the item quantity:\n");
                    foodQuantity = Console.ReadLine();
        

                    if (int.TryParse(foodQuantity, out int foodQuantityInt))
                    {
                        validQuantity = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Enter a numeric quantity");
                    }
                }
                
                // While loop and try-catch statement to make sure expiration date is entered correctly
                DateOnly expirationDate = default;
                bool isValidDate = false;

                while (!isValidDate)
                {
                    Console.WriteLine("Enter the item expiration date (mm/dd/yyyy):");

                    string userInput = Console.ReadLine();
                    
                    try
                    {
                        expirationDate = DateOnly.Parse(userInput);
                        isValidDate = true;
                        Console.WriteLine($"Valid date entered: {expirationDate}\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nInvalid date format. Please enter the date in mm/dd/yyyy format.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                
                // Pass all information to FoodItem constructor and add the foodItem object to the foodItems list
                FoodItem foodItem = new FoodItem(foodName, foodCategory, int.Parse(foodQuantity), expirationDate);
                foodItems.Add(foodItem);
                
                // Provide space to present success message before moving on
                Console.WriteLine("Food item entered successfully. Press enter to continue...");
                Console.ReadLine();
            }
            
            // Delete food item option
            if (int.Parse(userChoice) == 2 && foodItems.Count > 0)
            {
                Boolean validDelete = false;
                while (!validDelete)
                {
                    // List off food items
                    Console.WriteLine("\nEnter the number of the item you would like to delete:\n");
                    for (int i = 0; i < foodItems.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {foodItems[i].Name}");
                    }

                    string deleteNumber = Console.ReadLine();

                    if (int.TryParse(deleteNumber, out int itemDelete))
                    {
                        // Loop through food items to find matching number and delete if there is a matching number
                        for (int i = 0; i < foodItems.Count; i++)
                        {
                            if (itemDelete == (i + 1))
                            {
                                foodItems.RemoveAt(i);

                                Console.WriteLine("\nItem deleted successfully. Press enter to return to the main menu...");
                                Console.ReadLine();
                                validDelete = true;
                                break; // Exit the for loop immediately
                            }
                        }


                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                    }

                    if (!validDelete)
                    {
                        Console.WriteLine("\nInvalid input. Would you still like to delete an item? (Enter Y or N):\n");
                        string stillDelete = Console.ReadLine();

                        if (stillDelete.ToUpper() != "Y")
                        {
                            Console.WriteLine("\nPress enter to return to the main menu...");
                            Console.ReadLine();
                            validDelete = true;
                        }
                    }
                }
            }
            else if (int.Parse(userChoice) == 2 && foodItems.Count == 0)
            {
                Console.WriteLine("\nThere are no items to delete. Press enter to return to the main menu...\n");
                Console.ReadLine();
            }

            
            // Print off current food items
            if (int.Parse(userChoice) == 3)
            {
                for (int i = 0; i < foodItems.Count; i++)
                {
                    Console.WriteLine($"\n--{i+1}-- \n {foodItems[i].Name} \n {foodItems[i].Category} \n {foodItems[i].Quantity} \n {foodItems[i].ExpirationDate.ToShortDateString()}\n");
                }

                if (foodItems.Count == 0)
                {
                    Console.WriteLine("\nNo items to display.\n");
                }
                
                Console.WriteLine("Press enter to return to the main menu...");
                Console.ReadLine();
                
            }
            
            // Exit program
            if (int.Parse(userChoice) == 4)
            {
                Console.WriteLine("Thank you for using the Food Bank Manager System! Goodbye!\n");
                continueUser = true;
            }
        }
        
        // Error handling if the entry is invalid
        else
        {
            Console.WriteLine("Invalid input. Enter a number between 1 and 4");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid input. Enter a number between 1 and 4");
    }
}



