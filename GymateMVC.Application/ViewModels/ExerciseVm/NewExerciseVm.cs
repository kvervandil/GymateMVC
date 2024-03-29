﻿using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseVm
{
    public class NewExerciseVm : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseTypeId { get; set; }
        public List<SelectListItem> SelectListExerciseTypes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, NewExerciseVm>();
        }
    }
}
