﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Infrastructure;
using WebApplication1.Models;
using WebApplication1.DAL;
using WebApplication1.Repository;


namespace WebApplication1.Service
{

    /*  public interface IMealService
      {
          IEnumerable<Meal> GetMeals();
          Meal GetMealById(int id);
          Meal GetMealByName(string name);
          void AddMeal(Meal meal);

          void AddFoodToMeak(int mealId, int foodId);
          void UpdateMeal(Meal food);
          void RemoveMeal(int id);
          void SaveMeal();
      } */



    public class MealService : IMealService
    {
        IFoodRepository foodRepository;
        IMealRepository mealRepository;
        IUnitOfWork unitOfWork;

        public MealService(IFoodRepository foodRepository, IMealRepository mealRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.foodRepository = foodRepository;
            this.mealRepository = mealRepository;
        }

        public void AddFoodToMeal(int mealId, int foodId)
        {
            mealRepository.AttachFoodToMeal(mealId, foodId);
        }

        public Meal GetMealWithFoods(int mealId)
        {
            return mealRepository.GetMealWithFoods(mealId);
        }

        public IEnumerable<Meal> GetMeals()
        {
            return mealRepository.GetAll();
        }

        public IEnumerable<Meal> SortMealsByDate()
        {
            var meals = mealRepository.GetAll();
            return meals.OrderByDescending(d => d.SetDate);
        }

        public Meal GetMealById(int id)
        {
            return mealRepository.GetById(id);
        }

        public void AddMeal(Meal meal)
        {
            mealRepository.Add(meal);
        }

        public void UpdateMeal(Meal meal)
        {
            mealRepository.Update(meal);
        }

        public void SaveMeals()
        {
            unitOfWork.Commit();
        }

        //TODO IMealService
    }

    public interface IMealService
    {
        public void AddFoodToMeal(int mealId, int foodId);
        public void SaveMeals();
        public void UpdateMeal(Meal meal);
        public void AddMeal(Meal meal);
        public Meal GetMealById(int id);
        public IEnumerable<Meal> GetMeals();

    }
}