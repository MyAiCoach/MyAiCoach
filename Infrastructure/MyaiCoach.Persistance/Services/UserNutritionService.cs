using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Exceptions;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.NutritionDtos;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Services
{
    public class UserNutritionService:IUserNutritionService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFoodRepository _foodRepository;
        private readonly IGramRepository _gramRepository;
        private readonly INutritionDayRepository _nutritionDayRepository;
        private readonly INutritionSessionRepository _nutritionSessionRepository;

        public UserNutritionService(UserManager<AppUser> userManager, IFoodRepository foodRepository, IGramRepository gramRepository, INutritionDayRepository nutritionDayRepository, INutritionSessionRepository nutritionSessionRepository)
        {
            _userManager = userManager;
            _foodRepository = foodRepository;
            _gramRepository = gramRepository;
            _nutritionDayRepository = nutritionDayRepository;
            _nutritionSessionRepository = nutritionSessionRepository;
        }

        public async Task<List<DietProgramViewDto>> GetNutritionProgramAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId), "UserId must be exist");

            var result = new List<DietProgramViewDto>();


            var getNutritionDays = _nutritionDayRepository.GetWhere(w => w.AppUserId == userId).ToList();
            if (getNutritionDays == null)
                throw new UserNotFoundException($"{userId} user no is empty");

            foreach (var dayGroup in getNutritionDays.GroupBy(w => w.Days))
            {
                var dayProgram = new DietProgramViewDto
                {
                    Days = dayGroup.Key,
                    Foods = new List<FoodViewDto>(),
                    Grams = new List<GramViewDto>()
                };

                foreach (var nutritionDay in dayGroup)
                {
                    var getNutritionSession = await _nutritionSessionRepository.Table.FirstOrDefaultAsync(w => w.Id == nutritionDay.NutritionSessionId);

                    if (getNutritionSession == null)
                        continue; // or handle the situation accordingly

                    var getFood = await _foodRepository.Table.FirstOrDefaultAsync(e => e.Id == getNutritionSession.FoodId);
                    dayProgram.Foods.Add(new FoodViewDto
                    {
                        Name = getFood.Name,
                        Description = getFood.Description,
                        Calory = getFood.Calory,
                        Carbonhydrate = getFood.Carbonhydrate,
                        Protein = getFood.Protein,
                    });

                    var getGram = await _gramRepository.Table.FirstOrDefaultAsync(sr => sr.Id == getNutritionSession.GramId);
                    dayProgram.Grams.Add(new GramViewDto
                    {
                      Amount = getGram.Amount,
                      Type = getGram.Type
                    });
                }

                result.Add(dayProgram);
            }

            return result;
        }

        public async Task<bool> SaveNutritionAsync(Guid userId, List<DietProgramViewDto> input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input must be exist");

            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId), "UserId must be exist");

            var getUser = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (getUser == null)
                throw new UserNotFoundException($"{userId} user no is empty");

            var insert = await InsertIfNotExist(input);

            if (!insert)
                return false;

            foreach (var days in input)
            {
                for (var i = 0; i < days.Foods.Count; i++)
                {
                    var currentfood = days.Foods[i];
                    var currentgram = days.Grams.Count == 1 ? days.Grams[0] : days.Grams[i];


                    var getfood = await _foodRepository.GetSingleAsync(e => e.Name == currentfood.Name);
                    if (getfood == null)
                        continue;

                    var getgram = await _gramRepository.GetSingleAsync(sr => sr.Type == currentgram.Type && sr.Amount == currentgram.Amount);
                    if (getgram == null)
                        continue;

                    var nutritionSession = await _nutritionSessionRepository.Table.FirstOrDefaultAsync(
                          w => w.GramId == getgram.Id &&
                             w.FoodId == getfood.Id);

                    if (nutritionSession == null)
                    {
                        nutritionSession = new NutritionSession()
                        {
                           FoodId = getfood.Id,
                           GramId = getgram.Id,

                        };
                        _ = await _nutritionSessionRepository.AddAsync(nutritionSession);
                    }

                    var addnutritionDay = new NutritionDay()
                    {
                        AppUserId = getUser.Id,
                        Days = days.Days,
                        NutritionSessionId = nutritionSession.Id,
                        
                    };
                    var result = await _nutritionDayRepository.AddAsync(addnutritionDay);
                    _ = await _nutritionDayRepository.SaveAsync();


                    // for nutritionSession table 
                    nutritionSession.NutritionDayId = addnutritionDay.Id;
                    _ = _nutritionSessionRepository.Update(nutritionSession);
                    _ = _nutritionSessionRepository.Save();


                    if (!result)
                        return false;
                }
            }
            return true;
        }


        private async Task<bool> InsertIfNotExist(List<DietProgramViewDto> input)
        {
            foreach (var workDay in input)
            {
                foreach (var foods in workDay.Foods)
                {
                    var checkfood = await _foodRepository.Table.FirstOrDefaultAsync(e => e.Name == foods.Name);
                    if (checkfood == null)
                    {
                        var add = await _foodRepository.AddAsync(new()
                        {
                            Name = foods.Name,
                            Description = foods.Description,
                            Calory = foods.Calory,
                            Carbonhydrate = foods.Carbonhydrate,
                            Protein = foods.Protein,
                        });
                        _ = await _foodRepository.SaveAsync();

                    }
                }

                foreach (var gram in workDay.Grams)
                {
                    var checkgram = _gramRepository.Table.FirstOrDefaultAsync(sr => sr.Amount.Equals(gram.Amount) && sr.Type.Equals(gram.Type));
                    if (checkgram.Result == null)
                    {
                        var add = await _gramRepository.AddAsync(new()
                        {
                          Type = gram.Type,
                          Amount = gram.Amount,
                        });
                        _ = await _foodRepository.SaveAsync();

                    }
                }
            }

            return true;
        }
    }
}
