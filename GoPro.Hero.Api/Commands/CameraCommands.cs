﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPro.Hero.Api.Commands.CameraCommands
{
    [Command(HeroCommands.CAMERA_EXTENDED_SETTINGS, Parameterless = true)]
    class CommandCameraExtendedSettings : CommandRequest
    {
    }

    [Command(HeroCommands.CAMREA_INFORMATION, Parameterless = true)]
    class CommandCameraInformation : CommandRequest
    {
    }

    [Command(HeroCommands.CAMREA_LOCATE)]
    class CommandCameraLocate : CommandBoolean
    {
    }

    [Command(HeroCommands.CAMERA_PROTUNE)]
    class CommandCameraProtune : CommandBoolean
    {
    }

    [Command(HeroCommands.CAMERA_SETTINGS, Parameterless = true)]
    class CommandCameraSettings : CommandRequest
    {
    }

    [Command(HeroCommands.CAMREA_EXPOSURE)]
    class CommandCameraSpotMeter : CommandBoolean
    {
    }

    [Command(HeroCommands.CAMERA_ORIENTATION)]
    class CommandCameraOrientation : CommandRequest
    {
        private const string UP = "%00";
        private const string DOWN = "%01";

        public Orientation Orientation
        {
            get
            {
                return string.IsNullOrEmpty(base.parameter)
                ? Orientation.Up: base.parameter == UP
                ? Orientation.Up: Orientation.Down;
            }

            set
            {
                base.parameter = value == Orientation.Up ? UP : DOWN;
            }
        }
    }

    [Command(HeroCommands.CAMERA_MODE)]
    class CommandCameraMode : CommandRequest
    {
        private const string VIDEO = "%00";
        private const string PHOTO = "%01";
        private const string BURST = "%02";
        private const string TIME_LAPSE = "%03";

        public Mode Mode
        {
            get
            {
                switch (base.parameter)
                {
                    case VIDEO: return Mode.Video;
                    case PHOTO: return Mode.Photo;
                    case BURST: return Mode.Burst;
                    case TIME_LAPSE: return Mode.TimeLapse;
                    default: return Mode.Video;
                }
            }

            set
            {
                base.parameter = string.Format("%0{0}", (byte)value);
            }
        }
    }

    [Command(HeroCommands.CAMREA_LIVE_PREVIEW)]
    class CommandCameraPreview : CommandBoolean
    {
        private const string PREVIEW_ON = "%02";

        public override bool Enable
        {
            get
            {
                return string.IsNullOrEmpty(base.parameter) ? false : base.parameter == OFF ? false : true;
            }
            set
            {
                base.parameter = value ? PREVIEW_ON : OFF;
            }
        }
    }
}
