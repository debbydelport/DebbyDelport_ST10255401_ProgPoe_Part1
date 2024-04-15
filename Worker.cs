using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebbyDelport_ST10255401_ProgPoe_Part1
{
    //constructor
    public class Worker
    {
        private static Recipe recipe;
        public Worker() 
        {
            while (true)
            {
                Console.WriteLine("\n--- Recipe Manager ---");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display the recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Return to original");
                Console.WriteLine("5. Clear");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateRecipe();
                        break;
                    case "2":
                        DisplayRecipe();
                        break;
                    case "3":
                        ScaleRecipe();
                        break;
                    case "4":
                        ResetRecipe();
                        break;
                    case "5":
                        ClearRecipe();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        //Method to create the recipe
        private static void CreateRecipe()
        {
            recipe = new Recipe();

            Console.WriteLine("Enter Recipe Name:");
            recipe.Name = Console.ReadLine();

            CaptureIngredients();
            CaptureSteps();

            Console.WriteLine("Recipe created successfully!");
        }

        //********************************************************************************************************************
        //Method to capture the ingredients
        private static void CaptureIngredients()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());
            recipe.Ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for Ingredient {i + 1}: ");
                Console.WriteLine("Name: ");
                recipe.Ingredients[i] = new Ingredient();
                recipe.Ingredients[i].Name = Console.ReadLine();

                Console.WriteLine("Quantity: ");
                recipe.Ingredients[i].Quantity = double.Parse(Console.ReadLine());

                Console.WriteLine("Unit: ");
                recipe.Ingredients[i].Unit = Console.ReadLine();
            }
        }

        //********************************************************************************************************************
        //Method to capture the steps
        private static void CaptureSteps()
        {
            Console.WriteLine("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            recipe.Steps = new Step[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter description for Step {i + 1}: ");
                recipe.Steps[i] = new Step();
                recipe.Steps[i].Description = Console.ReadLine();
            }
        }

        //********************************************************************************************************************
        //Method to display the recipe
        private static void DisplayRecipe()
        {
            if (recipe == null)
            {
                Console.WriteLine("No recipe created yet.");
                return;
            }

            Console.WriteLine("\n--- Recipe ---");
            Console.WriteLine($"Name: {recipe.Name}");
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            int stepNum = 1;

            foreach (Step step in recipe.Steps)
            {
                Console.WriteLine($"{stepNum++}. {step.Description}");
            }
        }

        //********************************************************************************************************************
        //Method to clear the recipe
        private static void ClearRecipe()
        {
            Console.WriteLine("Are you sure you want to clear the recipe? (y/n)");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "y")
            {
                recipe = null;
                Console.WriteLine("Recipe cleared successfully.");
            }
            else
            {
                Console.WriteLine("Recipe remains unchanged.");
            }
        }

        //********************************************************************************************************************
        //Method to scale the recipe
        private static void ScaleRecipe()
        {
            if (recipe == null)
            {
                Console.WriteLine("No recipe created yet.");
                return;
            }

            Console.WriteLine("Enter scaling factor (0.5, 2, or 3): ");
            double factor;

            if (!double.TryParse(Console.ReadLine(), out factor))
            {
                Console.WriteLine("Invalid scaling factor. Please enter a valid number.");
                return;
            }

            recipe.ScaleRecipe(factor);
            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }

        //********************************************************************************************************************
        //Method to reset the recipe to original quantities after scaling
        private static void ResetRecipe()
        {
            if (recipe == null)
            {
                Console.WriteLine("No recipe created yet.");
                return;
            }

            recipe.ResetRecipe();
        }

    }
}
    

