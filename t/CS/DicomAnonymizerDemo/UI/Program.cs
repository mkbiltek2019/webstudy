﻿// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Demos;

namespace DicomAnonymizer
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         DicomEngine.Startup();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());

         DicomEngine.Shutdown();
      }
   }
}