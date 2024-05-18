using System;
using System.Collections.Generic;

// Class representing a recipe
class Recipe
{
    // Static list to store all recipes
    static List<Recipe> recipes = new List<Recipe>();

    // Properties of a recipe
    public string RecipeName { get; set; }
    public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe
    public List<string> Steps { get; set; } // List of steps to prepare the recipe

    // Constructor for creating a new recipe
    public Recipe(string name)
    {
        RecipeName = name;
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    // Main method to run the application
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Recipe Manager!");

        // Infinite loop to keep the application running until the user chooses to exit
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add a new recipe");
            Console.WriteLine("2. View list of recipes");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            // Switch statement to handle user choices
            switch (choice)
            {
                case "1":
                    AddNewRecipe(); // Method to add a new recipe
                    break;
                case "2":
                    ViewRecipes(); // Method to view existing recipes
                    break;
                case "3":
                    Environment.Exit(0); // Exit the application
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again."); // Inform the user about invalid input
                    break;
            }
        }
    }

    // Method to add a new recipe
    static void AddNewRecipe()
    {
        Console.WriteLine("\nEnter the name of the recipe:");
        string name = Console.ReadLine();

        Recipe newRecipe = new Recipe(name);

        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = Convert.ToInt32(Console.ReadLine());

        // Loop to add ingredients to the new recipe
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter ingredient #{i + 1} name:");
            string ingredientName = Console.ReadLine();

            Console.WriteLine($"Enter quantity of {ingredientName}:");
            double quantity = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter unit of measurement:");
            string unit = Console.ReadLine();

            Console.WriteLine("Enter calories:");
            double calories = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select food group:");
            Console.WriteLine("1. Vegetables");
            Console.WriteLine("2. Fruits");
            Console.WriteLine("3. Grains");
            Console.WriteLine("4. Proteins");
            int groupChoice = Convert.ToInt32(Console.ReadLine());
            string foodGroup = GetFoodGroup(groupChoice);

            Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);
            newRecipe.Ingredients.Add(ingredient);
        }

        // Loop to add steps to the new recipe
        Console.WriteLine("Enter the number of steps:");
        int numSteps = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step #{i + 1}:");
            string step = Console.ReadLine();
            newRecipe.Steps.Add(step);
        }

        recipes.Add(newRecipe); // Add the new recipe to the list of recipes
    }

    // Method to view the list of recipes
    static void ViewRecipes()
    {
        Console.WriteLine("\nList of Recipes:");

        // Sort the recipes alphabetically by name
        recipes.Sort((x, y) => string.Compare(x.RecipeName, y.RecipeName));

        // Display each recipe name
        foreach (Recipe recipe in recipes)
        {
            Console.WriteLine(recipe.RecipeName);
        }

        // Allow the user to select a recipe to view details
        Console.WriteLine("\nEnter the name of the recipe you want to view:");
        string selectedRecipe = Console.ReadLine();

        Recipe recipeToDisplay = recipes.Find(r => r.RecipeName.Equals(selectedRecipe, StringComparison.OrdinalIgnoreCase));

        if (recipeToDisplay != null)
        {
            DisplayRecipe(recipeToDisplay); // Display detailed information about the selected recipe
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    // Method to display detailed information about a recipe
    static void DisplayRecipe(Recipe recipe)
    {
        Console.WriteLine($"\n{recipe.RecipeName}");
        Console.WriteLine("\nIngredients:");
        double totalCalories = 0;

        // Iterate through each ingredient and display its details
        foreach (Ingredient ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            totalCalories += ingredient.Calories;
        }

        // Check if the total calories exceed 300 and notify the user if so
        if (totalCalories > 300)
        {
            NotifyUserExceedsCalories();
        }

        Console.WriteLine($"\nTotal calories: {totalCalories}");

        // Display the steps to prepare the recipe
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
        }
    }

    // Method to notify the user if the total calories exceed 300
    static void NotifyUserExceedsCalories()
    {
        Console.WriteLine("Warning: Total calories exceed 300!");
    }

    // Helper method to map food group numbers to names
    static string GetFoodGroup(int choice)
    {
        switch (choice)
        {
            case 1:
                return "Vegetables";
            case 2:
                return "Fruits";
            case 3:
                return "Grains";
            case 4:
                return "Proteins";
            default:
                return "Other";
        }
    }
}

// Class representing an ingredient
class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double Calories { get; set; }
    public string FoodGroup { get; set; }

    // Constructor for creating a new ingredient
    public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Calories = calories;
        FoodGroup = foodGroup;
    }
}

