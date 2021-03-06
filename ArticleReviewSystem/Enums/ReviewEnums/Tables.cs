﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleReviewSystem.Enums.ReviewEnums
{
    public enum Tables
    {
        [Display(Name = "Adequate")]
        Adequate,
        [Display(Name = "Should be rearranged to improve clarity")]
        ShouldBeRearrangedToImproveClarity,
        [Display(Name = "Some may be omitted")]
        SomeMayBeOmitted,
        [Display(Name = "More should be added (Write in a detailed comment)")]
        MoreShouldBeAdded
    }
}