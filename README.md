This C# program is designed to manage a collection of recipes, allowing users to add new recipes, view a list of all recipes, and exit the application. Here's how it works:

### Program Structure
- **Main Class (`Recipe`)**: This class represents a recipe and contains methods for adding new recipes, viewing existing ones, and displaying detailed information about a selected recipe.
- **Ingredient Class**: Represents individual ingredients within a recipe, including properties like name, quantity, unit, calories, and food group.

### User Interaction
- The `Main` method runs an infinite loop that displays a menu to the user, allowing them to choose between adding a new recipe, viewing the list of recipes, or exiting the application.
- Based on the user's choice, different methods are called:
  - **Adding a New Recipe**: The `AddNewRecipe` method prompts the user to enter details for a new recipe, including its name, ingredients (with quantity, unit, calories, and food group), and preparation steps. Each ingredient and step is added to the recipe object, which is then stored in the static `recipes` list.
  - **Viewing Recipes**: The `ViewRecipes` method sorts the list of recipes alphabetically by name and displays each one. It also allows the user to select a specific recipe to view its details.
  - **Exiting**: The application exits gracefully upon selecting this option.

### Additional Features
- **Sorting and Searching**: The program automatically sorts the list of recipes alphabetically whenever they are viewed. Users can also search for a specific recipe by name.
- **Calorie Notification**: When displaying a recipe's details, the program calculates the total calories of all ingredients and warns the user if the total exceeds 300 calories.

### Running the Code
To run this program, compile and execute the C# file containing the `Recipe` and `Ingredient` classes. The console application will start, presenting the user with options to interact with the recipe manager.
