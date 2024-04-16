using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebbyDelport_ST10255401_ProgPoe_Part1
{
    internal class Recipe
    {
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        // Variable to track the last scaling factor used in the program.
        private double lastScalingFactor = 1;

//********************************************************************************************************************
        //Method to Scale the recipe
        public void ScaleRecipe(double factor)
        {
            if (factor != 0.5 && factor != 2 && factor != 3)
            {
                Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                return;
            }

            // Store the used scaling factor that the user entered.
            lastScalingFactor = factor;

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

//********************************************************************************************************************
        //Method to reset recipe to original quantities after scaling
        public void ResetRecipe()
        {
            if (lastScalingFactor == 1)
            {
                Console.WriteLine("No scaling has been applied yet. There's nothing to reset.");
                return;
            }

            // Apply the inverse of the last scaling factor to reset quantities
            double inverseFactor = 1 / lastScalingFactor;

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= inverseFactor;
            }

            Console.WriteLine("Recipe quantities reset to original values.");
        }

    }
}
//***************************************END OF FILE******************************************************************
