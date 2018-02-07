﻿using CoreTemplate.Accessors.Models.EF.Base;

namespace CoreTemplate.Accessors.Models.EF
{
    public class MoviePerson : Entity
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public int JobTitleId { get; set; }

        public virtual JobTitle JobTitle { get; set; }
    }
}