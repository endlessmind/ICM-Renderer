﻿using ICM_Drawer.Drawing;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ICM_Drawer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[] referenceBmp = new byte[2110]{
0x42,0x4D,0x3E,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x3E,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x40,0x00,0x00,0x00,0x01,0x00,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x01,0xFF,0xE0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0xFF,0xF8,0x00,0x03,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0xFF,0xF8,0x00,0x03,0xFF,0xF0,0x00,0x0C,0xC7,0x8F,0x80,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0xFF,0xF8,0x00,0x03,0xFF,0xF0,0x00,0x0C,0xCC,0xC0,0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x01,0xFF,0xE0,0x00,0x0C,0xCC,0xC0,0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xCC,0xC7,0x80,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0C,0xCC,0xCC,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC0,0x7C,0x00,0x01,0x80,0xF8,0x00,0x07,0x8C,0xCC,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC0,0xFE,0x00,0x01,0x81,0xFC,0x00,0x03,0x0C,0xC7,0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0xC6,0x00,0x01,0x83,0x8C,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0x86,0x00,0x01,0x83,0x0C,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0x86,0x00,0x01,0x83,0x0C,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0xFE,0x00,0x01,0x83,0xFC,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0xFC,0x00,0x01,0x83,0xF8,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0x80,0x00,0x01,0x83,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC1,0x80,0x00,0x01,0x83,0x00,0x00,0x00,0x3C,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0xC1,0xC0,0x06,0x07,0x83,0x80,0x00,0x00,0x42,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0xC0,0xFE,0x0F,0x03,0x81,0xFC,0x00,0x00,0x81,0x24,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC0,0x7E,0x0F,0x01,0x80,0xFC,0x00,0x00,0x81,0x22,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0x00,0x00,0x00,0x00,0x00,0x61,0x42,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x19,0x42,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x05,0x82,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x7C,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x80,0xF8,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x01,0x06,0x80,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x01,0x0A,0x60,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x01,0x0A,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x01,0x12,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x00,0x92,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x61,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x00,0x00,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x07,0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x1E,0x07,0x83,0x07,0x81,0xE0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x3F,0x0F,0xC3,0x0F,0xC3,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x63,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x63,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x61,0x98,0x60,0x18,0x66,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x3F,0x0F,0xC0,0x0F,0xC3,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x1E,0x07,0x80,0x07,0x81,0xE0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
        const int bmpHeaderOffset = 61; //The sample contains the bmp-header of 62 bytes, so we should skip 0-61. This will not be needed when pulling data directly from the ICM.
        int pixelSize = 2;
        DirectBitmap bmp;

        byte[] LetterA = new byte[6]{ 0x78, 0x38, 0x28, 0x7C, 0x6C, 0xEE };
        byte[] LetterB = new byte[6] { 0xF8, 0x6C, 0x78, 0x6C, 0x6C, 0xF8 };
        byte[] LetterC = new byte[6] { 0x70, 0xD8, 0xC0, 0xC0, 0xD8, 0x70 };
        byte[] LetterD = new byte[6] { 0xF8, 0x6C, 0x6C, 0x6C, 0x6C, 0xF8 };
        byte[] LetterE = new byte[6] { 0xFC, 0x60, 0x78, 0x60, 0x6C, 0xFC };
        byte[] LetterF = new byte[6] { 0xFC, 0x60, 0x78, 0x60, 0x60, 0xF0 };
        byte[] LetterG = new byte[6] { 0x70, 0xD8, 0xC0, 0xF8, 0xD8, 0x78 };
        byte[] LetterH = new byte[6] { 0xEE, 0x6C, 0x7C, 0x6C, 0x6C, 0xEE };
        byte[] LetterI = new byte[6] { 0x78, 0x30, 0x30, 0x30, 0x30, 0x78 };
        byte[] LetterJ = new byte[6] { 0x3C, 0x18, 0x18, 0xD8, 0xD8, 0x70 };
        byte[] LetterK = new byte[6] { 0xEC, 0x68, 0x70, 0x78, 0x6C, 0x6C };
        byte[] LetterL = new byte[6] { 0xF0, 0x60, 0x60, 0x60, 0x6C, 0xFC };
        byte[] LetterM = new byte[6] { 0xC4, 0x6C, 0x6C, 0x7C, 0x54, 0xD4 };
        byte[] LetterN = new byte[6] { 0xEE, 0x74, 0x74, 0x6C, 0x6C, 0xe4 };
        byte[] LetterO = new byte[6] { 0x70, 0xD8, 0xD8, 0xD8, 0xD8, 0x70 };
        byte[] LetterP = new byte[6] { 0xF8, 0x6C, 0x6C, 0x78, 0x60, 0xF0 };
        byte[] LetterQ = new byte[6] { 0x70, 0xD8, 0xD8, 0xD8, 0x70, 0x18 };
        byte[] LetterR = new byte[6] { 0xF8, 0x6C, 0x6C, 0x78, 0x6C, 0xEC };
        byte[] LetterS = new byte[6] { 0x78, 0xC8, 0xF0, 0x38, 0x98, 0xF0 };
        byte[] LetterT = new byte[6] { 0xFC, 0xB4, 0x30, 0x30, 0x30, 0x78 };
        byte[] LetterU = new byte[6] { 0xEE, 0x6C, 0x6C, 0x6C, 0x6C, 0x38 };
        byte[] LetterV = new byte[6] { 0xEE, 0x6C, 0x28, 0x38, 0x38, 0x10 };
        byte[] LetterW = new byte[6] { 0xD6, 0x54, 0x54, 0x7C, 0x38, 0x28 };
        byte[] LetterX = new byte[6] { 0xCC, 0x78, 0x30, 0x30, 0x78, 0xCC };
        byte[] LetterY = new byte[6] { 0xE6, 0x66, 0x3C, 0x18, 0x18, 0x3C };
        byte[] LetterZ = new byte[6] { 0xF8, 0xD8, 0x30, 0x60, 0xD8, 0xF8 };

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Is bit 1 (black)
        /// </summary>
        /// <param name="b">Byte</param>
        /// <param name="bit">Single bit we want to test</param>
        /// <returns></returns>
        private Boolean isBlack(byte b, int bit)
        {
            //Basically a simple bitwise and a check if it's not 0
            return (b & (1 << bit -1)) != 0;
        }


        /// <summary>
        /// The WPF view named "Image" needs an BitmapImage as source.
        /// We have been drawing to a WinForm Bitmap (older standard) and this
        /// function converts it.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }


        /// <summary>
        /// Opens dialog to save the image
        /// </summary>
        /// <param name="bmp"></param>
        private void saveBmpToFile(Bitmap bmp)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "ICM-" + DateTime.Now.ToString("yyyy-dd-MM_HH_mm_ss") + ".jpg";
            if (dialog.ShowDialog() == true)
            {
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int row = 0;
            int pixel = 0; //We count up all pixels draw, every 256 pixels we move down a row
            bmp = new DirectBitmap(256 * pixelSize, 64 * pixelSize);
            //Reversed for-loop. First row is last in the data, so we have to loop from the back.
            for (int i = referenceBmp.Length -1; i > bmpHeaderOffset; i--)
            {
                byte currentb = referenceBmp[i];
                for (int j = 0; j < 8; j++) //8 bits in a byte
                {
                    
                    int pixelX = pixel % 256; //So we get X position by modulating the pixel count with 256 (256px wide)
                    pixelX = (256 - (pixelX + 1)) * pixelSize;// And then we reverse it, so pixel 256 becomes 0, 255->1, and so on.
                    //pixel % 256 can never be 256, therefore 256 - pixelX can never be lower than 1.
                    //This would cause the first column to be shifted forward by one pixel, but before we had "-1" on the X-position.
                    //This worked fine with rectangles, as we can change their size and it will all fit just fine.
                    //But with bitmap, we're drawing each pixels, so when we wanted to scale up the image by a factor of 2
                    //We would have the "1" from the calculation above but because we multiply (in this case by 2), the value
                    //of pixelX would be 2 and when we used "-1" we would be back at 1.
                    //This would be worse if we scaled by a factor of 3, then pixelX would never get lower than 2.

                    //Base-problem: if 'pixel' is 255 and is modulated by 256, the result would be 255.
                    //When 'pixel' reached 256, the modulation would return 0. So the result (pixelX) would never
                    //reach 256, and therefore the smalest possible value for 256 - pixelX would be 1.
                    //By adding "+1", we can reach 256 - 256 = 0  or 256 - (255 +1).
                    //This solves a rendering error with bitmap that was not present with WPF canvas.


                    

                    //Draw to bitmap.
                    bmp.SetPixel(pixelX, (row * pixelSize), isBlack(currentb, j + 1) ? Color.Black : Color.White);
                    if (pixelSize > 1)
                    {
                        for (int k = 0; k < pixelSize; k++)
                        {
                            for (int l = 0; l < pixelSize;l++)
                            {
                                bmp.SetPixel(pixelX + l, (row * pixelSize) + k, isBlack(currentb, j + 1) ? Color.Black : Color.White);
                            }
                        }
                    }

                    pixel++;
                    if (pixel % 256 == 0)
                    {
                        //256 pixel has been drawn, move to next row
                        row++;
                    }
                    
                }

            }

            //Show result
            imgResult.Source = BitmapToImageSource(bmp.Bitmap);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)//Save it
                saveBmpToFile(bmp.Bitmap);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            
            BufferProcessing bp = new BufferProcessing();
            int index = (256 / 2) - 40;
            bp.insertLetter(index, 10, LetterA, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterB, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterC, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterD, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterE, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterF, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterG, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterH, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterI, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterJ, ref referenceBmp);
            bp.insertLetter(index += 8, 10, LetterK, ref referenceBmp);
            
            //Next row
            bp.insertLetter(index = (256 / 2) - 40, 18, LetterL, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterM, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterN, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterO, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterP, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterQ, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterR, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterS, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterT, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterU, ref referenceBmp);
            bp.insertLetter(index += 8, 18, LetterV, ref referenceBmp);

            //Next row
            bp.insertLetter(index = (256 / 2) - 40, 26, LetterW, ref referenceBmp);
            bp.insertLetter(index += 8, 26, LetterX, ref referenceBmp);
            bp.insertLetter(index += 8, 26, LetterY, ref referenceBmp);
            bp.insertLetter(index += 8, 26, LetterZ, ref referenceBmp);

            bp.insertLetter(index = (256 / 2) - 20, 42, LetterH, ref referenceBmp);
            bp.insertLetter(index += 8, 42, LetterE, ref referenceBmp);
            bp.insertLetter(index += 8, 42, LetterL, ref referenceBmp);
            bp.insertLetter(index += 8, 42, LetterL, ref referenceBmp);
            bp.insertLetter(index += 8, 42, LetterO, ref referenceBmp);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
