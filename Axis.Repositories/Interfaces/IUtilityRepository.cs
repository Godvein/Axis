using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Axis.Repositories.Interfaces
{
    public interface IUtilityRepository
    {
        public void LogActivity(string Activity, int? UserId = null, string ActivityType = "General");
    }
}
