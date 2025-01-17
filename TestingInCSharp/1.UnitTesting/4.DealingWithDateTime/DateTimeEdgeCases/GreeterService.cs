﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeEdgeCases
{
    internal class GreeterService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public GreeterService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        internal string GenerateGreetText()
        {
            var dateTimeNow = _dateTimeProvider.Now;
            return dateTimeNow.Hour switch
            {
                >= 5 and < 12 => "Good morning",
                >= 12 and < 18 => "Good afternoon",
                _ => "Good evening"
            };
        }
    }
}
