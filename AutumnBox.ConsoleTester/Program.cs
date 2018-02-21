﻿using AutumnBox.Basic.ACP;
using AutumnBox.Basic.Adb;
using AutumnBox.Basic.Device;
using AutumnBox.Basic.Device.PackageManage;
using AutumnBox.Basic.Executer;
using AutumnBox.Basic.MultipleDevices;
using AutumnBox.Basic.Util;
using AutumnBox.Support.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutumnBox.ConsoleTester
{
    class Program
    {
        public readonly static DeviceBasicInfo mi6 = new DeviceBasicInfo()
        {
            Serial = new DeviceSerial("af0fe186"),
            State = DeviceState.Poweron,
        };
        public readonly static DeviceBasicInfo mi6net = new DeviceBasicInfo()
        {
            Serial = new DeviceSerial("192.168.0.12:5555"),
            State = DeviceState.Poweron,
        };
        public readonly static DeviceBasicInfo mi4 = new DeviceBasicInfo()
        {
            Serial = new DeviceSerial("9dd1b490"),
            State = DeviceState.Poweron,
        };
        unsafe static int Main(string[] cmdargs)
        {
            UserManager um = new UserManager(mi6.Serial);
            foreach (User user in um.GetUsers())
            {
                Console.WriteLine($"{user.Id} {user.Name}");
            }
            Console.ReadKey();
            return 0;
        }
        private class Test : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("dispose");
            }
            ~Test()
            {
                Console.WriteLine("Finalize");
            }
        }
    }
}
