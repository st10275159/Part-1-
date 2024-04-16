using System;

namespace Recipe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe App.");

            // Prompt the user to enter recipe details
            Recipe recipe = GetRecipeDetails();

            // Display the entered recipe
            Console.WriteLine("\nHere's the recipe you entered:");
            recipe.DisplayRecipe();

            // Prompt the user to scale the recipe
            ScaleRecipe(recipe);

            // Display the scaled recipe
            Console.WriteLine("\nHere's the scaled recipe:");
            recipe.DisplayRecipe();

            // Reset the quantities to original values
            recipe.ResetQuantities();

            // Display the recipe after resetting quantities
            Console.WriteLine("\nRecipe after resetting quantities:");
            recipe.DisplayRecipe();

            Console.WriteLine("\nThank you for using the Recipe App!");
        }

        static Recipe GetRecipeDetails()
        {
            // Get number of ingredients from the user
            Console.Write("\nEnter the number of ingredients: ");
            int numberOfIngredients = int.Parse(Console.ReadLine());

            // Initialize array to store ingredients
            Ingredient[] ingredients = new Ingredient[numberOfIngredients];

            // Get details of each ingredient
            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.WriteLine($"\nDetails for Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                // Create ingredient object and add to array
                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            // Get number of steps from the user
            Console.Write("\nEnter the number of steps: ");
            int numberOfSteps = int.Parse(Console.ReadLine());

            // Initialize array to store steps
            string[] steps = new string[numberOfSteps];

            // Get details of each step
            for (int i = 0; i < numberOfSteps; i++)
            {
                Console.Write($"\nEnter Step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            // Create and return recipe object
            return new Recipe(numberOfIngredients, ingredients, numberOfSteps, steps);
        }

        static void ScaleRecipe(Recipe recipe)
        {
            Console.WriteLine("\nDo you want to scale the recipe? (Y/N)");
            char choice = char.ToUpper(Console.ReadKey().KeyChar);
            if (choice == 'Y')
            {
                Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());
                recipe.ScaleIngredients(factor);
            }
        }
    }

    class Recipe
    {
        public int NumberOfIngredients { get; }
        public Ingredient[] Ingredients { get; }
        public int NumberOfSteps { get; }
        public string[] Steps { get; }

        public Recipe(int numberOfIngredients, Ingredient[] ingredients, int numberOfSteps, string[] steps)
        {
            NumberOfIngredients = numberOfIngredients;
            Ingredients = ingredients;
            NumberOfSteps = numberOfSteps;
            Steps = steps;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < NumberOfSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public void ScaleIngredients(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Implement resetting quantities to original values
        }
    }

    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}

