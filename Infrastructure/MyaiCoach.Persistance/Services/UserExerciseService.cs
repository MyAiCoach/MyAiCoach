﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Exceptions;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.ExerciseDtos;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Domain.Enums;
using MyaiCoach.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Services
{
    public class UserExerciseService : IUserExerciseService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ISetRepRepository _setRepRepository;
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IWorkoutSessionRepository _workoutSessionRepository;

        public UserExerciseService(UserManager<AppUser> userManager, IExerciseRepository exerciseRepository, ISetRepRepository setRepRepository, IWorkoutDayRepository workoutDayRepository, IWorkoutSessionRepository workoutSessionRepository)
        {
            _userManager = userManager;
            _exerciseRepository = exerciseRepository;
            _setRepRepository = setRepRepository;
            _workoutDayRepository = workoutDayRepository;
            _workoutSessionRepository = workoutSessionRepository;
        }

        public async Task<List<ProgramViewDto>> GetWorkoutProgramAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId), "UserId must be exist");

            var result = new List<ProgramViewDto>();


            var getWorkoutDays = _workoutDayRepository.GetWhere(w => w.AppUserId == userId).ToList();
            if (getWorkoutDays == null)
                throw new UserNotFoundException($"{userId} user no is empty");

            foreach (var dayGroup in getWorkoutDays.GroupBy(w => w.Days))
            {
                var dayProgram = new ProgramViewDto
                {
                    Day = dayGroup.Key,
                    Exercises = new List<ExerciseViewDto>(),
                    SetReps = new List<SetRepViewDto>()
                };

                foreach (var workoutDay in dayGroup)
                {
                    var getWorkoutSession = await _workoutSessionRepository.Table.FirstOrDefaultAsync(w => w.Id == workoutDay.WorkoutSessionId);

                    if (getWorkoutSession == null)
                        continue; // or handle the situation accordingly

                    var getExercise = await _exerciseRepository.Table.FirstOrDefaultAsync(e => e.Id == getWorkoutSession.ExerciseId);
                    dayProgram.Exercises.Add(new ExerciseViewDto
                    {
                        Name = getExercise.Name,
                        Description = getExercise.Description,
                        TargetArea = getExercise.TargetArea,
                    });

                    var getSetRep = await _setRepRepository.Table.FirstOrDefaultAsync(sr => sr.Id == getWorkoutSession.SetRepId);
                    dayProgram.SetReps.Add(new SetRepViewDto
                    {
                        Set = getSetRep.Set,
                        Rep = getSetRep.Rep,
                    });
                }

                result.Add(dayProgram);
            }

            return result;
        }

        public async Task<bool> SaveWorkoutAsync(Guid userId, List<ProgramViewDto> input)
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
                for (var i = 0; i < days.Exercises.Count; i++)
                {
                    var currentExercise = days.Exercises[i];
                    var currentSetRep = days.SetReps.Count == 1 ? days.SetReps[0] : days.SetReps[i];

                    var getExercise = await _exerciseRepository.GetSingleAsync(e => e.Name == currentExercise.Name);
                    if (getExercise == null)
                        continue;

                    var getSetRep = await _setRepRepository.GetSingleAsync(sr => sr.Set == currentSetRep.Set && sr.Rep == currentSetRep.Rep);
                    if (getSetRep == null)
                        continue;

                    var workoutSession = await _workoutSessionRepository.Table.FirstOrDefaultAsync(
                          w => w.SetRepId == getSetRep.Id &&
                             w.ExerciseId == getExercise.Id);

                    if (workoutSession == null)
                    {
                        workoutSession = new WorkoutSession()
                        {
                            ExerciseId = getExercise.Id,
                            SetRepId = getSetRep.Id,

                        };
                        _ = await _workoutSessionRepository.AddAsync(workoutSession);
                    }

                    var addWorkoutDay = new WorkoutDay()
                    {
                        AppUserId = getUser.Id,
                        Days = days.Day,
                        WorkoutSessionId = workoutSession.Id,
                    };
                    var result = await _workoutDayRepository.AddAsync(addWorkoutDay);
                    _ = await _workoutDayRepository.SaveAsync();


                    // for workoutSession table 
                    workoutSession.WorkoutDayId = addWorkoutDay.Id;
                    _ = _workoutSessionRepository.Update(workoutSession);
                    _ = _workoutSessionRepository.Save();


                    if (!result)
                        return false;
                }
            }
            return true;
        }


        private async Task<bool> InsertIfNotExist(List<ProgramViewDto> input)
        {
            foreach (var workDay in input)
            {
                foreach (var exercises in workDay.Exercises)
                {
                    var checkExercise = await _exerciseRepository.Table.FirstOrDefaultAsync(e => e.Name == exercises.Name);
                    if (checkExercise == null)
                    {
                        var add = await _exerciseRepository.AddAsync(new()
                        {
                            Name = exercises.Name,
                            Description = exercises.Description,
                            TargetArea = exercises.TargetArea,
                        });
                        _ = await _exerciseRepository.SaveAsync();

                    }
                }

                foreach (var setRep in workDay.SetReps)
                {
                    var checkSetRep = _setRepRepository.Table.FirstOrDefaultAsync(sr => sr.Set.Equals(setRep.Set) && sr.Rep.Equals(setRep.Rep));
                    if (checkSetRep.Result == null)
                    {
                        var add = await _setRepRepository.AddAsync(new()
                        {
                            Set = setRep.Set,
                            Rep = setRep.Rep,
                        });
                        _ = await _exerciseRepository.SaveAsync();

                    }
                }
            }

            return true;
        }
    }
}