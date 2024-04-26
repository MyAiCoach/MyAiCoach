using MyaiCoach.Application.Exceptions;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
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

        private readonly IAppUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ISetRepRepository _setRepRepository;
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IWorkoutSessionRepository _workoutSessionRepository;

        public UserExerciseService(IAppUserRepository userRepository, IExerciseRepository exerciseRepository, ISetRepRepository setRepRepository, IWorkoutDayRepository workoutDayRepository, IWorkoutSessionRepository workoutSessionRepository)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _setRepRepository = setRepRepository;
            _workoutDayRepository = workoutDayRepository;
            _workoutSessionRepository = workoutSessionRepository;
        }

        public async Task<bool> SaveWorkoutAsync(Guid userId, List<ProgramViewDto> input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input must be exist");

            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId), "UserId must be exist");

            var getUser = _userRepository.GetSingleAsync(u => u.Id == userId);

            if (getUser == null)
                throw new UserNotFoundException($"{userId} user no is empty");

            var insert = await InsertIfNotExist(input);

            if (!insert)
                return false;

            foreach (var days in input)
            {
                var sessionIds = new List<Guid>();

                for (var i = 0; i < days.Exercises.Count; i++)
                {
                    var currentExercise = days.Exercises[i];
                    var currentSetRep = days.SetReps[i];


                    var getExercise = _exerciseRepository.GetSingleAsync(e => e.Name == currentExercise.Name);
                    if (getExercise == null)
                        continue;

                    var getSetRep = _setRepRepository.GetSingleAsync(sr => sr.Set == currentSetRep.Set && sr.Rep == currentSetRep.Rep);
                    if (getSetRep == null)
                        continue;

                    var workoutSession = await _workoutSessionRepository.GetSingleAsync(
                        w => w.SetRepId == getSetRep.Result.Id &&
                             w.ExerciseId == getExercise.Result.Id);

                    if (workoutSession == null)
                    {
                        workoutSession = new WorkoutSession()
                        {
                            ExerciseId = getExercise.Result.Id,
                            SetRepId = getSetRep.Result.Id
                        };
                        _ = await _workoutSessionRepository.AddAsync(workoutSession);
                    }

                    sessionIds.Add(workoutSession.Id);
                }
                

                var addWorkoutDay = await _workoutDayRepository.AddAsync(new()
                {
                    AppUserId = getUser.Result.Id,
                    Days = days.Day,
                    WorkoutSessionsIds = sessionIds
                });

                if (!addWorkoutDay)
                {
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
                    var checkExercise = await _exerciseRepository.GetSingleAsync(e => e.Name == exercises.Name);
                    if (checkExercise == null)
                    {
                        var add = await _exerciseRepository.AddAsync(new()
                        {
                            Name = exercises.Name,
                            Description = exercises.Description,
                            TargetArea = exercises.TargetArea,
                        });
                    }
                }

                foreach (var setRep in workDay.SetReps)
                {
                    var checkSetRep = await _setRepRepository.GetSingleAsync(sr => sr.Set == setRep.Set && sr.Rep == setRep.Rep);
                    if (checkSetRep == null)
                    {
                        var add = await _setRepRepository.AddAsync(new()
                        {
                            Set = setRep.Set,
                            Rep = setRep.Rep,
                        });
                    }
                }
            }

            return true;
        }
    }
}