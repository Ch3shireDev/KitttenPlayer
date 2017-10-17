﻿using System;
using System.Diagnostics;

namespace KittenPlayer
{

    public partial class MusicPlayer
    {
        private static MusicPlayer instance = null;
        public static MusicPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicPlayer();
                }
                return instance;
            }
        }
        Player player = new MFPlayer();

        private MusicPlayer(){}

        public Track CurrentTrack = null;
        public MusicTab CurrentTab = null;

        public double Progress
        {
            get { return player.Progress; }
            set { player.Progress = value; }
        }

        public double Volume
        {
            get { return player.Volume; }
            set { player.Volume = value; }
        }
      
        String GetTime()
        {
            if (player.IsPlaying)
            {
                int seconds = (int)player.TotalMilliseconds / 1000 % 60;
                int minutes = (int)player.TotalMilliseconds / 1000 / 60 % 60;
                int hours = (int)player.TotalMilliseconds / 1000 / 60 / 60;
                
                if (hours > 0)
                {
                    return String.Format("{0}:{1:00}:{2:00}", hours, minutes, seconds);
                }
                else
                {
                    return String.Format("{0:00}:{1:00}", minutes, seconds);
                }
            }
            else
            {
                return "0:00";
            }
        }

        public bool IsPlaying { get => player.IsPlaying; }
        public bool IsPaused { get => player.IsPaused; }
        
        public void Play(String File)
        {
            player.Load(File);
            player.Play();
        }

        public void Load(Track track)
        {
            player.Load(track.filePath);
        }

        public void Play(Track track)
        {
            Load(track);
            player.Play();
        }
        public void Play() => player.Play();
        public void Pause() => player.Pause();
        public void Stop() => player.Stop();

        public void Next() { }
        public void Previous() { }
    }
}
