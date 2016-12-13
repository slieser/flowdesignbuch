﻿using System;
using System.Text;

namespace csvviewer
{
    public class Program
    {
        public static void Main(string[] args) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var interactors = new Interactors();
            var ui = new Ui();

            Action start = () => {
                var records = interactors.Start(args);
                ui.Display(records);
            };

            start();
        }
    }
}