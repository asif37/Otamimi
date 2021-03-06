﻿using System.ComponentModel.DataAnnotations;
using Otamimi.Models;

namespace WebApplication17.ViewModels
{
    public class BankViewModel
    {


        [Required]
        [Display(Name = "اسم البنك")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "بنك محلي؟")]
        public BankType Type { get; set; }


    }
}