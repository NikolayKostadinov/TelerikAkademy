﻿using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace HiddenTruth.BackgroundTasks
{
    public sealed class TileSchedulerTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            ClockTileScheduler.CreateSchedule();
            deferral.Complete();
        }
    }
}
