﻿using ImageService.Commands;
using ImageService.Infrastructure.Enums;
using ImageService.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageService.ImageService.Commands {
    class GetConfigCommand : ICommand {

        public string Execute(string[] args, out bool result) {
            try {
                string[] arr = new string[5];
                arr[0] = ConfigurationManager.AppSettings.Get("OutputDir");
                arr[1] = ConfigurationManager.AppSettings.Get("SourceName");
                arr[2] = ConfigurationManager.AppSettings.Get("LogName");
                arr[3] = ConfigurationManager.AppSettings.Get("ThumbnailSize");
                arr[4] = ConfigurationManager.AppSettings.Get("Handler");
                CommandRecievedEventArgs commandArgs = new CommandRecievedEventArgs((int)CommandEnum.GetConfigCommand, arr, "");
                result = true;
                return JsonConvert.SerializeObject(commandArgs);
            } catch (Exception e) {
                result = false;
                return e.ToString();
            }
        }
    }
}
