/*
 * File: UserDBSettings.cs
 * Author: Wanni Arachchige H.S
 * Date: October 8, 2023
 * Description: This file defines the UserDBSettings class, which represents the implementation for the IUserDBSettings interface.
 * Reference: https://youtube.com/playlist?list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&si=cyZFtfJ6-tAtDonz
 */

using EAD_BACKEND.Interfaces;
namespace EAD_BACKEND.Implementations
{
    public class UserDBSettings : IUserDBSettings
    {
        public string UserCollectionName { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
    }
}
