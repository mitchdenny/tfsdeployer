﻿using System;
using System.Management.Automation.Host;

namespace TfsDeployer.DeployAgent
{
    // Based on Microsoft.Windows.PowerShell.Gui.Internal.GPSHostRawUserInterface, Microsoft.PowerShell.GPowerShell, Version=1.0.0.0
    public sealed class DeploymentHostRawUi : PSHostRawUserInterface
    {
        private int _bufferWidth = 100;
        
        public DeploymentHostRawUi()
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
        }

        public override void FlushInputBuffer()
        {
            throw new NotSupportedException();
        }

        public override BufferCell[,] GetBufferContents(Rectangle rectangle)
        {
            throw new NotSupportedException();
        }

        public override KeyInfo ReadKey(ReadKeyOptions options)
        {
            throw new NotSupportedException();
        }

        public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
        {
            throw new NotSupportedException();
        }

        public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
        {
            throw new NotSupportedException();
        }

        public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
        {
            throw new NotSupportedException();
        }

        public override ConsoleColor BackgroundColor { get; set; }

        public override Size BufferSize
        {
            get
            {
                return new Size(_bufferWidth, 0);
            }
            set
            {
                _bufferWidth = value.Width > 80 ? value.Width : 80;
            }
        }

        public override Coordinates CursorPosition { get; set; }

        public override int CursorSize
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override ConsoleColor ForegroundColor { get; set; }

        public override bool KeyAvailable
        {
            get { return false; }
        }

        public override Size MaxPhysicalWindowSize
        {
            get { throw new NotSupportedException(); }
        }

        public override Size MaxWindowSize
        {
            get { throw new NotSupportedException(); }
        }

        public override Coordinates WindowPosition
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override Size WindowSize
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override string WindowTitle { get; set; }
    }
}