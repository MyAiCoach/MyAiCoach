using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Infrastructure.Utils
{
    public class GeneratePrompt
    {

        public static string GenerateWorkout(CreateWorkoutDto input)
        {
            var prompt = "Give me a only workout program. ";

            //For Age
            prompt = "Im " + input.Age + " years old, ";

            //For Weight and Height
            prompt += "weighing " + input.Weight + " kgs, ";

            //For Workout Level
            switch (input.WorkoutLevel)
            {
                case WorkoutLevel.Beginner:
                    prompt += "I am a beginner, ";
                    break;
                case WorkoutLevel.Intermediate:
                    prompt += "I am an intermediate, ";
                    break;
                case WorkoutLevel.Advanced:
                    prompt += "I am an advanced, ";
                    break;
                case WorkoutLevel.Professional:
                    prompt += "I am a professional, ";
                    break;
                case WorkoutLevel.Expert:
                    prompt += "I am an expert, ";
                    break;
            }

            //For Workout Type
            switch (input.WorkoutType)
            {
                case WorkoutType.LoseWeight:
                    prompt += "and I want to lose weight. ";
                    break;
                case WorkoutType.GainMuscle:
                    prompt += "and I want to gain muscle. ";
                    break;
                case WorkoutType.StayFit:
                    prompt += "and I want to stay fit. ";
                    break;
                case WorkoutType.GainStrength:
                    prompt += "and I want to gain strength. ";
                    break;
                case WorkoutType.GainEndurance:
                    prompt += "and I want to gain endurance. ";
                    break;
                case WorkoutType.GainFlexibility:
                    prompt += "and I want to gain flexibility. ";
                    break;
            }

            //For Workout Duration
            prompt += "I want to workout for " + input.WorkoutDuration + " days, ";

            //For Workout Day Count
            prompt += "and I want to workout " + input.WorkoutDayCount + " days a week. ";  
            return prompt;
        }


        public static string GenerateNutrition(CreateNutritionDto input)
        {
            var prompt = "Give me a only diet program for 7 days. ";

            //For Age
            prompt = "Im " + input.Age + " years old, ";

            //For Weight and Height
            prompt += "weighing " + input.Weight + " kgs, ";

            //For Nutrition Goal
            switch (input.NutritionGoal)
            {
                case NutritionGoal.WeightLoss:
                    prompt += "I want to lose weight, ";
                    break;
                case NutritionGoal.WeightGain:
                    prompt += "I want to gain muscle, ";
                    break;
                case NutritionGoal.MaintainWeight:
                    prompt += "I want to be same gain";
                    break;
            }

            //For Nutrition Duration
            prompt += "I want to follow this nutrition plan for " + input.NutritionDuration + " days, ";

            //For Lactose Intolerance
            if (input.LactoseInTolerance)
            {
                prompt += "I am lactose intolerant, ";
            }

            //For Gluten Intolerance
            if (input.GlutenInTolerance)
            {
                prompt += "I am gluten intolerant, ";
            }

            //For Vegan
            if (input.Vegan)
            {
                prompt += "I am vegan, ";
            }

            return prompt;
        }
    }
}
