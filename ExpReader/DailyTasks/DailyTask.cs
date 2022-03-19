﻿using System;
using System.Collections.Generic;
using ExpReader.AppSettings;
using System.Text;
using Acr.UserDialogs;
using ExpReader.Services;
using Xamarin.Essentials;
using Newtonsoft.Json;
using DAL.Models;

namespace ExpReader.DailyTasks
{
    static class DailyTask
    {
        public static int TodayReadPages;


        public static void UpdateTodayReadPages()
        {
            TodayReadPages++;
            Preferences.Set(nameof(TodayReadPages), TodayReadPages);
            CheckTaskComletion();
        }
        private static void CheckTaskComletion()
        {
            TodayReadPages = Preferences.Get(nameof(TodayReadPages), 0);
            if (TodayReadPages == Settings.DailyTask)
            {
                var st = Settings.userStats;
                var stats = JsonConvert.DeserializeObject<UserStats>(st);
                stats.ReadPages = Settings.DailyTask;
                UserDialogs.Instance.Alert($"Вы выполнили ежедневное задание и получаете {Settings.DailyTask} очков", "Поздравляем");
            }
        }

    }
}
