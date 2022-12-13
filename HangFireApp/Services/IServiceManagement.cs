﻿namespace HangFireApp.Services
{
    public interface IServiceManagement
    {
        void SendMail();
        void UpdateDatabase();
        void GenerateMerchandise();
        void SyncData();
    }
}
