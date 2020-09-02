﻿using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface ICompetitionService
    {
        IEnumerable<GroupResult> FirstRound(int drawId);

        IEnumerable<GroupResult> SecondRound(int drawId);

        IEnumerable<GroupResult> GroupsSummaries(IEnumerable<GroupResult> groupResults);
    }
}